using AutoMapper;
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
        private readonly IMapper _mapper;

        public AutosController(AutosDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listAutos= await _context.autosCar.ToListAsync();
                var listAutosDto = _mapper.Map<IEnumerable<AutosDto>>(listAutos);
                return Ok(listAutosDto);
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
                var autosDto = _mapper.Map<AutosDto>(Autos);
                return Ok(autosDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Guardar(AutosDto autosDto)
        {
            try
            {
                var Autos = _mapper.Map<AutosEntity>(autosDto);
                Autos.Date = DateTime.Now;
                _context.Add(Autos);
                await _context.SaveChangesAsync();
                var autosItemDto = _mapper.Map<AutosDto>(Autos);
                return CreatedAtAction("Get", new { id = Autos.Id }, Autos); ;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }

   
}
