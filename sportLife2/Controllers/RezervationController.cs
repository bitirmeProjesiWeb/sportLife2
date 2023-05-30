using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using sportLife2.DbModel;
using sportLife2.DTOs;
using sportLife2.Repositories;
using sportLife2.Repositories.Interface;

namespace sportLife2.Controllers
{
    [Route("api/[controller]")]


    public class RezervationController : Controller
    {
        private readonly IRezervationRepository _rezervationRepository;
        private readonly IMapper _mapper;


        public RezervationController(IRezervationRepository rezervationRepository, IMapper mapper)
        {
            _rezervationRepository = rezervationRepository;
            _mapper = mapper;
        }


        [HttpPost("Create")]
        public IActionResult Create([FromBody] RezervationCreateDTO rezervationCreate)
        {
            var data = _mapper.Map<Rezervation>(rezervationCreate);

            if (_rezervationRepository.Create(data))
            {
                var dto = _mapper.Map<RezervationCreateDTO>(data);
                return Ok("Başarılı");
            }
            else
            {
                return BadRequest("Başarısız");
            }
        }


        [HttpPost("GetDateRezervation")]
        public async Task<IActionResult> GetDateRezervation([FromBody] DateRezervationDTO request)
        {
            var response = await _rezervationRepository.GetDateRezervation(request);

            return Ok(response);
        }

        [HttpGet("GetUserId/{UserId}")]
        public IActionResult GetRezervationsByUserId(int UserId)
        {
            var rezervations = _rezervationRepository.GetRezervationsByUserId(UserId);
            if (rezervations == null)
            {
                return NotFound("Böyle bir veri yok.");
            }
            var rezervationListDTO = _mapper.Map<RezervationListDTO>(rezervations);
            return Ok(rezervationListDTO);
        }

        [HttpGet("GetPitchId/{PitchId}")]
        public IActionResult GetRezervationsPitchId(int PitchId)
        {
            var rezervations = _rezervationRepository.GetRezervationsByUserId(PitchId);
            if (rezervations == null)
            {
                return NotFound("Böyle bir veri yok.");
            }
            var rezervationListDTO = _mapper.Map<RezervationListDTO>(rezervations);
            return Ok(rezervationListDTO);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var data = _rezervationRepository.GetById(id);
            var dto = _mapper.Map<RezervationCreateDTO>(data);
            // data.IsDeleted = false; Soft Delete 
            if (data == null)
            {
                return NotFound("Böyle bir veri yok");
            }
            if (_rezervationRepository.Delete(id) == true)
            {
                return Ok("Silindi");
            }
            else
            {
                return BadRequest("Hatalı");
            }
        }


    }
}
