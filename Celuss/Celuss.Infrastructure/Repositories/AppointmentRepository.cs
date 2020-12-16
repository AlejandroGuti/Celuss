using Celuss.Infrastructure.Contexts;
using Celuss.Infrastructure.Entities;
using Celuss.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Celuss.Infrastructure.Repositories
{
    public class AppointmentRepository: IAppointmentRepository
    {
        private readonly DataContext _context;

        public AppointmentRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<int> Create(Appointment data, int IPSId, int CustId, int DoctId)
        {
            data.Customer = await _context.Customers.FindAsync(CustId);
            data.Doctor = await _context.Doctors.FindAsync(DoctId);
            data.IPS = await _context.IPSs.FindAsync(IPSId);
            _context.Appointments.Add(data);
            await _context.SaveChangesAsync();
            return data.Id;
        }

        public async Task<int> Delete(int id)
        {
            Appointment data = await _context.Appointments.FindAsync(id);
            if (data == null)
            {
                return 0;
            }

            _context.Appointments.Remove(data);
            await _context.SaveChangesAsync();
            return 1;
        }

        public async Task<ICollection<Appointment>> FindAll()
        {
            return await _context.Appointments.ToListAsync();
        }
        public async Task<ICollection<Appointment>> FindAllPIPS(int IPSIs)
        {
            return await _context.Appointments.Where(p => p.IPS.Id == IPSIs).ToListAsync();
        }

        public async Task<Appointment> FindById(int id)
        {
            Appointment data = await _context.Appointments.FindAsync(id);

            return data;
        }

        public async Task<int> Update(Appointment data, int IPSId, int CustId, int DoctId)
        {
            data.Customer = await _context.Customers.FindAsync(CustId);
            data.Doctor = await _context.Doctors.FindAsync(DoctId);
            data.IPS = await _context.IPSs.FindAsync(IPSId);
            _context.Appointments.Update(data);
            await _context.SaveChangesAsync();
            return 1;
        }
    }
}
