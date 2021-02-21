using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

