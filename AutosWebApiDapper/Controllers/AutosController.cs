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
        private readonly IAutosRepository _autoRepository;
        private readonly IMapper _mapper;

        public AutosController( IAutosRepository autoRepository, IMapper mapper)
        {
            _autoRepository = autoRepository;
             _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listAutos= await _autoRepository.GetListAutos();
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
                var Autos = await _autoRepository.GetAutosId(id);

                if (Autos == null)
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
               
                await _autoRepository.AddAutos(Autos);
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
