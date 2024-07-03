using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using si730ebu20221b127.API.Personnel.Domain.Model.Queries;
using si730ebu20221b127.API.Personnel.Domain.Services;
using si730ebu20221b127.API.Personnel.Interfaces.REST.Resources;
using si730ebu20221b127.API.Personnel.Interfaces.REST.Transform;

namespace si730ebu20221b127.API.Personnel.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class ExaminersController(IExaminerCommandService examinerCommandService, IExaminerQueryService examinerQueryService)
    : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateExaminer([FromBody] CreateExaminerResource resource)
    {
        try
        {
            var createExaminerCommand = CreateExaminerCommandFromResourceAssembler.ToCommandFromResource(resource);
            var examiner = await examinerCommandService.Handle(createExaminerCommand);
            if (examiner is null) return BadRequest();
            var examinerResource = ExaminerResourceFromEntityAssembler.ToResourceFromEntity(examiner);
            return CreatedAtAction(nameof(GetExaminerById), new { id = examinerResource.Id }, examinerResource);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }


    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetExaminerById(int id)
    {
        var getExaminerByIdQuery = new GetExaminerByIdQuery(id);
        var examiner = await examinerQueryService.Handle(getExaminerByIdQuery);
        if (examiner == null) return NotFound("Examiner not found.");
        var examinerResource = ExaminerResourceFromEntityAssembler.ToResourceFromEntity(examiner);
        return Ok(examinerResource);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllExaminers()
    {
        var getAllExaminersQuery = new GetAllExaminersQuery();
        var examiners = await examinerQueryService.Handle(getAllExaminersQuery);
        var examinerResources = examiners.Select(ExaminerResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(examinerResources);
    }
    
}