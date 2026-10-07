using Microsoft.AspNetCore.Mvc;
using MyWebApp.Models;
using MyWebApp.Services;

namespace MyWebApp.Controllers
{
    [ApiController]
    [Route("api/subject")]
    public class SubjectMarkController : ControllerBase
    {
        private readonly SubjectMarkService subMarkService;

        public SubjectMarkController(SubjectMarkService _subMarkService)
        {
            subMarkService = _subMarkService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var all_marks = await subMarkService.GetAllSubjectMarks();
            return Ok(all_marks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var this_subject = await subMarkService.GetSubjectmarkbyId(id);
            if (this_subject == null)
                return NotFound("Not found");
            return Ok(this_subject);
        }

        [HttpPost]
    public async Task<IActionResult> Create([FromBody] SubjectMark subMark)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var createdMark = await subMarkService.AddSubjectMarkAsync(subMark);
        return Ok(createdMark);
    }

       
    }
}