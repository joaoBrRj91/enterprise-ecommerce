using Microsoft.AspNetCore.Mvc;
using NSE.Shared.Models.Common;

namespace NSE.WebApp.MVC.Controllers;

public abstract class MainController : Controller
{
    private const string GENERIC_ERROR = "Ocorred An Generic Error In Integration Service Try Again.";

    protected bool HasErrorsInIntegration(ResponseResult responseResult)
    {
        if (responseResult.Errors?.Length > 0)
        {
            foreach (var error in responseResult.Errors)
            {
                ModelState.AddModelError(string.Empty, error);
            }

            return true;
        }

        if(!responseResult.IsSuccess)
        {
            ModelState.AddModelError(string.Empty, GENERIC_ERROR);
            return true;
        }

        return false;
    }

}