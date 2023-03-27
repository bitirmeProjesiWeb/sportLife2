using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using sportLife2.DbModel;
using sportLife2.DTOs;
using sportLife2.Repositories.Interface;

namespace sportLife2.Controllers
{
    [Route("api/[controller]")]
   
    public class PitchController : Controller
    {
        private readonly IPitchRepository _pitchRepository;
        private readonly IMapper _mapper;

        public PitchController(IPitchRepository pitchRepository, IMapper mapper)
        {
            _pitchRepository = pitchRepository;
            _mapper = mapper;
        }

        [HttpGet("GetAdminId/{AdminId}")]
        public IActionResult GetAdminId(int AdminId)
        {
            var pitch = _pitchRepository.GetAdminId(AdminId);
            if (pitch == null)
            {
                return NotFound("Böyle bir veri yok.");
            }
            var pitchCreateDTO = _mapper.Map<PitchCreateDTO>(pitch);
            return Ok(pitchCreateDTO);
        }

        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var pitch = _pitchRepository.GetById(id);
            if (pitch == null)
            {
                return NotFound("Böyle bir veri yok.");
            }
            var pitchCreateDTO = _mapper.Map<PitchCreateDTO>(pitch);
            return Ok(pitchCreateDTO);
        }

        [HttpPut("Edit")]
        public IActionResult Edit([FromBody] PitchUpdateDTO pitchUpdate)
        {
            var data = _mapper.Map<Pitch>(pitchUpdate);
            if (_pitchRepository.Update(data))
            {
                var dto = _mapper.Map<PitchUpdateDTO>(data);
                return Ok("Başarılı");
            }
            else
            {
                return BadRequest("Başarısız");
            }
        }


        [HttpPost("Create")]
        public IActionResult Create([FromBody] PitchCreateDTO pitchCreate)
        {
            var data = _mapper.Map<Pitch>(pitchCreate);

            if (_pitchRepository.Create(data))
            {
                var dto = _mapper.Map<PitchCreateDTO>(data);
                return Ok("Başarılı");
            }
            else
            {
                return BadRequest("Başarısız");
            }
        }

        [HttpPost("TypePitch")]
        public async Task<IActionResult> TypePitch([FromBody] GetTypeRequest request)
        {
          var response= await _pitchRepository.GetType(request);
           
            return Ok(response);
        }

    }
}
