// Example of sending and receiving data from Unity over Serial 9600 baud
// change the COM port in your unity script to match COM port assigned when you plug in your device...
//
// Buttons Pins: 12, 11 are setup as internal pullups
// Bounce Library used to trigger code only when the button is pressed and the pin voltage falls.
//
// Onboard LED light used for feedback.
#include <Keyboard.h>
#include <Bounce2.h>

#define LED 13
#define BUTTON1 12
#define BUTTON2 11
Bounce button1 = Bounce();
Bounce button2 = Bounce();


void setup() {
  Serial.begin(9600);
  pinMode(BUTTON1,INPUT_PULLUP);
  pinMode(BUTTON2,INPUT_PULLUP);
  pinMode(LED, OUTPUT);

  // Buttons with a 30 ms debounce
  button1.attach(BUTTON1);
  button1.interval(30);
  button2.attach(BUTTON2);
  button2.interval(30);

}

void loop() 
{
  button1.update();
  button2.update();

  if (Serial.available()) //serial data coming from UNITY
  { 
    int inByte = Serial.read();
    if(inByte == 'O')
    {
      //Serial.println("Arduino Recieved S"); //respond to Unity
      digitalWrite(LED, HIGH);  
    }
    if(inByte == '0')
    {
      //Serial.println("Arduino Received O"); //respond to Unity
      digitalWrite(LED, LOW);      
    }  
  }

//while (Serial.available() > 0) {
//    // When sending strings make sure not send any line ending characters
//    String incoming = Serial.readString();
////    Serial.print("Received: ");
////    Serial.println(incoming);
//
    if (incoming == "O") {
      // Turn button light on
      digitalWrite(LED, LOW);
    }
    if (incoming == "S1") {
      // Turn button light off
      digitalWrite(LED, HIGH);
    }
//
//  }

  // check if the buttons got pressed
  if(button1.fell()) {
//    Serial.println("1");
    Keyboard.write('S');
  }
  if(button2.fell()) {
//    Serial.println("2");
    Keyboard.write('O');
  } 
}
