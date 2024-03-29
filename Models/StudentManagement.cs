﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace StudentManagement.Models
{
    public class StudentMangement
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [BsonElement("name")]
        public string Name { get; set; } = string.Empty;

        [BsonElement("graduated")]
        public bool IsGraduated { get; set; }

        [BsonElement("courses")]
        public string[] Courses { get; set; }

        [BsonElement("gender")]
        public string Gender { get; set; }

        [BsonElement("age")]
        public int Age { get; set; }
    }
}
