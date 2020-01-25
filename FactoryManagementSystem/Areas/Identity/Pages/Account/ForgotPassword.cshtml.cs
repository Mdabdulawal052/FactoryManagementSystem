using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using FactoryManagementSystem.Data.AdditionUserData;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FactoryManagementSystem.Data;
using FactoryManagementSystem.Repository.IRepository;
using System.Net.Mail;
using System.Net;

namespace FactoryManagementSystem.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class ForgotPasswordModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmailSender _emailSender;
        public IUserPermissionRepo Repo { get; }
        public ForgotPasswordModel(UserManager<ApplicationUser> userManager, IEmailSender emailSender, IUserPermissionRepo repo)
        {
            _userManager = userManager;
            _emailSender = emailSender;
            Repo = repo;
        }

        [BindProperty]
        public InputModel Input { get; set; }
        

        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {

                //var user = await _userManager.FindByEmailAsync(Input.Email);
                var user = Repo.GetUserByEmail(Input.Email);

                if (user == null /*|| !(await _userManager.IsEmailConfirmedAsync(user))*/)
                {
                    // Don't reveal that the user does not exist or is not confirmed
                    return RedirectToPage("./ForgotPasswordConfirmation");
                }

                // For more information on how to enable account confirmation and password reset please 
                // visit https://go.microsoft.com/fwlink/?LinkID=532713
                var code = await _userManager.GeneratePasswordResetTokenAsync(user);
                var callbackUrl = Url.Page(
                    "/Account/ResetPassword",
                    pageHandler: null,
                    values: new { code },
                    protocol: Request.Scheme);


                //string To = Input.Email;
                //string Subject = "Reset Password";
                //string Body = "Please reset your password by ";/*<a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.";*/
                //MailMessage mm = new MailMessage();
                //mm.To.Add(To);
                //mm.Subject = Subject;
                //mm.Body = Body;
                //mm.IsBodyHtml = true;
                //mm.SubjectEncoding = System.Text.Encoding.UTF8;
                //mm.Priority = MailPriority.High;
                //mm.From =  new MailAddress(MasterConfrg.FromMail);
                //SmtpClient smtp = new SmtpClient();
                //smtp.Host = "smtp.gmail.com";
                //smtp.Port = 587;
                //smtp.UseDefaultCredentials = false;
                //smtp.EnableSsl = true;
                //smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                //NetworkCredential nc = new NetworkCredential("md.abdul.awal96816@gmail.com", "foysal123");//MasterConfrg.FromMail, MasterConfrg.MailPassword
                //smtp.Credentials = nc;

                //await smtp.SendMailAsync(mm);




                await _emailSender.SendEmailAsync(
                    Input.Email,
                    "Reset Password",
                    $"Please reset your password by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                return RedirectToPage("./ForgotPasswordConfirmation");
            }

            return Page();
        }
    }
}
