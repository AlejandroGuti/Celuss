using Celuss.Infrastructure.Contexts;
using Celuss.Infrastructure.Entities;
using Celuss.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Celuss.Infrastructure.Repositories
{
    public class IPSRepository: IIPSRepository
    {
        private readonly DataContext _context;

        public IPSRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<int> Create(IPS data)
        {
            _context.IPSs.Add(data);
            await _context.SaveChangesAsync();
            return data.Id;
        }

        public async Task<int> Delete(int id)
        {
            IPS data = await _context.IPSs.FindAsync(id);
            if (data == null)
            {
                return 0;
            }
            _context.IPSs.Remove(data);
            await _context.SaveChangesAsync();
            return 1;
        }

        public async Task<ICollection<IPS>> FindAll()
        {
            return await _context.IPSs.ToListAsync();
        }

        public async Task<IPS> FindById(int id)
        {
            IPS data = await _context.IPSs.FindAsync(id);

            return data;
        }

        public async Task<int> Update(IPS data)
        {
            _context.IPSs.Update(data);
            await _context.SaveChangesAsync();
            return 1;
        }
    }
}
