using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using School.WebAPI.Data;
using School.WebAPI.Models;

namespace School.WebAPI.Logic
{
    public class EnrollmentLogic
    {
        private EFGenericRepository<EnrollmentPoco> _eFGenericRepository;

        public EnrollmentLogic(EFGenericRepository<EnrollmentPoco> eFGenericRepository)
        {
            _eFGenericRepository = eFGenericRepository;
        }

        public IEnumerable<EnrollmentPoco> GetAll()
        {
            return _eFGenericRepository.GetAll();
        }


        public EnrollmentPoco GetSingle(int id)
        {
            return _eFGenericRepository.GetSingle(studentCourse => studentCourse.EnrollmentID == id);
        }


        public void Add(EnrollmentPoco studentCourse)
        {
            _eFGenericRepository.Add(studentCourse);
        }


        public void Remove(int id)
        {
            EnrollmentPoco studentCourse = _eFGenericRepository.GetSingle(studentCourse => studentCourse.EnrollmentID == id);
            _eFGenericRepository.Remove(studentCourse);
        }
    }
}
