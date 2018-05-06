using Profile.Model.Models;
using System.Threading.Tasks;

namespace Profile.Service.Services.Interfaces
{
    public interface IMilitaryStatusResumeService
    {
        Task SaveMilitaryStatusAndUpdateResumeAsync(Resume resume, string militaryStatus);
    }
}
