
using IGGWebAPI.Domain.Entities;
namespace IGGWebAPI.Application.Interfaces;

 
    public interface IGPSDeviceRepository
    {
        Task<IEnumerable<GPSDevice>> GetAllAsync(
            CancellationToken cancellationToken);

        Task<GPSDevice?> GetByIdAsync(
            int id,
            CancellationToken cancellationToken);

        Task<int> CreateAsync(
            GPSDevice device,
            CancellationToken cancellationToken);

        Task<bool> UpdateAsync(
            GPSDevice device,
            CancellationToken cancellationToken);

        Task<bool> DeleteAsync(
            int id,
            CancellationToken cancellationToken);
    }

