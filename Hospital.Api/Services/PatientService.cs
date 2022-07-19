using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hospital.Api
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly ISiteRepository _siteRepository;
        private readonly IMapper _mapper;

        public PatientService(IPatientRepository patientRepository, IMapper mapper, ISiteRepository siteRepository)
        {
            _patientRepository = patientRepository;
            _siteRepository = siteRepository;
            _mapper = mapper;
        }
        /// <summary>
        /// Добавить нового пациента
        /// </summary>
        public async Task AddNew(PatientDto patientDto)
        {
            var newEntity = _mapper.Map<Patient>(patientDto);
            await _patientRepository.AddAsync(newEntity);
        }

        /// <summary>
        /// Удалить пациента
        /// </summary>
        public async Task<BaseResponse> Delete(long patientId)
        {
            var exist = await _patientRepository.FindAsync<Patient>(e => e.Id == patientId);
            if (exist == null)
                return new BaseResponse() { StatusCode = ResponseStatusCodes.NotFound, ErrorMessage = "Patient not found" };
            await _patientRepository.DeleteAsync(exist);
            return new BaseResponse();
        }
        /// <summary>
        /// Получить информацию о пациенте
        /// </summary>
        public async Task<BaseResponse<PatientEditModel>> GetPatientInfo(long patientId)
        {
            var exist = await _patientRepository.FindAsync<Patient>(e => e.Id == patientId);
            if (exist == null)
                return new BaseResponse<PatientEditModel>() { StatusCode = ResponseStatusCodes.NotFound, ErrorMessage = "Patient not found" };

            var model = _mapper.Map<PatientEditModel>(exist);
            return new BaseResponse<PatientEditModel>() { Data = model };
        }
        /// <summary>
        /// Обновить информацию о пациенте
        /// </summary>
        public async Task<BaseResponse<PatientEditModel>> UpdatePatient(PatientEditModel model)
        {
            var entity = _mapper.Map<Patient>(model);
            var site = await _siteRepository.FindAsync<Site>(e => e.Id == model.SiteId);
            entity.Site = site;
            await _patientRepository.UpdateAsync(entity);
            return new BaseResponse<PatientEditModel>() { Data = _mapper.Map<PatientEditModel>(entity) };
        }
        /// <summary>
        /// Получить список пациентов
        /// </summary>
        public async Task<BaseResponse<List<PatientViewModel>>> GetPatients(PatientFilterDto filterDto)
        {
            var page = (filterDto.Page - 1) * filterDto.Take;
            var patients = await _patientRepository.GetAsync<Patient>(e => true, page, filterDto.Take, filterDto.OrderField, filterDto.SortDirect, new string[] { nameof(Site) });
            var result = _mapper.Map<List<PatientViewModel>>(patients);
            return new BaseResponse<List<PatientViewModel>>() { Data = result };
        }
    }
}
