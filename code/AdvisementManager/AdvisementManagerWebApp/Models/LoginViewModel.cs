using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class LoginViewModel
{
    #region Properties  

    [Required]
    [Display(Name = "Username")]
    public string Username { get; set; }

    [Required]
    [Display(Name = "Password")]
    public string Password { get; set; }

    #endregion
}

