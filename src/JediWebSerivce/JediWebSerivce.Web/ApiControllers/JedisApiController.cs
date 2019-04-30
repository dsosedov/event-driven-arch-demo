using JediWebSerivce.Web.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace JediWebSerivce.Web.ApiControllers
{
    [Route("api/jedis")]
    [ApiController]
    public class JedisApiController : ControllerBase
    {
        readonly JediContext _context;

        public JedisApiController(JediContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task Post(Jedi jedi)
        {
            await _context.Jedis.AddAsync(jedi);
            await _context.SaveChangesAsync();
        }

        public Task<Jedi[]> Get()
        {
            return _context.Jedis.ToArrayAsync();
        }
    }
}
