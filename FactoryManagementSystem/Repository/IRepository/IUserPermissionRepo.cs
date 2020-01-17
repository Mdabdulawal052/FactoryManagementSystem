using FactoryManagementSystem.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FactoryManagementSystem.Repository.IRepository
{
    public interface IUserPermissionRepo
    {
         bool GetPermission(string RoleName, string CurrentUserName);
        IEnumerable<PermissionViewModel> GetPermissionData(string name);
        void CreateUserParmission(string Id);
    }
}
