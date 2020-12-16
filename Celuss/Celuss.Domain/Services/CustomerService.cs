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
    public class CustomerService: ICustomerService
    {
        private readonly ICustomerRespository _customerRespository;
        private readonly IMapper _mapper;

        public CustomerService
            (ICustomerRespository customerRespository,
            IMapper mapper)
        {
            _customerRespository = customerRespository;
            _mapper = mapper;
        }
        public async Task<Response> Create(CustomerRequest model)
        {

            Customer info = _mapper.Map<Customer>(model);
            int result = await _customerRespository.Create
                (info,
                model.IPSId);

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
            int result = await _customerRespository.Delete(id);

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
            ICollection<Customer> result = await _customerRespository.FindAll();

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
        public async Task<Response> FindAllPIPS(RequestId requestId)
        {
            ICollection<Customer> result = await _customerRespository.FindAllPIPS(requestId.Id);

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
            Customer result = await _customerRespository.FindById(id);

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
        public async Task<Response> Update(int id, CustomerRequest request)
        {
            Customer info = await _customerRespository.FindById(id);
            if (info == null)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = Messages.NotFound.ToString()
                };
            }
            info.CC = request.CC;
            info.Phone = request.Phone;
            info.Name = request.Name;
            info.LastName = request.LastName;
            int result = await _customerRespository.Update(info,
                request.IPSId);

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
