using Celuss.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Celuss.Infrastructure.Repositories.Interfaces
{
    public interface IDoctorRepository
    {
        Task<int> Create(Doctor data, int IPSId);
        Task<int> Delete(int id);
        Task<ICollection<Doctor>> FindAll();
        Task<Doctor> FindById(int id);
        Task<int> Update(Doctor data, int IPSId);
        Task<ICollection<Doctor>> FindAllPIPS(int IPSId);
    }
}
