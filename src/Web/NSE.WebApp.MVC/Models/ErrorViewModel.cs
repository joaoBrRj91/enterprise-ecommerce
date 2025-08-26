using System.Net;

namespace NSE.WebApp.MVC.Models
{
    public class ErrorViewModel
    {
        public string? Title { get; private set; }

        public string? Message { get; private set; }

        public HttpStatusCode StatusCode { get; private set; }


        public ErrorViewModel CreateErrorModelByStatusCode(int statusCode)
        {
            var statusCodeType = Enum.Parse<HttpStatusCode>(statusCode.ToString());

            switch (statusCodeType)
            {
                case HttpStatusCode.NotFound:
                    StatusCode = HttpStatusCode.NotFound;
                    Title = "Not Found Resource";
                    Message = "Not Found Resource. Verifed again or contact admin.";
                    break;
                case HttpStatusCode.Forbidden:
                    StatusCode = HttpStatusCode.NotFound;
                    Title = "Not Permission";
                    Message = "Not Permission. Contact admin for more details.";
                    break;
                default:
                    StatusCode = HttpStatusCode.InternalServerError;
                    Title = "Error In Application";
                    Message = "Oops! Something went wrong, but don't worry." +
                          " We'll let you know our schedule and we'll schedule it shortly!";
                    break;

            }

            return this;
        }
    }
}
