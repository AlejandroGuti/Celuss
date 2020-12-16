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
    public class AppointmentService: IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IMapper _mapper;

        public AppointmentService
            (IAppointmentRepository appointmentRepository,
            IMapper mapper)
        {
            _appointmentRepository = appointmentRepository;
            _mapper = mapper;
        }
        public async Task<Response> Create(AppointmentRequest model)
        {

            Appointment info = _mapper.Map<Appointment>(model);
            int result = await _appointmentRepository.Create
                (info,
                model.IPSId,
                model.CustomerId,
                model.DoctorId);

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
            int result = await _appointmentRepository.Delete(id);

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
            ICollection<Appointment> result = await _appointmentRepository.FindAll();

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
            ICollection<Appointment> result = await _appointmentRepository.FindAllPIPS(requestId.Id);

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
            Appointment result = await _appointmentRepository.FindById(id);

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
        public async Task<Response> Update(int id, AppointmentRequest request)
        {
            Appointment info = await _appointmentRepository.FindById(id);
            if (info == null)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = Messages.NotFound.ToString()
                };
            }
            info.Diagnostic = request.Diagnostic;
            info.Hour = request.Hour;
            int result = await _appointmentRepository.Update(info,
                request.IPSId,
                request.CustomerId,
                request.DoctorId); ;

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
