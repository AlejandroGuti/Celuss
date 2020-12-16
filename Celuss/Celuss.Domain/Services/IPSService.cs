using AutoMapper;
using Celuss.Domain.DTOs;
using Celuss.Domain.Enum;
using Celuss.Domain.Responses;
using Celuss.Domain.Services.Interfaces;
using Celuss.Infrastructure.Entities;
using Celuss.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Celuss.Domain.Services
{
    public class IPSService : IIPSService
    {
        private readonly IIPSRepository _IPSRepository;
        private readonly IMapper _mapper;
        public IPSService(IIPSRepository IPSRepository, IMapper mapper)
        {
            _IPSRepository = IPSRepository;
            _mapper = mapper;

        }
        public async Task<Response> Create(IPSRequest model)
        {
            IPS info = _mapper.Map<IPS>(model);
            int result = await _IPSRepository.Create(info);
            if (result > 0)
            {
                return new Response
                {
                    IsSuccess = true,
                    Message = Messages.Created.ToString(),
                    Result = result
                };
            }
            else
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = Messages.NotCreated.ToString()
                };
            }
        }
        public async Task<Response> Delete(int id)
        {
            int result = await _IPSRepository.Delete(id);

            if (result > 0)
            {
                return new Response
                {
                    IsSuccess = true,
                    Message = Messages.Delete.ToString(),
                    Result = result

                };
            }

            else
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = Messages.NotDelete.ToString()
                };
            }
        }
        public async Task<Response> FindAll()
        {
            ICollection<IPS> result = await _IPSRepository.FindAll();

            if (result.Count > 0)
            {
                return new Response
                {
                    IsSuccess = true,
                    Message = Messages.Found.ToString(),
                    Result = result

                };
            }
            else
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = Messages.NotFound.ToString()
                };
            }
        }
        public async Task<Response> FindById(int id)
        {
            IPS result = await _IPSRepository.FindById(id);

            if (result != null)
            {
                return new Response
                {
                    IsSuccess = true,
                    Message = Messages.Found.ToString(),
                    Result = result

                };
            }
            else
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = Messages.NotFound.ToString()
                };
            }
        }
        public async Task<Response> Update(int id, IPSRequest request)
        {
            IPS iPS = await _IPSRepository.FindById(id);
            if (iPS == null)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = Messages.NotFound.ToString()
                };
            }
            iPS.Name = request.Name;
            iPS.NIT = request.NIT;
            int result = await _IPSRepository.Update(iPS);

            if (result > 0)
            {
                return new Response
                {
                    IsSuccess = true,
                    Message = Messages.Updated.ToString(),
                    Result = result

                };
            }
            else
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = Messages.NotUpdated.ToString()
                };
            }
        }
    }
}
