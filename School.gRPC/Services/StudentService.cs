using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using School.gRPC.Protos;
using School.WebAPI.Data;
using School.WebAPI.Logic;
using School.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static School.gRPC.Protos.Student;

namespace School.gRPC.Services
{
    public class StudentService : StudentBase
    {
        private StudentLogic _logic = new StudentLogic(new EFGenericRepository<StudentPoco>());
        public override Task<StudentReply> GetStudent(StudentIDRequest request, ServerCallContext context)
        {
            StudentPoco studentPoco = _logic.GetSingle(request.StudentID);
            StudentReply studentReply = new StudentReply()
            {
                StudentID = studentPoco.StudentID,
                Name = studentPoco.Name

            };

            return Task.FromResult(studentReply);
        }
        public override Task<Empty> AddStudent(StudentReply request, ServerCallContext context)
        {
            StudentPoco studentPoco = new StudentPoco()
            {
                StudentID = request.StudentID,
                Name = request.Name
            };
            _logic.Add(studentPoco);

            return Task.FromResult(new Empty());
        }

        public override Task<Empty> DeleteStudent(StudentReply request, ServerCallContext context)
        {
            _logic.Remove(request.StudentID);

            return Task.FromResult(new Empty());
        }
    }
}

