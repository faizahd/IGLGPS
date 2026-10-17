using System;
using System.Collections.Generic;

namespace IGGWebAPI.Domain.Entitiese;

public partial class GpsHistory
{
    public Guid EventId { get; set; }

    public string DeviceId { get; set; } = null!;

    public string? VehicleId { get; set; }

    public DateTime GpsTime { get; set; }

    public DateTime ReceivedTime { get; set; }

    public decimal Latitude { get; set; }

    public decimal Longitude { get; set; }

    public decimal? Speed { get; set; }

    public decimal? Direction { get; set; }

    public bool? Ignition { get; set; }

    public decimal? Odometer { get; set; }

    public string? EventType { get; set; }
}
