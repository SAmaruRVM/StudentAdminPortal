using System.Collections.Generic;
using System.Threading.Tasks;

using AutoMapper;

using Microsoft.AspNetCore.Mvc;

using StudentAdminPortal.RestfulAPI.DTOs;
using StudentAdminPortal.RestfulAPI.Repositories;

namespace StudentAdminPortal.RestfulAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GendersController : ControllerBase
    {
        private readonly IGenderRepository _genderRepository;
        private readonly IMapper _autoMapper;

        public GendersController(IGenderRepository studentRepository,
                                  IMapper autoMapper)
        {
            _genderRepository = studentRepository;
            _autoMapper = autoMapper;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<GenderDTO>>> RetrieveAllGendersAsync()
            => Ok(_autoMapper.Map<IEnumerable<GenderDTO>>(await _genderRepository.RetrieveAllAsync()));
    }
}
