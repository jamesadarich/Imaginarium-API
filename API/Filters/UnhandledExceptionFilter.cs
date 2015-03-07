using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;
using ErrorReaper.Managers.Adapters;

namespace Imaginarium.API.Filters
{
    public class UnhandledExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            var request = HttpWebRequest.CreateHttp("http://api.imaginarium.getsett.net/error-reaper/report/dot-net");
            request.Method = "POST";
            request.ContentType = "application/json";
            using (var streamWriter = new System.IO.StreamWriter(request.GetRequestStream()))
            {
                var reportDto = context.Exception.ToDto();
                var reportJson =  new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(reportDto);
                streamWriter.Write(reportJson);
            }

            try
            {
                var httpResponse = (HttpWebResponse)request.GetResponse();
                using (var streamReader = new System.IO.StreamReader(httpResponse.GetResponseStream()))
                {
                    var responseText = streamReader.ReadToEnd();
                    //Now you have your response.
                    //or false depending on information in the response
                }
            }
            catch
            {

            }

            var response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
            response.Content = new StringContent(context.Exception.Message);
            context.Response = response;

            throw new System.Web.Http.HttpResponseException(response);
        }
    }
}