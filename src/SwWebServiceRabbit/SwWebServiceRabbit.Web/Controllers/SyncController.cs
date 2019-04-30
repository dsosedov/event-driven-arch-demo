using SwWebServiceRabbit.Web.Data;
using SwWebServiceRabbit.Web.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace SwWebServiceRabbit.Web.Controllers
{
    public class SyncController : BaseController
    {
        readonly HttpClient _client;

        protected override string Title => "Sync";

        public SyncController(ToonContext context)
            : base(context)
        {
            _client = new HttpClient();
        }

        protected override async Task ChildIndex(ToonViewModel model)
        {
            var url = string.Empty;

            switch (model.Order)
            {
                case Order.Jedi:
                    url = "http://localhost:51585/api/jedis";
                    break;
                case Order.Sith:
                    url = "http://localhost:51586/api/siths";
                    break;
            }

            var response = await _client.PostAsJsonAsync<IDictionary<string, string>>(url, new Dictionary<string, string> { { "name", model.Name } });

            if (!response.IsSuccessStatusCode)
            {
                
            }
        }
    }
}