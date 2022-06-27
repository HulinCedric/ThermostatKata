# Thermostat Kata

The following is a Kata, a coding exercise, to introduce Value Object concepts from Tactical Domain-Driven Design.

To understand what is a Value Object, you can read this [article](https://martinfowler.com/bliki/ValueObject.html) from Martin Fowler.

Try to ask you before (up front) and after (refactoring) your design decision phase:
- Where is the sweet spot for a behavior ?
- Who is responsible and guarantees rule validity ?

Keep in mind what an Object is.

## Approaches

To work on Value Object emergence, two kinds of approach is possible for this Kata
- From scratch approach
- Refactoring approach

In the From Scratch approach, just follow steps one by one, with your favorite design approach (with or without test).

---

(Soon)
In the Refactoring approach, a little messy solution is provided that does the work.
Just try to use refactoring technic in order to bring clearer intent of the source code.

Also, the latest step (the 8 one) needs to be implemented, you can try with and without refactoring, and learn what Value Object can help to achieve.

---

## Before you start

* Try not to read ahead.
* Do **one task at a time**. Try to work incrementally.

## The Kata

You work in a company that want to build and sell thermostat.
A thermostat senses temperature and performs actions in order to maintained temperature in a desired setpoint.

Your goal is to implement some parts of it.

Without worrying about the hardware layer, your main focus is the thermostat behaviors.

### Step 1: Thermostat

The thermostat when turned on, doesn't have a temperature to display, it just displays "Initialization".

### Step 2: Measurement

The company wants to sell thermostat for industries, sensor is extremely accurate.

To display a temperature, the thermostat requires some measurement.
A measurement is provided by the hardware layer in the [International System of Units](https://en.wikipedia.org/wiki/International_System_of_Units) for temperature, the [Kelvin](https://en.wikipedia.org/wiki/Kelvin) (K).

When a measurement is received, the thermostat displays it as it is.

For example, by default, the thermostat displays a measurement with a value of 20: "20 K".

### Step 3: Measurement accuracy

The accuracy of the sensor provides measurement with a lot of decimals.

To improve readability, Kelvin should always be displayed rounded, without decimals.

For example:
- A measurement of 214.87123002 should be displayed "215 K".
- A measurement of 100.131 should be displayed "100 K".
- A measurement of 23.55 should be displayed "24 K".

### Step 3: Temperature

The company wants to sell their nicely designed thermostats to European people for domestic purpose.

Customers should be able to see the temperature in [degree Celsius](https://en.wikipedia.org/wiki/Celsius) (°C).
For that, at initialization time, a button set the temperature display mode.

Always as before, for the previous model without display mode button, the Kelvin is selected by default.

The conversion can be calculated like that:
- x °C = x + 273.15 K

For example:
- 23 °C = 23 + 273.15 K
- 23 °C = 296.15 K

### Step 4: Temperature accuracy

The company forgot to say that degree Celsius should have a max precision of one decimal.
Also, trailing decimal zero should not be displayed.

- So, "23.0 °C" isn't valid, it should be displayed "23 °C".
- Also, "23.1 °C" is a valid temperature and should be displayed as it is.
- Lastly, "23.12223 °C" should be displayed "23.1 °C".

### Step 5: The sensor issue

The company is facing an issue, their accurate sensor is not so accurate and sometime provide negative measurement.
Kelvin cannot be negative, nothing can be colder than absolute zero.

In order not to provide impossible value to customers that can lead to big issues, the company plan to change the sensor.
But you need to manage old thermostat with buggy hardware, by software tricks.

A measurement cannot be negative and, you should rectify negative input.

For example, a "-1 K" measurement is equal to "0 K" measurement.

### Step 6: Hot, Cold & Perfect temperature

The thermostat provides information about how hot or cold is a temperature, in an absolute manner.
To simplify the usage of the thermostat, there is a preset determination of what is a temperature considered as cold, as hot, or perfect.

The preset value is different depending on the temperature unit:
- The preset for a perfect Kelvin temperature is 257.15 K.
- The preset for a perfect Celsius temperature is 20 °C.

Depending on the temperature value, the thermostat can display "Hot", "Cold" or "Perfect", in addition to the temperature.
For simplicity, you can display this information separately.

- If the temperature is equal to the preset, the temperature is considered as "Perfect".
- If greater, the temperature is considered as "Hot".
- If lower, the temperature is considered as "Cold".

### Step 7: Very Hot & Very Cold temperature

Because industry customers’ systems can manage high temperature variability, they should be able to have more regulation actions, in order to rectify a temperature quickly.
The thermostat should provide how very cold or very hot is a temperature.

Be careful, this feature is not managed by domestic customers' systems.
Only Kelvin temperature is targeted for this change.

- The preset for a very cold Kelvin temperature is 243.15 K.
- The preset for a very hot Kelvin temperature is 273.15.

Depending on the temperature value, the thermostat can display "Very Hot" or "Very Cold", in addition to all previous values.

### Step 8: Here we come, the USA!

Great news, the company will expand to the United States of America !
As you can imagine, for domestic usage, units of temperature is not in Celsius, but Fahrenheit (°F).

For new thermostats, a new button provides the capability to be turned on with a degree Fahrenheit display mode.

The conversion can be calculated like that:
- x °F = 5/9(x − 32) + 273.15 K

For example:
- 68 °C = 5/9(68 − 32) + 273.15 K
- 68 °C = 293.15 K

Fahrenheit temperature is considered as perfect at 68 °F.
For Fahrenheit, one decimal will suffice, as for Celsius.

For example:
- So, "98.0 °F" isn't valid, it should be displayed "98 °F".
- Also, "98.1 °F" is a valid temperature and should be displayed as it is.
- Lastly, "98.12223 °F" should be displayed "98.1 °F".

### Step 9: Desired customer temperature
//TODO write further step description