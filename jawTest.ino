#include <Adafruit_MotorShield.h>

Adafruit_MotorShield AFMS = Adafruit_MotorShield();

Adafruit_DCMotor *jawMotor = AFMS.getMotor(1);

int jawPot = 0;
int maxJaw;
int minJaw;

void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);
  Serial.println("Creepy face control software");
  Serial.println("Calibrating potentiometers");
  AFMS.begin();
  jawMotor->setSpeed(255);
  jawMotor->run(FORWARD);
  delay(1000);
  maxJaw = analogRead(jawPot);
  Serial.println("Maximum jaw position: " + String(maxJaw));
  jawMotor->run(RELEASE);
  delay(100);
  jawMotor->run(BACKWARD);
  delay(1000);
  minJaw = analogRead(jawPot);
  Serial.println("Minimum jaw position: " + String(minJaw));
  jawMotor->run(RELEASE);
}

void loop() {
  // put your main code here, to run repeatedly:
  if (Serial.available() > 0)
  {
    Serial.println("Ready to accept input");
    int currentVal = analogRead(jawPot);
    int targetVal = Serial.readString().toInt();
    if (targetVal < currentVal)
    {
      jawMotor->setSpeed(255);
      jawMotor->run(BACKWARD);
      while (true)
      {
        currentVal = analogRead(jawPot);
        if (currentVal <= targetVal)
        {
          jawMotor->run(RELEASE);
          break;
        }
      }
    }
    else if(targetVal > currentVal)
    {
      jawMotor->setSpeed(255);
      jawMotor->run(FORWARD);
      while (true)
      {
        currentVal = analogRead(jawPot);
        if (currentVal >= targetVal)
        {
          jawMotor->run(RELEASE);
          break;
        }
      }
    }
  }
}
