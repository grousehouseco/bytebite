namespace CoreLib.Models;

public class AppSettings
{
    public MeasurementSystem MassUnits { get; set; } = MeasurementSystem.Metric;
    public MeasurementSystem VolumeUnits { get; set; } = MeasurementSystem.Imperial;
    // notifications
    // privacy
}