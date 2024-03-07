

using StudentManagement.Models;

namespace StudentManagement.Services
{
    public interface IStudentServices
    {
        List<StudentMangement> Get();

        StudentMangement Get(string id);

        StudentMangement Create(StudentMangement student);

        void Update(string id,StudentMangement student);
         
        void Remove(string id);
    } 
}
