using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hospital.Api
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly ISiteRepository _siteRepository;
        private readonly ISpecializationRepository _specializationRepository;
        private readonly IParlorRepository _parlorRepository;
        private readonly IMapper _mapper;
        public DoctorService(IDoctorRepository doctorRepository, ISiteRepository siteRepository, ISpecializationRepository specializationRepository,
            IParlorRepository parlorRepository, IMapper mapper)
        {
            _doctorRepository = doctorRepository;
            _siteRepository = siteRepository;
            _specializationRepository = specializationRepository;
            _parlorRepository = parlorRepository;
            _mapper = mapper;
        }
        /// <summary>
        /// Добавить нового врача
        /// </summary>
        public async Task AddNew(DoctorDto doctorDto)
        {
            var newEntity = _mapper.Map<Doctor>(doctorDto);
            await _doctorRepository.AddAsync<Doctor>(newEntity);
        }
        /// <summary>
        /// Удалить врача
        /// </summary>
        public async Task<BaseResponse> Delete(long doctorId)
        {
            var exist = await _doctorRepository.FindAsync<Doctor>(e => e.Id == doctorId);
            if (exist == null)
                return new BaseResponse() { StatusCode = ResponseStatusCodes.NotFound, ErrorMessage = "Doctor not found" };
            await _doctorRepository.DeleteAsync<Doctor>(exist);
            return new BaseResponse();
        }
        /// <summary>
        /// Получить информацию о враче
        /// </summary>
        public async Task<BaseResponse<DoctorEditModel>> GetDoctorInfo(long doctorId)
        {
            var exist = await _doctorRepository.FindAsync<Doctor>(e => e.Id == doctorId);
            if (exist == null)
                return new BaseResponse<DoctorEditModel>() { StatusCode = ResponseStatusCodes.NotFound, ErrorMessage = "Doctor not found" };

            var model = _mapper.Map<DoctorEditModel>(exist);
            return new BaseResponse<DoctorEditModel>() { Data = model };
        }
        /// <summary>
        /// Обновить информацию о враче
        /// </summary>
        public async Task<BaseResponse<DoctorEditModel>> UpdateDoctor(DoctorEditModel model)
        {
            var entity = _mapper.Map<Doctor>(model);
            var site = await _siteRepository.FindAsync<Site>(e => e.Id == model.SiteId);
            var specialization = await _specializationRepository.FindAsync<Specialization>(e => e.Id == model.SpecializationId);
            var parlor = await _parlorRepository.FindAsync<Parlor>(e => e.Id == model.ParlorId);
            entity.Site = site;
            entity.Specialization = specialization;
            entity.Parlor = parlor;
            await _doctorRepository.UpdateAsync(entity);
            return new BaseResponse<DoctorEditModel>() { Data = _mapper.Map<DoctorEditModel>(entity) };
        }
        /// <summary>
        /// Получить список врачей
        /// </summary>
        public async Task<BaseResponse<List<DoctorViewModel>>> GetDoctors(DoctorsFilterDto filterDto)
        {
            var page = (filterDto.Page - 1) * filterDto.Take;
            var patients = await _doctorRepository.GetAsync<Doctor>(e => true, page, filterDto.Take, filterDto.OrderField, filterDto.SortDirect, new string[] { nameof(Site), nameof(Specialization), nameof(Parlor) });
            var result = _mapper.Map<List<DoctorViewModel>>(patients);
            return new BaseResponse<List<DoctorViewModel>>() { Data = result };
        }
    }
}
