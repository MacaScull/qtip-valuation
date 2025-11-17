using Microsoft.AspNetCore.Mvc;
using ApiService.Application.Interfaces;
using ApiService.Application.DTO;

namespace ApiService.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SubmissionsController : ControllerBase
{
    private readonly ISubmissionService _submissionService;

    public SubmissionsController(ISubmissionService submissionService)
    {
        _submissionService = submissionService;
    }

    // GET: api/Submissions/count
    [HttpGet("count")]
    public async Task<IActionResult> CountClassifications()
    {
        try
        {
            return Ok(await _submissionService.CountSubmissionClassicationsAsync());
        }
        catch (Exception ex)
        {
            // Log the exception
            return BadRequest(new { error = ex.Message });
        }
    }

    // POST: api/Submissions/create
    [HttpPost("create")]
    public async Task<IActionResult> CreateSubmission([FromBody] CreateSubmissionsRequest request)
    {
        try
        {
            var Submission = await _submissionService.CreateSubmissionAsync(request.textSubmission);
            return Ok(Submission);
        }
        catch (Exception ex)
        {
            // Log the exception
            return BadRequest(new { error = ex.Message });
        }
    }
}
