using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Spartane.Core.Domain.Binnacle;
using Spartane.Core.Domain.User;
using Spartane.Web.Areas.Frontal.Models;

namespace Spartane.Web.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }
    }

    public class ManageUserViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginViewModel
    {
        [Required(ErrorMessageResourceType = typeof(Resources.LoginResources),
                  ErrorMessageResourceName = "UserNameRequired")]
        [Display(Name = "UserName", ResourceType = typeof(Resources.LoginResources))]
        public string UserName { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.LoginResources),
                  ErrorMessageResourceName = "PasswordRequired")]
        [DataType(DataType.Password)]
        [Display(Name = "Password", ResourceType = typeof(Resources.LoginResources))]
        public string Password { get; set; }

        [Display(Name = "Language", ResourceType = typeof(Resources.LoginResources))]
        public IList<LanguageModel> LanguageList { get; set; }

        public int? SelectedLanguage { get; set; }

        [Display(Name = "RememberMe", ResourceType = typeof(Resources.LoginResources))]
        public bool RememberMe { get; set; }

        public int FailedAttempts { get; set; }
        public int MaxFailedAttempts { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessageResourceType = typeof(Resources.LoginResources),
                  ErrorMessageResourceName = "UserNameRequired")]
        [Display(Name = "UserName", ResourceType = typeof(Resources.LoginResources))]
        public string UserName { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.LoginResources),
                  ErrorMessageResourceName = "EmailRequired")]
        [DataType(DataType.EmailAddress, ErrorMessageResourceType = typeof(Resources.LoginResources), ErrorMessageResourceName = "InvalidEmail")]
        [EmailAddress(ErrorMessageResourceType = typeof(Resources.LoginResources), ErrorMessageResourceName = "InvalidEmail", ErrorMessage = null)]
        [Display(Name = "Email", ResourceType = typeof(Resources.LoginResources))]
        public string Email { get; set; }

    }

    public class ChangePasswordViewModel
    {

        public int Id_User { get; set; }

        public bool IsSuccess { get; set; }

        public string OperationMessage { get; set; }

        public string ExpirationMessage { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.LoginResources),
                  ErrorMessageResourceName = "UserNameRequired")]
        [Display(Name = "UserName", ResourceType = typeof(Resources.LoginResources))]
        public string UserName { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.LoginResources),
                  ErrorMessageResourceName = "EmailRequired")]
        [DataType(DataType.EmailAddress, ErrorMessageResourceType = typeof(Resources.LoginResources), ErrorMessageResourceName = "InvalidEmail")]
        [EmailAddress(ErrorMessageResourceType = typeof(Resources.LoginResources), ErrorMessageResourceName = "InvalidEmail", ErrorMessage = null)]
        [Display(Name = "Email", ResourceType = typeof(Resources.LoginResources))]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "CurrentPassword", ResourceType = typeof(Resources.LoginResources))]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessageResourceName = "CharactersLong", ErrorMessageResourceType = typeof(Resources.Resources), MinimumLength = 4)]
        [DataType(DataType.Password)]
        [Display(Name = "NewPassword", ResourceType = typeof(Resources.LoginResources))]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "ConfirmNewPassword", ResourceType = typeof(Resources.LoginResources))]
        [Compare("NewPassword", ErrorMessageResourceName = "PasswordMatch", ErrorMessageResourceType = typeof(Resources.LoginResources))]
        public string ConfirmPassword { get; set; }



    }

    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class InformationUser
    {
        public IList<ModulesData> ModulesPermited { get; set; }

        public IList<DashBoardData> DashBoardsPermited { get; set; }

        public GlobalData GlobalData { get; set; }

        public IList<OperationPermited> OperationsPermited{get; set;}

    }

    public class OperationPermited
    {
        public bool Permited {get; set;}
        public Operations Operation {get;set;}
    }

    public class VersionValidation
    {
        public string VersionWebApi { get; set; }
        public string VersionDB { get; set; }
        public string VersionMVC { get; set; }
    }
}
