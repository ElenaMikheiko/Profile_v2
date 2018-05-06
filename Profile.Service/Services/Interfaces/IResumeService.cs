using Profile.Model.Models;

namespace Profile.Service.Services.Interfaces
{
    public interface IResumeService
    {
        void CreateResumeForStudent(int studentId);

        Resume GetResumeByStudentId(int studentId);

        Resume GetResumeById(int resumeId);

        void UpdateResume(Resume resume);
    }
}
