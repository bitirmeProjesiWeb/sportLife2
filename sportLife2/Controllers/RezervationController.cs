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
