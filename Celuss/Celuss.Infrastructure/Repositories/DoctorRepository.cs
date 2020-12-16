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
    public class DoctorRepository: IDoctorRepository
    {
        private readonly DataContext _context;

        public DoctorRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<int> Create(Doctor data, int IPSId)
        {
            data.IPS = await _context.IPSs.FindAsync(IPSId);
            _context.Doctors.Add(data);
            await _context.SaveChangesAsync();
            return data.Id;
        }

        public async Task<int> Delete(int id)
        {
            Doctor data = await _context.Doctors.FindAsync(id);
            if (data == null)
            {
                return 0;
            }

            _context.Doctors.Remove(data);
            await _context.SaveChangesAsync();
            return 1;
        }

        public async Task<ICollection<Doctor>> FindAll()
        {
            return await _context.Doctors.ToListAsync();
        }
        public async Task<ICollection<Doctor>> FindAllPIPS(int IPSIs)
        {
            return await _context.Doctors.Where(p => p.IPS.Id == IPSIs).ToListAsync();
        }

        public async Task<Doctor> FindById(int id)
        {
            Doctor data = await _context.Doctors.FindAsync(id);

            return data;
        }

        public async Task<int> Update(Doctor data, int IPSId)
        {
            data.IPS= await _context.IPSs.FindAsync(IPSId);
            _context.Doctors.Update(data);
            await _context.SaveChangesAsync();
            return 1;
        }
    }
}
