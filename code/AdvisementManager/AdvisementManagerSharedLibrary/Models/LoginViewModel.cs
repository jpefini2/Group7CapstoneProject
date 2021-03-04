using System.ComponentModel.DataAnnotations;

namespace AdvisementManagerSharedLibrary.Models
{
    public class LoginViewModel
    {
        #region Properties  

        /// <summary>
        /// The username entry of this user.
        /// </summary>
        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }

        /// <summary>
        /// The password entry for this user.s
        /// </summary>
        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }

        #endregion
    }
}
