byte incomingBytes[3] = {0, 0, 0};
int working_Part = 0;
int target_Speed = 0;
int target_Position = 0;

void setup() 
{
  // put your setup code here, to run once:
  Serial.begin(9600);
}

void loop() 
{
  // put your main code here, to run repeatedly:
  if (Serial.available() > 0)
  {
    //Attempt to read in our command
    read_Command();
    switch(working_Part)
    {
      case 0:
        Serial.print("Move jaw to ");
        Serial.print(target_Position, DEC);
        Serial.print(" at speed: ");
        Serial.println(target_Speed, DEC);
        break;
      case 1:
        Serial.print("Move lip to ");
        Serial.print(target_Position, DEC);
        Serial.print(" at speed: ");
        Serial.println(target_Speed, DEC);
        break;
      case 2:
        Serial.print("Move eyes to ");
        Serial.print(target_Position, DEC);
        Serial.print(" at speed: ");
        Serial.println(target_Speed, DEC);
        break;
      case 3:
        Serial.print("Move eyebrows to ");
        Serial.print(target_Position, DEC);
        Serial.print(" at speed: ");
        Serial.println(target_Speed, DEC);
        break;
      default:
        Serial.println("Unrecognized command");
        break;
    }
  }
}

//Functions to catch and process our incoming bytes for our move commands
//May contain a lot of redundency but are mostly here to increase readability
void read_Command()
{
  Serial.readBytes(incomingBytes, 3);
  working_Part = incomingBytes[0];
  target_Speed = incomingBytes[1];
  target_Position = incomingBytes[2];
}

