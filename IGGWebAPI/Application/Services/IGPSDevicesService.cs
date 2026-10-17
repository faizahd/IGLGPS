namespace IGGWebAPI.Application.Services
{
    using global::IGGWebAPI.Application.DTOs;
    using IGGWebAPI.Application.DTOs;


    public interface IGPSDeviceService
    {
        Task<IEnumerable<GPSDeviceDto>> GetAllAsync(
           CancellationToken cancellationToken);

        Task<GPSDeviceDto?> GetByIdAsync(
            int id, CancellationToken cancellationToken);

        Task<int> CreateAsync(
            CreateGPSDeviceDto dto, CancellationToken cancellationToken);

        Task<bool> UpdateAsync(
            int id, UpdateGPSDeviceDto dto,
            CancellationToken cancellationToken);

        Task<bool> DeleteAsync(
            int id, CancellationToken cancellationToken);
    }
}
