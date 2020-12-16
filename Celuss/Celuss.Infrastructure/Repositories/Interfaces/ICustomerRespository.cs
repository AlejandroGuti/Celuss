using Celuss.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Celuss.Infrastructure.Repositories.Interfaces
{
    public interface ICustomerRespository
    {
        Task<int> Create(Customer data, int IPSId);
        Task<int> Delete(int id);
        Task<ICollection<Customer>> FindAll();
        Task<Customer> FindById(int id);
        Task<int> Update(Customer data, int IPSId);
        Task<ICollection<Customer>> FindAllPIPS(int IPSId);
    }
}
