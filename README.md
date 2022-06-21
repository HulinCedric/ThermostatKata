# Thermostat Kata

The following is a small Kata, a coding exercise, to introduce Value Object concept from Tactical Domain-Driven Design.

## Before you start
* Try not to read ahead.
* Do **one task at a time**. Try to work incrementally.

## The kata

### Step 1: Thermostat

Your domain is to built some part of a thermostat.
Without carrying of hardware layer, your main focus is thermostat behavior.

The thermostat when turn on doesn't have temperature to display, it just display "Initialization".

### Step 2: Measurement

Company built accurate thermostat for industries, sensor are extremely accurate.

To display temperature, the thermostat require some measurement.
A measurement is provided by the hardware layer in the [International System of Units](https://en.wikipedia.org/wiki/International_System_of_Units) for temperature, the [Kelvin](https://en.wikipedia.org/wiki/Kelvin) (K).

When a measurement is received, the thermostat display it as it.

For example, by default, the thermostat display a measurement with a value of 20: "20 K".

### Step 3: Temperature

Company want to sell their nicely designed thermostat to european people for domestic purpose.

Customer require to see the temperature in [degree Celsius](https://en.wikipedia.org/wiki/Celsius) (°C).
For that, at initialization, a button set the temperature display mode.

Always as before, by default, when not set, the Kelvin is selected.

The conversion can be calculated like that:
x °C = x + 273.15 K

For example:
23 °C = 23 + 273.15 K
23 °C = 296.15 K

### Step 4: Hot & Cold

The thermostat provide information about how hot or cold is a temperature.
To simplify usage of thermostat, there is preset determination of what is a temperature considered as cold, as hot, or perfect.

The preset is different depending on the temperature unit.

The preset for perfect Kelvin temperature is 257.15 K.
The preset for perfect Celsius temperature is 20 °C.

Depending of the temperature value, the thermostat can display "Hot", "Cold", "Perfect".

If the temperature is equal to the preset, the temperature is considered as "Perfect"
If greater, the temperature is considered as "Hot".
If lower, the temperature is considered as "Cold".