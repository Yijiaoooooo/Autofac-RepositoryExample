using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RepositoryExample.Models;

namespace RepositoryExample.Services
{
    public interface IGradeService

    {
        IQueryable<Grade> GetAllGrade();

        void Insert(Grade grade);

        void Update(Grade grade);

        void Delete(Grade grade);

        Grade GetById(int Id);
    }
}