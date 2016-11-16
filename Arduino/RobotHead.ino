#include <Adafruit_MotorShield.h>

Adafruit_MotorShield AFMS = Adafruit_MotorShield();

Adafruit_DCMotor *jawMotor = AFMS.getMotor(1);
Adafruit_DCMotor *eyeHor = AFMS.getMotor(3);
Adafruit_DCMotor *eyeVert = AFMS.getMotor(2);
Adafruit_DCMotor *eyeLids = AFMS.getMotor(4);

const int jawPot = 0;
const int eyeHorPot = 1;
const int eyeVertPot = 2;

const int maxJaw = 700;
const int minJaw = 200;
const int maxEyeHor = 600;
const int minEyeHor = 300;
const int maxEyeVert = 700;
const int minEyeVert = 100;

byte incomingBytes[3] = {0, 0, 0};
int workingPart = 0;
int targetSpeed = 0;
int targetX = 0;
int targetY = 0;
int currentXVal = 0;
int currentYVal = 0;

void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);
  Serial.println("Creepy face control software");
  AFMS.begin();
  jawMotor->setSpeed(255);
  eyeHor->setSpeed(255);
  eyeVert->setSpeed(255);
  eyeLids->setSpeed(255);

  Serial.println("Testing motors!");

  //Open jaw
  jawMotor->run(FORWARD);

  //Eyes up and to right
  eyeHor->run(FORWARD);
  eyeVert->run(FORWARD);
  delay(1000);
  jawMotor->run(RELEASE);
  Serial.println(analogRead(jawPot));
  eyeHor->run(RELEASE);
  Serial.println(analogRead(eyeHorPot));
  eyeVert->run(RELEASE);
  Serial.println(analogRead(eyeVertPot));

  blinkEyes();

  //Close jaw
  jawMotor->run(BACKWARD);

  //Eyes down and to left
  eyeHor->run(BACKWARD);
  eyeVert->run(BACKWARD);
  delay(1000);
  jawMotor->run(RELEASE);
  Serial.println(analogRead(jawPot));
  eyeHor->run(RELEASE);
  Serial.println(analogRead(eyeHorPot));
  eyeVert->run(RELEASE);
  Serial.println(analogRead(eyeVertPot));

  //Align eyes center
}

void loop() {
  // put your main code here, to run repeatedly:
  if (Serial.available() > 0)
  {
    Serial.println(1);
    readCommand();
    switch(workingPart)
    {
      //Jaw
      case 0:
        moveJaw();
        Serial.println("Calling moveJaw");
        break;
      //Eyes
      case 1:
        moveEyes();
        Serial.println("Calling moveEyes");
        break;
      //Eyelids
      case 2:
        //Blink is the only thing we currently care to do with eyelids
        blinkEyes();
        Serial.println("Calling blinkEyes");
        break;
      default:
        Serial.println("Unrecognized command");
        break;
    }
  }
}

void readCommand()
{
  Serial.readBytes(incomingBytes, 4);
  workingPart = (int)incomingBytes[0];
  targetSpeed = (int)incomingBytes[1];
  //Use X value for standard linear movement 
  targetX = (int)incomingBytes[2];
  //Y value only relevant for eye movement
  targetY = (int)incomingBytes[3];
}

void blinkEyes()
{
  //blink
  eyeLids->run(FORWARD);
  delay(600);
  eyeLids->run(RELEASE);
  delay(10);
  eyeLids->run(BACKWARD);
  delay(600);
  eyeLids->run(RELEASE);
}

void moveJaw()
{
  targetX = (targetX * 5) + 200;
  
  if (targetX > maxJaw) { targetX = maxJaw; }
  if (targetX < minJaw) { targetX = minJaw; }
  currentXVal = analogRead(jawPot);
  
  jawMotor->setSpeed(targetSpeed);
  if (targetX < currentXVal)
  {
    jawMotor->run(BACKWARD);
    while (targetX <= currentXVal)
    {
      currentXVal = analogRead(jawPot);
      Serial.println(currentXVal);
    }
    jawMotor->run(RELEASE);
  }
  else if (targetX > currentXVal)
  {
    jawMotor->run(FORWARD);
    while (targetX >= currentXVal)
    {
      currentXVal = analogRead(jawPot);
      Serial.println(currentXVal);
    }
    jawMotor->run(RELEASE);
  }
  else
  {
    Serial.println("If not called");
  }
}

void moveEyes()
{
  bool xFor = false;
  bool yFor = false;
  bool xDone = false;
  bool yDone = false;

  targetX = (targetX * 3) + 300;
  targetY = (targetY * 6) + 100;
  
  if (targetX > maxEyeHor) { targetX = maxEyeHor; }
  if (targetX < minEyeHor) { targetX = minEyeHor; }
  if (targetY > maxEyeVert) { targetY = maxEyeVert; }
  if (targetY < minEyeVert) { targetY = minEyeVert; }

  eyeHor->setSpeed(targetSpeed);
  eyeVert->setSpeed(targetSpeed);
  
  currentXVal = analogRead(eyeHorPot);
  //get x motor moving
  if (targetX < currentXVal)
  {
    xFor = true;
    eyeHor->run(FORWARD);
  }
  else if (targetX > currentXVal)
  {
    xFor = false;
    eyeHor->run(BACKWARD);
  }

  currentYVal = analogRead(eyeVertPot);
  //get y motor moving
  if (targetY < currentYVal)
  {
    yFor = true;
    eyeVert->run(FORWARD);
  }
  else if (targetY > currentYVal)
  {
    yFor = false;
    eyeVert->run(BACKWARD);
  }

  //loop till they both are at there correct position
  while (!(xDone && yDone))
  {
    //Check horizontal motor
    currentXVal = analogRead(eyeHorPot);
    if (xFor)
    {
      if (targetX >= currentXVal)
      {
        xDone = true;
        eyeHor->run(RELEASE);
      }
    }
    else
    {
      if (targetX <= currentXVal)
      {
        xDone = true;
        eyeHor->run(RELEASE);
      }
    }
    //Check vertical motor
    currentYVal = analogRead(eyeVertPot);
    if (yFor)
    {
      if (targetY >= currentYVal)
      {
        yDone = true;
        eyeVert->run(RELEASE);
      }
    }
    else
    {
      if (targetY <= currentYVal)
      {
        yDone = true;
        eyeVert->run(RELEASE);
      }
    }
  }
  
}

