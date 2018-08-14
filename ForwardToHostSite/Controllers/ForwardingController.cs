using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ForwardToHost.Controllers
{
    public class ForwardingController : ApiController
    {

        static ForwardingController()
        {
            ServicePointManager
                .ServerCertificateValidationCallback +=
                (sender, cert, chain, sslPolicyErrors) => true;
        }

        static HttpClient forwardingClient = new HttpClient();
        

        [HttpGet]
        [HttpPost]
        [HttpDelete]
        [HttpHead]
        [HttpOptions]
        [HttpPatch]
        [HttpPut]
        public HttpResponseMessage Forward()
        {
            var hostName = ConfigurationManager.AppSettings["ForwardHost"];

            var uri = "https://"+ hostName + this.Request.RequestUri.PathAndQuery;
            var httpRequestMessage = new HttpRequestMessage(this.Request.Method, uri);
            foreach (var header in this.Request.Headers)
            {
                if (header.Key.Equals("Host", StringComparison.OrdinalIgnoreCase))
                {
                    httpRequestMessage.Headers.TryAddWithoutValidation(header.Key, hostName);
                }
                else
                {
                    httpRequestMessage.Headers.TryAddWithoutValidation(header.Key, header.Value);
                }
                
            }

            if (this.Request.Method != HttpMethod.Get)
            {

                httpRequestMessage.Content = new StringContent(this.Request.Content.ReadAsStringAsync().Result);

                foreach (var header in this.Request.Content.Headers)
                {

                    httpRequestMessage.Content.Headers.TryAddWithoutValidation(header.Key, header.Value);
                }
            }

            return forwardingClient.SendAsync(httpRequestMessage).Result;

        }




    }
}