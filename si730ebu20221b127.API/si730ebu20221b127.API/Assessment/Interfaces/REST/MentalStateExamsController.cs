using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using si730ebu20221b127.API.Assessment.Domain.Model.Queries;
using si730ebu20221b127.API.Assessment.Domain.Services;
using si730ebu20221b127.API.Assessment.Interfaces.REST.Resources;
using si730ebu20221b127.API.Assessment.Interfaces.REST.Transform;

namespace si730ebu20221b127.API.Assessment.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class MentalStateExamsController(IMentalStateExamCommandService mentalStateExamCommandService, IMentalStateExamQueryService mentalStateExamQueryService)
    : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateMentalStateExam([FromBody] CreateMentalStateExamResource resource)
    {
        var createMentalStateExamCommand =
            CreateMentalStateExamCommandFromResourceAssembler.ToCommandFromResource(resource);
        var mentalStateExam = await mentalStateExamCommandService.Handle(createMentalStateExamCommand);
        if (mentalStateExam is null) return BadRequest();
        var mentalStateExamResource = MentalStateExamResourceFromEntityAssembler.ToResourceFromEntity(mentalStateExam);
        return CreatedAtAction(nameof(GetMentalStateExamById), new { id = mentalStateExam.Id },
            mentalStateExamResource);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetMentalStateExamById(int id)
    {
        var getMentalStateExamByIdQuery = new GetMentalStateExamByIdQuery(id);
        var mentalStateExam = await mentalStateExamQueryService.Handle(getMentalStateExamByIdQuery);
        if (mentalStateExam is null) return NotFound();
        var mentalStateExamResource = MentalStateExamResourceFromEntityAssembler.ToResourceFromEntity(mentalStateExam);
        return Ok(mentalStateExamResource);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllMentalStateExams()
    {
        var getAllMentalStateExamsQuery = new GetAllMentalStateExamsQuery();
        var mentalStateExams = await mentalStateExamQueryService.Handle(getAllMentalStateExamsQuery);
        var mentalStateExamResources = mentalStateExams.Select(MentalStateExamResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(mentalStateExamResources);
    }
    
}