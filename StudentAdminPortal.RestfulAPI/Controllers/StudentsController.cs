using System;
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
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _autoMapper;

        public StudentsController(IStudentRepository studentRepository,
                                  IMapper autoMapper)
        {
            _studentRepository = studentRepository;
            _autoMapper = autoMapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentDTO>>> RetrieveAllAsync()
        {
            var students = await _studentRepository.RetrieveAllAsync();
            return Ok(_autoMapper.Map<IEnumerable<StudentDTO>>(students));
        }  

        [HttpGet("{studentId:Guid}")]
        public async Task<ActionResult<StudentDTO>> RetrieveByIdAsync([FromRoute] Guid studentId)
        {
            var searchedStudent = await _studentRepository.RetrieveByIdAsync(studentId);
            return searchedStudent switch 
            {
                null => NotFound(),
                _ => Ok(_autoMapper.Map<StudentDTO>(searchedStudent))
            };
        }
    }
}
