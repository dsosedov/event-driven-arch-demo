using SithWebService.Web.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace SithWebService.Web.ApiControllers
{
    [Route("api/siths")]
    [ApiController]
    public class SithsApiController : ControllerBase
    {
        readonly SithContext _context;

        public SithsApiController(SithContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task Post(Sith sith)
        {
            await _context.Siths.AddAsync(sith);
            await _context.SaveChangesAsync();
        }

        public Task<Sith[]> Get()
        {
            return _context.Siths.ToArrayAsync();
        }
    }
}
