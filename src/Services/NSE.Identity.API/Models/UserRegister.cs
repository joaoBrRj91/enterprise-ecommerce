using System.ComponentModel.DataAnnotations;

namespace NSE.Identity.API.Models;

public class UserRegister : UserData
{
    [Compare("Senha", ErrorMessage = "As senhas não conferem.")]
    public string PasswordConfirm { get; set; }
}

