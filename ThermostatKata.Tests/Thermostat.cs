public class Thermostat
{
    private readonly Temperature _perfectTemperature = new(257.15);
    private readonly TemperatureUnit _temperatureUnit;

    public Thermostat(TemperatureUnit temperatureUnit = TemperatureUnit.Kelvin)
    {
        _temperatureUnit = temperatureUnit;
        Display = "Initialization";
    }

    public string Display { get; private set; }

    public void ReceiveMeasurement(double measure)
    {
        var temperature = new Temperature(measure);

        Display = _temperatureUnit == TemperatureUnit.Degree
                      ? $"{temperature.GetDegreeValue()} °C"
                      : $"{temperature.GetKelvinValue()} K";
    }
}

public class Temperature
{
    private readonly double _kelvinTemperature;

    public Temperature(double measure)
        => _kelvinTemperature = measure;

    public double GetDegreeValue()
        => _kelvinTemperature - 273.15;

    public double GetKelvinValue()
        => _kelvinTemperature;
}

public enum TemperatureUnit
{
    Degree,
    Kelvin
}