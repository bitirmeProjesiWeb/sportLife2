using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using sportLife2.DbModel;
using sportLife2.DTOs;
using sportLife2.Repositories.Interface;
using sportLife2.Repositories;

namespace sportLife2.Controllers
{

    [Route("api/[controller]")]
    public class UserController:Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var User = _userRepository.GetAll();
            if (User == null)
            {
               
                return NotFound();
            }
            var UserDto = _mapper.Map<List<UserDTO>>(User.ToList());
           
            return Ok(UserDto);
        }

        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var user = _userRepository.GetById(id);
            if (user == null)
            {
                return NotFound("Böyle bir veri yok.");
            }
            var userDTO = _mapper.Map<UserDTO>(user);
            return Ok(userDTO);
        }

        [HttpPut("Edit")]
        public IActionResult Edit([FromBody] UserUpdateDTO userUpdate)
        {
            var data = _mapper.Map<UserEntity>(userUpdate);
            if (_userRepository.Update(data))
            {
                var dto = _mapper.Map<UserUpdateDTO>(data);
                return Ok("Başarılı");
            }
            else
            {
                return BadRequest("Başarısız");
            }
        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody] UserDTO user)
        {
            var data = _mapper.Map<UserEntity>(user);

            if (_userRepository.Create(data))
            {
                var dto = _mapper.Map<UserDTO>(data);
                return Ok("Başarılı");
            }
            else
            {
                return BadRequest("Bu Email adresi kayıtlıdır.");
            }
        }
        [HttpPost("TypeUser")]
        public async Task<IActionResult> TypeUser([FromBody] GetUserRequest request)
        {
            var response = await _userRepository.GetTypeUser(request);

            return Ok(response);
        }

    }
}
