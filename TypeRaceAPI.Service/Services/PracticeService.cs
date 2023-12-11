using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypeRaceAPI.Core.Interfaces;
using TypeRaceAPI.Core.Models;
using TypeRaceAPI.Service.IServices;

namespace TypeRaceAPI.Service.Services
{
    public class PracticeService : IPracticeService
    {
        private IUnitOfWork unitOfWork;
        public PracticeService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public void DeletePractice(Practice practice)
        {
            throw new NotImplementedException();
        }

        public Practice? GetPractice(int id)
        {
            return unitOfWork.Practices.Get(id);
        }

        public IEnumerable<Practice> GetPractices()
        {
            return unitOfWork.Practices.GetAll();
        }

        public void InsertPractice(Practice practice)
        {
            unitOfWork.Practices.Add(practice);
        }

        public void UpdatePractice(Practice practice)
        {
            throw new NotImplementedException();
        }
    }
}
