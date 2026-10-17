namespace IGGWebAPI.Application.DTOs
{    
    public record GPSDeviceDto(
    int Id,
    string DeviceNumber,
    string DeviceName,
    string? Model,
    bool IsActive,
    DateTime CreatedAt);
}
public record CreateGPSDeviceDto(
    string DeviceNumber,
    string DeviceName,
    string? Model,
    bool IsActive = true);

public record UpdateGPSDeviceDto(
    string DeviceNumber,
    string DeviceName,
    string? Model,
    bool IsActive);