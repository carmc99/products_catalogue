using Newtonsoft.Json;
using products_catalogue.Domain.ViewModels;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Results;

namespace products_catalogue.Application.Middleware
{
    public class InternalServerErrorTextPlainResult : StatusCodeResult
    {
        public string Content { get; set; }

        public InternalServerErrorTextPlainResult(HttpRequestMessage message) : base(HttpStatusCode.InternalServerError, message)
        {

        }

        public override async Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new StringContent(JsonConvert.SerializeObject((new ResponseViewModel<string>
                {
                    Metadata = new Domain.Models.Metadata
                    {
                        StatusCode = (int)HttpStatusCode.InternalServerError,
                    },
                    Payload = Content
                }))),
                RequestMessage = Request,
            };

            return response;
        }
    }
}