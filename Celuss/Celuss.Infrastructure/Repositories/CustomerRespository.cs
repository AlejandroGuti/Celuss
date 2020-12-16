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
    public class CustomerRespository: ICustomerRespository
    {
        private readonly DataContext _context;

        public CustomerRespository(DataContext context)
        {
            _context = context;
        }
        public async Task<int> Create(Customer data, int IPSId)
        {
            data.IPS = await _context.IPSs.FindAsync(IPSId);
            _context.Customers.Add(data);
            await _context.SaveChangesAsync();
            return data.Id;
        }

        public async Task<int> Delete(int id)
        {
            Customer data = await _context.Customers.FindAsync(id);
            if (data == null)
            {
                return 0;
            }

            _context.Customers.Remove(data);
            await _context.SaveChangesAsync();
            return 1;
        }

        public async Task<ICollection<Customer>> FindAll()
        {
            return await _context.Customers.ToListAsync();
        }
        public async Task<ICollection<Customer>> FindAllPIPS(int IPSIs)
        {
            return await _context.Customers.Where(p => p.IPS.Id == IPSIs).ToListAsync();
        }

        public async Task<Customer> FindById(int id)
        {
            Customer data = await _context.Customers.FindAsync(id);

            return data;
        }

        public async Task<int> Update(Customer data, int IPSId)
        {
            data.IPS = await _context.IPSs.FindAsync(IPSId);
            _context.Customers.Update(data);
            await _context.SaveChangesAsync();
            return 1;
        }
    }
}
