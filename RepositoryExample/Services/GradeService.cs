using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RepositoryExample.Models;
using RepositoryExample.MyRepository;

namespace RepositoryExample.Services
{
    public class GradeService:IGradeService
    {
        private readonly IRepository<Grade> _gradeRepository;

        public GradeService(IRepository<Grade> gradeRepository)
        {
            _gradeRepository = gradeRepository;
        }

        public IQueryable<Grade> GetAllGrade()
        {
            return _gradeRepository.Table;
        }

        public void Insert(Grade grade)
        {
            _gradeRepository.Insert(grade);
        }

        public void Update(Grade grade)
        {
            _gradeRepository.Update(grade);
        }

        public void Delete(Grade grade)
        {
            _gradeRepository.Delete(grade);
        }

        public Grade GetById(int Id)
        {

          return   _gradeRepository.GetById(Id);
        }
    }
}