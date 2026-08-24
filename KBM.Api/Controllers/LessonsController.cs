using KBM.Application.DTOs;
using KBM.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace KBM.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class LessonsController : ControllerBase
{
    private readonly LessonService _lessonService;

    public LessonsController(LessonService lessonService)
    {
        _lessonService = lessonService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<LessonDto>>> GetAll()
    {
        var lessons = await _lessonService.GetAllAsync();

        return Ok(lessons);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<LessonDto>> GetById(Guid id)
    {
        var lesson = await _lessonService.GetByIdAsync(id);

        if (lesson is null)
            return NotFound();

        return Ok(lesson);
    }

    [HttpPost]
    public async Task<ActionResult<LessonDto>> Create(LessonDto dto)
    {
        var lesson = await _lessonService.CreateAsync(dto);

        return CreatedAtAction(
            nameof(GetById),
            new { id = lesson.Id },
            lesson);
    }
}
