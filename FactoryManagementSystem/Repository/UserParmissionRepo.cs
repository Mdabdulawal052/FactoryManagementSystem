using FactoryManagementSystem.Data;
using FactoryManagementSystem.Data.AdditionUserData;
using FactoryManagementSystem.Data.ViewModels;
using FactoryManagementSystem.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;


namespace FactoryManagementSystem.Repository
{
    public class UserParmissionRepo:IUserPermissionRepo
    {

        SqlCommand Command;
        public ApplicationDbContext Context { get; }
        public IConfiguration Configuration { get; }
       

        public UserParmissionRepo(ApplicationDbContext context, IConfiguration configuration)
        {
            Context = context;
            Configuration = configuration;
           
        }

        public bool GetPermission(string RoleName, string CurrentUserName)
        {
            object obj;
            bool per = false;
            var CurrentUser = Context.Users.FirstOrDefault(x => x.UserName == CurrentUserName);
            string CurrentUserId = CurrentUser.Id;
            //Context.PermissionMaps.Include(x=>x.us)
            using (SqlConnection con = new SqlConnection(Configuration.GetConnectionString("DefaultConnection")))
            {

                // Customer  Permittion
                string query01 = string.Format(@"SELECT  pmap.IsPermitted
                                            FROM PermissionMaps pmap
	                                         INNER JOIN 
                                            UserRoles uRole ON pmap.RoleId=uRole.RoleId
                                            WHERE 
                                            pmap.[ApplicationUserId]='{0}' AND pmap.IsPermitted=1 
                                            AND uRole.Name='{1}'", CurrentUserId, RoleName);
                Command = new SqlCommand(query01, con);
                con.Open();
                obj = Command.ExecuteScalar();
                con.Close();
            }

            if (!System.DBNull.Value.Equals(obj))
            {
                per = Convert.ToBoolean(obj);
            }
            return per;
        }
       

        public IEnumerable<PermissionViewModel> GetPermissionData(string name)
        {
            List<PermissionViewModel> PermissionsList = new List<PermissionViewModel>();
           
            using (SqlConnection con = new SqlConnection(Configuration.GetConnectionString("DefaultConnection")))
            {

                // Customer  Permittion
                SqlDataReader reader;
                string query01 = string.Format(@"SELECT pmap.PermissionId,uRole.RoleId,pmap.UserId, u.Name,"
                                              +" uRole.Name as PermissionName,pmap.IsPermitted FROM PermissionMaps pmap"+
			                                            " INNER JOIN UserRoles uRole ON pmap.RoleId=uRole.RoleId"+
			                                            " INNER JOIN AspNetUsers u ON pmap.UserId=u.Id"+
                                                        " where  username IS NULL OR LEN('{0}') = 0 or (username Like '%{0}%')", name);
                Command = new SqlCommand(query01, con);
                con.Open();
                reader = Command.ExecuteReader();
                if (reader.HasRows)
                {
                   
                    while (reader.Read())
                    {
                        PermissionViewModel model = new PermissionViewModel();
                        model.PermissionId = reader.GetInt32(reader.GetOrdinal("PermissionId"));

                        model.UserId = reader.GetString(reader.GetOrdinal("UserId"));
                        model.UserName = reader.GetString(reader.GetOrdinal("Name"));
                        model.RoleId = reader.GetInt32(reader.GetOrdinal("RoleId"));
                        model.RoleName = reader.GetString(reader.GetOrdinal("PermissionName"));
                        model.IsPermitted = reader.GetBoolean(reader.GetOrdinal("IsPermitted"));
                        PermissionsList.Add(model);
                    }

                }
               
                con.Close();
            }
            return PermissionsList;
        }

        public void CreateUserParmission(string Id)
        {
            var userRoles = Context.UserRoles.ToList();
            
            //var mapData = Context.PermissionMaps.Where(x => x.ApplicationUserId == Id).Include(x => x.UserRole).ToList();
            foreach (var item in userRoles)
            {
                var mapData = Context.PermissionMaps.Where(x => x.ApplicationUserId == Id).FirstOrDefault(x=>x.RoleId==item.RoleId);

                if (mapData != null) 
                {
                    
                    continue;
                }
                
                PermissionMap permissionMap = new PermissionMap()
                {
                    RoleId = item.RoleId,
                    ApplicationUserId = Id,
                    IsPermitted = false
                };
                Context.PermissionMaps.Add(permissionMap);
                Context.SaveChanges();
            }
            
        }
    }
}
