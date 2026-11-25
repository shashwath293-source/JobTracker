using JobTracker.Models;

namespace JobTracker.Services;

public class ApplicationService : IApplicationService
{
    private readonly List<JobApplication> _applications = new()
    {
        new JobApplication { Id = 1, Company = "JPMorgan Chase", Title = ".NET Developer", Status = "Interview", AppliedDate = new DateOnly(2026, 11, 18) },
        new JobApplication { Id = 2, Company = "Parsec", Title = "Software Engineer II", Status = "Applied", AppliedDate = new DateOnly(2026, 11, 19) }
    };

    public List<JobApplication> GetAll()
    {
        return _applications;
    }

    public JobApplication? GetById(int id)
    {
        return _applications.FirstOrDefault(a => a.Id == id);
    }

    public JobApplication Create(JobApplication application)
    {
        application.Id = _applications.Count == 0 ? 1 : _applications.Max(a => a.Id) + 1;
        _applications.Add(application);
        return application;
    }

    public JobApplication? Update(int id, JobApplication updated)
    {
        var existing = GetById(id);
        if (existing == null) return null;

        existing.Company = updated.Company;
        existing.Title = updated.Title;
        existing.Status = updated.Status;
        existing.AppliedDate = updated.AppliedDate;
        existing.Notes = updated.Notes;
        return existing;
    }

    public bool Delete(int id)
    {
        var existing = GetById(id);
        if (existing == null) return false;

        _applications.Remove(existing);
        return true;
    }
}