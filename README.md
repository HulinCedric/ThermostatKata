# Thermostat Kata

The following is a Kata, a coding exercise, to introduce Value Object concept from Tactical Domain-Driven Design.

To understand what is a Value Object, you can read this [article](https://martinfowler.com/bliki/ValueObject.html) from Martin Fowler.

Try to ask you before (up-front) and after (refactoring) your design decision phase: 
- Where is the sweet spot for a behavior ?
- Who is responsible and guarantee rule validity ?

Keep in mind what an Object is.

## Approaches

To work on Value Object emergence, two kinds of approach is possible for this Kata
- From scratch approach
- Refactoring approach

In the From Scratch approach, just follow steps one by one, with you favorite design approach (with or without test).

(Soon)
In the Refactoring approach, a little messy solution is provided that do the work. 
Just try to use refactoring technic in order to bring clearer intent of the source code.

Also, the latest Step need to be implemented, you can try with and without refactoring, and learn what Value Object can help to achieve.

## Before you start

* Try not to read ahead.
* Do **one task at a time**. Try to work incrementally.

## The Kata

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

### Step 3: Measurement precision

Accuracy of sensor provide measurement with a lot of decimal.

To improve readability, Kelvin should always be displayed rounded, without decimal.

For example, a measurement of 214.87123002 should be displayed "215 K".
Another example, a measurement of 100.131 should be displayed "100 K".
Finally, a measurement of 23.55 should be displayed "24 K".

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

### Step 4: Temperature precisions

We are missing to said that degree Celsius should have a max precision of 1 decimal.
Also, trailing decimal zero should not be display.

So, 23.0 °C isn't valid, it should be displayed 23 °C.
23.1 °C is a valid temperature and 23.12223 °C should be displayed 23.1 °C.

### Step 5: Not so good measurement
// TODO Rework description
We are facing an issue. 
Our accurate sensor are not so accurate and sometime provide negative measurement.

A Kelvin cannot be negative, nothing can be colder than absolute zero.

Some system connected to our thermostat, completely crash because of this.
We cannot replace physical sensor, we need to manage this with software.

A measurement cannot be negative, and should manage by correcting potential negative input.

For example, a "-1 K" measurement is equal to "0 K" measurement.

### Step 6: Hot & Cold

The thermostat provide information about how hot or cold is a temperature.
To simplify usage of thermostat, there is preset determination of what is a temperature considered as cold, as hot, or perfect.

The preset is different depending on the temperature unit.

The preset for perfect Kelvin temperature is 257.15 K.
The preset for perfect Celsius temperature is 20 °C.

Depending of the temperature value, the thermostat can display "Hot", "Cold", "Perfect".

If the temperature is equal to the preset, the temperature is considered as "Perfect"
If greater, the temperature is considered as "Hot".
If lower, the temperature is considered as "Cold".

### Step 7: Very Hot & Very Cold
// TODO Rework description
In industries, they require more information to trig different process depending on temperature coldest or hottest.

Depending of the temperature value, the thermostat can display "Very Hot" & "Very Cold"".

If the temperature is equal to the preset, the temperature is considered as "Perfect"
If greater, the temperature is considered as "Hot".
If lower, the temperature is considered as "Cold".

### Step 8: Here we come, US !

Great news, our company will expand to United States of America !
As you can imagine, for domestic usage, unit of temperature is not in Celsius degree, but Fahrenheit degree (°F).

For new Thermostat, a new button provide capability to turn on Thermostat with Fahrenheit display mode.

The conversion can be calculated like that:
x °F = 5/9(x − 32) + 273.15 K

For example:
68 °C = 5/9(68 − 32) + 273.15 K
68 °C = 293.15 K

A Fahrenheit temperature is considered as "perfect" at 68 °F.
For Fahrenheit, one decimal will suffice.

TODO Add Example