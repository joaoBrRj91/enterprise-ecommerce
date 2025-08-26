using NSE.WebApp.MVC.Models;
using System.Net;

namespace NSE.WebApp.MVC.Configurations
{
    public static class Constants
    {
        public const string AdminPolicy = "Admin";
        public const string UserPolicy = "User";
        public const string LoginPath = "/sign-in";
        public const string AccessDeniedPath = "/erro/403";
    }
}
