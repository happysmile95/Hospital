using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Api.Controllers
{
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly DoctorService _doctorService;
        public DoctorController(DoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        /// <summary>
        /// Добавить нового врача
        /// </summary>
        [HttpPost]
        [Route("api/doctor/add")]
        public Task Add(DoctorDto dto)
        {
            return _doctorService.AddNew(dto);
        }

        /// <summary>
        /// Удалить врача
        /// </summary>
        [HttpGet]
        [Route("api/doctor/delete")]
        public Task<BaseResponse> Delete(long doctorId)
        {
            return _doctorService.Delete(doctorId);
        }

        /// <summary>
        /// Получить информацию о враче
        /// </summary>
        [HttpGet]
        [Route("api/doctor/getDoctorInfo")]
        public Task<BaseResponse<DoctorEditModel>> GetPatientInfo(long doctorId)
        {
            return _doctorService.GetDoctorInfo(doctorId);
        }

        /// <summary>
        /// Обновить информацию о враче
        /// </summary>
        [HttpPost]
        [Route("api/doctor/update")]
        public Task<BaseResponse<DoctorEditModel>> Update(DoctorEditModel model)
        {
            return _doctorService.UpdateDoctor(model);
        }

        /// <summary>
        /// Получить список врачей
        /// </summary>
        [HttpPost]
        [Route("api/doctor/getDoctors")]
        public Task<BaseResponse<List<DoctorViewModel>>> GetDoctors(DoctorsFilterDto filterDto)
        {
            return _doctorService.GetDoctors(filterDto);
        }
    }
}
