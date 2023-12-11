using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TypeRaceAPI.Core.Interfaces;
using TypeRaceAPI.Core.Models;
using TypeRaceAPI.Service.IServices;

namespace TypeRaceAPI.Service.Services
{
    public class ProgressService : IProgressService
    {
        private IUnitOfWork unitOfWork;
        public ProgressService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public void DeleteProgress(Progress progress)
        {
            throw new NotImplementedException();
        }
        public Progress? GetProgress(int progress)
        {
            return unitOfWork.Progresses.Get(progress);
        }

        public IEnumerable<Progress?> GetProgresses(Expression<Func<Progress, bool>> predicate, string[]? inculde)
        {
            var result = unitOfWork.Progresses.FindAll(predicate, includes: inculde);
            return result;
        }

        public IEnumerable<Progress?> GetProgresses(Expression<Func<Progress, bool>>? predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Progress?> GetProgresses()
        {
            return unitOfWork.Progresses.GetAll();
        }

        public void InsertProgress(Progress progress)
        {
            unitOfWork.Progresses.Add(progress);
        }

        public void UpdateProgress(Progress progress)
        {
            throw new NotImplementedException();
        }
    }
}
