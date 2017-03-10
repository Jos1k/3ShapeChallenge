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
        public IEnumerable<User> Get()
        {
            return _userRepository.GetAll();
        }

        // GET api/users/5
        [HttpGet]
        [Route("find")]
        public IEnumerable<User> Get([FromQuery] string id, [FromQuery] string email, [FromQuery] string toDate)
        {
            UserFilterModel filter = new UserFilterModel()
            {
                Id = id,
                Email = email,
                ToDate = toDate
            };

            return _userRepository.GetBy(filter);
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
                return Ok(_userRepository.Create(_mapper.Map<User>(user)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}
