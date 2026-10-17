namespace IGGWebAPI.Domain.Entities;

public class GPSDevice
{
    public int Id { get; set; }

    public string DeviceNumber { get; set; } = string.Empty;

    public string DeviceName { get; set; } = string.Empty;

    public string? Model { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }
}