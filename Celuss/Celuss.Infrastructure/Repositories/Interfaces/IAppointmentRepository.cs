using Celuss.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Celuss.Infrastructure.Repositories.Interfaces
{
    public interface IAppointmentRepository
    {
        Task<int> Create(Appointment data, int IPSId, int CustId, int DoctId);
        Task<int> Delete(int id);
        Task<ICollection<Appointment>> FindAll();
        Task<Appointment> FindById(int id);
        Task<int> Update(Appointment data, int IPSId, int CustId, int DoctId);
        Task<ICollection<Appointment>> FindAllPIPS(int IPSId);
    }
}
