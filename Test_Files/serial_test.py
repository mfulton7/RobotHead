#!/usr/bin/env python

import serial
import time

port = '/dev/ttyACM1'

ard = serial.Serial(port,9600,timeout=5)
time.sleep(2) # wait for Arduino


moods=("Anger","Disgust","Fear","Joy","Sadness")
#main loop
while(1):
    input_mood=""
    while input_mood not in moods:
        print("Enter a valid mood: " + str(moods))
        print("Enter \'exit\' to quit")
        input_mood=raw_input("> ")
        if input_mood == "exit":
            print("Exiting")
            exit(0)
    
    #after user has entered valid mood
    #send to Arduino which will determine motor response

    ard.flush()
    print ("Python value sent: ")
    print (input_mood)
    ard.write(input_mood)
    ard.flush() 
    time.sleep(1) 


# Reading back from Arduino
#msg = ard.read(ard.inWaiting()) # read all characters in buffer
#print ("Message from arduino: ")
#print (msg)
