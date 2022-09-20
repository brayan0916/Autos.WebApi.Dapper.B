using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutosWebApiDapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutosController : ControllerBase
    {
        private readonly AutosDBContext _context;

        public AutosController(AutosDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listAutos= await _context.autosCar.ToListAsync();
                return Ok(listAutos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetId(int id)
        {
            try
            {
                var Autos = await _context.autosCar.FindAsync(id);

                if(Autos == null)
                {
                    return NotFound();
                }
                return Ok(Autos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Guardar(AutosEntity Autos)
        {
            try
            {
                Autos.Date = DateTime.Now;
                _context.Add(Autos);
                await _context.SaveChangesAsync();
                return CreatedAtAction("Get", new { id = Autos.Id }, Autos); ;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }

   
}
