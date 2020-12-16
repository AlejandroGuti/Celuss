using Celuss.Domain.DTOs;
using Celuss.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Celuss.Domain.Services.Interfaces
{
    public interface IDoctorService
    {
        Task<Response> Create(DoctorRequest model);
        Task<Response> Delete(int id);
        Task<Response> FindAll();
        Task<Response> FindById(int id);
        Task<Response> Update(int id, DoctorRequest request);
        Task<Response> FindAllPIPS(RequestId requestId);
    }
}
