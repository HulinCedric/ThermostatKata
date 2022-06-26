using System;
using FluentAssertions;
using FluentAssertions.Primitives;
using Xunit;

namespace ThermostatKata.Tests;

public class ThermostatShould
{
    [Fact]
    public void Display_Initialization_when_turn_on()
        => Thermostat.TurnOn().ShouldDisplay("Initialization");

    [Theory]
    [InlineData(20, "20 K")]
    [InlineData(214.87123002, "215 K")]
    [InlineData(100.131, "100 K")]
    [InlineData(23.55, "24 K")]
    public void Display_measurement_when_receiving_one(Measurement measurement, string expectedDisplay)
    {
        var thermostat = Thermostat.TurnOn();

        thermostat.Receive(measurement);

        thermostat.ShouldDisplay(expectedDisplay);
    }
}

public static class ThermostatTestExtension
{
    public static AndConstraint<StringAssertions> ShouldDisplay(this Thermostat thermostat, string expected)
        => thermostat.Display().Should().Be(expected);
}

public record Measurement(decimal Value)
{
    public override string ToString()
        => $"{Value:N0} K";

    public static implicit operator decimal(Measurement measurement)
        => measurement.Value;

    public static implicit operator Measurement(double doubleValue)
        => new(Convert.ToDecimal(doubleValue));

    public static implicit operator string(Measurement measurement)
        => measurement.ToString();
}

public class Thermostat
{
    private string display;

    private Thermostat()
        => display = "Initialization";

    public string Display()
        => display;

    public static Thermostat TurnOn()
        => new();

    public void Receive(Measurement measurement)
        => display = measurement;
}