using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Api
{
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly PatientService _patientService;
        
        public PatientController(PatientService patientService)
        {
            _patientService = patientService;
        }

        /// <summary>
        /// Добавить нового пациента
        /// </summary>
        [HttpPost]
        [Route("api/patient/add")]
        public Task Add(PatientDto dto)
        {
            return _patientService.AddNew(dto);
        }

        /// <summary>
        /// Удалить пациента
        /// </summary>
        [HttpGet]
        [Route("api/patient/delete")]
        public Task<BaseResponse> Delete(long patientId)
        {
            return _patientService.Delete(patientId);
        }

        /// <summary>
        /// Получить информацию о пациенте
        /// </summary>
        [HttpGet]
        [Route("api/patient/getPatientInfo")]
        public Task<BaseResponse<PatientEditModel>> GetPatientInfo(long patientId)
        {
            return _patientService.GetPatientInfo(patientId);
        }

        /// <summary>
        /// Обновить информацию о пациенте
        /// </summary>
        [HttpPost]
        [Route("api/patient/update")]
        public Task<BaseResponse<PatientEditModel>> Update(PatientEditModel model)
        {
            return _patientService.UpdatePatient(model);
        }

        /// <summary>
        /// Получить список пациентов
        /// </summary>
        [HttpPost]
        [Route("api/patient/getPatients")]
        public Task<BaseResponse<List<PatientViewModel>>> GetPatients(PatientFilterDto filterDto)
        {
            return _patientService.GetPatients(filterDto);
        }
    }
}
