using Microsoft.AspNetCore.Mvc;
using JobTracker.Models;
using JobTracker.Services;

namespace JobTracker.Controllers;

[ApiController]
[Route("api/applications")]
public class ApplicationController : ControllerBase 
{
    private readonly IApplicationService _service;

    public ApplicationController(IApplicationService service)
    {
        _service = service;
    }

    [HttpGet]
    public ActionResult<IEnumerable<JobApplication>> GetAll()
    {
        return Ok(_service.GetAll());
    }

    [HttpGet("{id}")]
    public ActionResult<JobApplication> GetById(int id)
    {
        var application = _service.GetById(id);

        if (application == null)
        {
            return NotFound();
        }

        return Ok(application);
    }

    [HttpPost]
    public ActionResult<JobApplication> Create(JobApplication application)
    {
        if (string.IsNullOrWhiteSpace(application.Company) || string.IsNullOrWhiteSpace(application.Title))
        {
            return BadRequest("Company and Title are required.");
        }

        var created = _service.Create(application);

        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, JobApplication updated)
    {
        var existing = _service.GetById(id);

        if (existing == null)
        {
            return NotFound();
        }

        existing.Company = updated.Company;
        existing.Title = updated.Title;
        existing.Status = updated.Status;
        existing.AppliedDate = updated.AppliedDate;
        existing.Notes = updated.Notes;

        return Ok(existing);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var deleted = _service.Delete(id);

        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}