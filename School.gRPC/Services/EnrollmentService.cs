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
using static School.gRPC.Protos.Enrollment;

namespace School.gRPC.Services
{
    public class EnrollmentService : EnrollmentBase
    {
        private EnrollmentLogic _logic = new EnrollmentLogic(new EFGenericRepository<EnrollmentPoco>());
        public override Task<EnrollmentReply> GetEnrollment(EnrollmentIDRequest request, ServerCallContext context)
        {
            EnrollmentPoco EnrollmentPoco = _logic.GetSingle(request.EnrollmentID);
            EnrollmentReply EnrollmentReply = new EnrollmentReply()
            {
                EnrollmentID = EnrollmentPoco.EnrollmentID,
                StudentID = EnrollmentPoco.StudentID,
                CourseID = EnrollmentPoco.CourseID
            };

            return Task.FromResult(EnrollmentReply);
        }
        public override Task<Empty> AddEnrollment(EnrollmentReply request, ServerCallContext context)
        {
            EnrollmentPoco EnrollmentPoco = new EnrollmentPoco()
            {
                EnrollmentID = request.EnrollmentID,
                StudentID = request.StudentID,
                CourseID = request.CourseID
            };
            _logic.Add(EnrollmentPoco);

            return Task.FromResult(new Empty());
        }

        public override Task<Empty> DeleteEnrollment(EnrollmentReply request, ServerCallContext context)
        {
            _logic.Remove(request.EnrollmentID);

            return Task.FromResult(new Empty());
        }
    }
}

