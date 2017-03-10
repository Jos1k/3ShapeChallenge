using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using DataAccess.Repositories;
using DataAccess.Models;
using System;
using DataAccess.Repositories.Common;
using _3ShapeChallenge.Models;
using AutoMapper;

namespace _3ShapeChallenge.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UsersController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        // GET api/users
        [HttpGet]
        public IEnumerable<_ShowUser> Get()
        {
            return _mapper.Map<IEnumerable<_ShowUser>>(_userRepository.GetAll());
        }

        // GET api/users/5
        [HttpGet]
        [Route("find")]
        public IActionResult Get([FromQuery]_GetByFilter filter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IEnumerable <User> users = _userRepository.GetBy(_mapper.Map<UserFilterModel>(filter));
            return Ok(_mapper.Map<IEnumerable<_ShowUser>>(users));
        }

        // POST api/users
        [HttpPost]
        public IActionResult Post([FromBody]_AddUser user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                User userResult = _userRepository.Create(_mapper.Map<User>(user));
                return Ok(_mapper.Map<_ShowUser>(userResult));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}
