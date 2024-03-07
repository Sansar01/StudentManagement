using MongoDB.Driver;
using StudentManagement.Models;

namespace StudentManagement.Services
{
    public class StudentServices : IStudentServices
    {
        private readonly IMongoCollection<StudentMangement> _collection;
        public StudentServices(IStudentStoreDatabaseSettings setting,IMongoClient mongoClient) 
        {
         var database  = mongoClient.GetDatabase(setting.DatabaseName);
           _collection =  database.GetCollection<StudentMangement>(setting.StudentCoursesCollectionName);
        }

        public StudentMangement Create(StudentMangement student)
        {
            _collection.InsertOne(student);
            return student;
        }

        public List<StudentMangement> Get()
        {
            return _collection.Find(student => true).ToList();
        }

        public StudentMangement Get(string id)
        {
           return _collection.Find(student=>student.Id == id).FirstOrDefault();
        }

        public void Remove(string id)
        {
           _collection.DeleteOne(student=>student.Id == id);
        }

        public void Update(string id, StudentMangement student)
        {
            _collection.ReplaceOne(student => student.Id == id, student);
        }
    }
}
