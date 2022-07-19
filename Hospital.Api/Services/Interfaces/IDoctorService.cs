using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hospital.Api
{
    public interface IDoctorService
    {
        /// <summary>
        /// Добавить нового врача
        /// </summary>
        Task AddNew(DoctorDto doctorDto);
        /// <summary>
        /// Удалить врача
        /// </summary>
        Task<BaseResponse> Delete(long doctorId);
        /// <summary>
        /// Получить информацию о враче
        /// </summary>
        Task<BaseResponse<DoctorEditModel>> GetDoctorInfo(long doctorId);
        /// <summary>
        /// Обновить информацию о враче
        /// </summary>
        Task<BaseResponse<DoctorEditModel>> UpdateDoctor(DoctorEditModel model);
        /// <summary>
        /// Получить список врачей
        /// </summary>
        Task<BaseResponse<List<DoctorViewModel>>> GetDoctors(DoctorsFilterDto filterDto);
    }
}