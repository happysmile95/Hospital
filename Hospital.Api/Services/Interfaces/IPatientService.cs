using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hospital.Api
{
    public interface IPatientService
    {
        /// <summary>
        /// Добавить нового пациента
        /// </summary>
        Task AddNew(PatientDto patientDto);
        /// <summary>
        /// Удалить пациента
        /// </summary>
        Task<BaseResponse> Delete(long patientId);
        /// <summary>
        /// Получить информацию о пациенте
        /// </summary>
        Task<BaseResponse<PatientEditModel>> GetPatientInfo(long patientId);
        /// <summary>
        /// Обновить информацию о пациенте
        /// </summary>
        Task<BaseResponse<PatientEditModel>> UpdatePatient(PatientEditModel model);
        /// <summary>
        /// Получить список пациентов
        /// </summary>
        Task<BaseResponse<List<PatientViewModel>>> GetPatients(PatientFilterDto filterDto);
    }
}