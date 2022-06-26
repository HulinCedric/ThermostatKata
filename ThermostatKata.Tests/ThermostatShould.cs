using FluentAssertions;
using Xunit;

namespace ThermostatKata.Tests;

public class ThermostatShould
{
    [Fact]
    public void Foo()
    {
        var thermostat = new Thermostat(TemperatureUnit.Degree);

        thermostat.ReceiveMeasurement(257.15);

        thermostat.Display.Should().Be("-16 °C");
    }
}