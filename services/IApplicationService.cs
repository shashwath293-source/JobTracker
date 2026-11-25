using JobTracker.Models;
namespace JobTracker.Services;

public interface IApplicationService
{
    List<JobApplication> GetAll();
    JobApplication? GetById(int id);
    JobApplication Create(JobApplication application);
    JobApplication? Update(int id, JobApplication updated);
    bool Delete(int id);
}