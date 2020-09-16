using School.WebAPI.Data;
using School.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.WebAPI.Logic
{
    public class StudentLogic
    {
        private EFGenericRepository<StudentPoco> _eFGenericRepository;

        public StudentLogic(EFGenericRepository<StudentPoco> eFGenericRepository)
        {
            _eFGenericRepository = eFGenericRepository;
        }

        public IEnumerable<StudentPoco> GetAll()
        {
            return _eFGenericRepository.GetAll(s => s.Enrollments);
        }


        public StudentPoco GetSingle(int id)
        {
            return _eFGenericRepository
                    .GetSingle(student => student.StudentID == id,s => s.Enrollments);
                    
        }


        public void Add(StudentPoco student)
        {
            _eFGenericRepository.Add(student);
        }


        public void Remove(int id)
        {
            StudentPoco student = _eFGenericRepository.GetSingle(student => student.StudentID == id);
            _eFGenericRepository.Remove(student);
        }
    }
}
