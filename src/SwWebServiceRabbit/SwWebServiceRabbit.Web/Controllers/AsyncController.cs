using Newtonsoft.Json;
using SwWebServiceRabbit.Web.Data;
using SwWebServiceRabbit.Web.Models;
using System.Threading.Tasks;

namespace SwWebServiceRabbit.Web.Controllers
{
    public class AsyncController : BaseController
    {
        protected override string Title => "Async";

        public AsyncController(ToonContext context)
            : base(context)
        {
        }

        protected override async Task ChildIndex(ToonViewModel model)
        {
            QueueConnector.Instance.Publish(JsonConvert.SerializeObject(model));
        }
    }
}