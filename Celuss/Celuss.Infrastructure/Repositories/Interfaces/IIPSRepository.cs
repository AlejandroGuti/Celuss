using Celuss.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Celuss.Infrastructure.Repositories.Interfaces
{
    public interface IIPSRepository
    {
        Task<int> Create(IPS data);
        Task<int> Delete(int id);
        Task<ICollection<IPS>> FindAll();
        Task<IPS> FindById(int id);
        Task<int> Update(IPS data);
    }
}
