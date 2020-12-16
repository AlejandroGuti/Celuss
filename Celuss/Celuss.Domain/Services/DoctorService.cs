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
    public class DoctorService: IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IMapper _mapper;

        public DoctorService
            (IDoctorRepository doctorRepository,
            IMapper mapper)
        {
            _doctorRepository = doctorRepository;
            _mapper = mapper;
        }
        public async Task<Response> Create(DoctorRequest model)
        {

            Doctor info = _mapper.Map<Doctor>(model);
            int result = await _doctorRepository.Create
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
            int result = await _doctorRepository.Delete(id);

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
            ICollection<Doctor> result = await _doctorRepository.FindAll();

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
            ICollection<Doctor> result = await _doctorRepository.FindAllPIPS(requestId.Id);

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
            Doctor result = await _doctorRepository.FindById(id);

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
        public async Task<Response> Update(int id, DoctorRequest request)
        {
            Doctor info = await _doctorRepository.FindById(id);
            if (info == null)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = Messages.NotFound.ToString()
                };
            }
            info.CC = request.CC;
            info.Code = request.Code;
            info.Name = request.Name;
            info.LastName = request.LastName;
            int result = await _doctorRepository.Update(info,
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
