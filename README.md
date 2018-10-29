# Unity Arduino Serial Communication
An example unity project that is setup to receive keyboard input
from an Arduino and output Serial via COM3 back to the Arduino.

A unity game object with the script `SerialArduino.cs` sets up the connection.
The same object also has a `KeyboardController.cs` script that reads keyboard input
and calls the SerialArduino.writeSerial() method. 

## Unity
Version 2017.3.0f3
### Keyboard Input Letters
O - Turns light on
S - Turns light off

### Serial out to Arduino
'O' - Turn LED on pin 13 on
'F' - Turn LED on pin 13 off

## Arduino
Version 1.8.4
Adafruit Itsybitsy (Leonardo)
Libraries Used:
Bounce2, Keyboard

###Pins:
Button1 - pin 12 (INPUT_PULLUP)
Button2 - pin 11 (INPUT_PULLUP)
LED - pin 13

