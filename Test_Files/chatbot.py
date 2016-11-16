#!/usr/bin/env python
#pip install cleverbot SpeechRecognition pyserial pyttsx


import speech_recognition as sr
from cleverbot import Cleverbot
import pyttsx
import urllib2
import serial
import time,subprocess,json
import random
from multiprocessing import Process
from multiprocessing import Pipe


class Chatbot(object):

    port = '/dev/ttyACM1'

    ##########################################################################
    def __init__(self):
        self.cb = Cleverbot()
        self.r = sr.Recognizer()
        self.ard = serial.Serial(self.port, 9600, timeout=5)
        self.pyttsx_engine = pyttsx.init()
    ##########################################################################
    @property
    def get_input(self):
        #Get audio input from user

        with sr.Microphone() as source:
            print("Say something!")
            audio = self.r.listen(source)

        # Speech recognition using Google Speech Recognition
        try:
            question=""
            #for testing purposes, we're just using the default API key
            #to use another API key, use `r.recognize_google(audio, key="GOOGLE_SPEECH_RECOGNITION_API_KEY")`
            #instead of `r.recognize_google(audio)`
            question = self.r.recognize_google(audio)
            print("You said: " + question)
        except (sr.UnknownValueError,sr.RequestError) as e:
            question="Hello"
            print("Google Speech Recognition encountered an error: {0}".format(e))

        return question

    ##########################################################################
    def query_cleverbot(self,question):
        #Query Cleverbot with user input

        print("Calling Cleverbot!")

        try:
            answer=self.cb.ask(question)
            print("Cleverbot said: {}".format(answer))
            #For *nix systems.
            #subprocess.call(["espeak", answer])

            self.pyttsx_engine.say(answer)
            self.pyttsx_engine.runAndWait()

        except:
            print("Error!")
            answer="Can you repeat that?"

    ##########################################################################
    def query_watson(self,conn,question):
        # Call watson to analysis the mood of input

        print("Calling Watson!")

        data = str(question)
        url = 'https://watson-api-explorer.mybluemix.net/tone-analyzer/api/v3/tone?version=2016-05-19'
        response=""

        try:
            req = urllib2.Request(url, data, {'Content-Type': 'text/plain'})
            f = urllib2.urlopen(req)
            for line in f:
                response = response + line
            f.close()

            response = json.loads(response)

        except IOError:
            print("Failed to open {0}.".format(url))
        except ValueError:
            print("Could not decode JSON!")


        watson_mood_values = {}
        moods = ("Anger", "Disgust", "Fear", "Joy", "Sadness")

        #if response from watson, choose the mood with the highest score
        #else pick a random mood to return

        if response:
            for elem in response['document_tone']['tone_categories'][0]['tones']:
                #print elem['tone_name']
                watson_mood_values[elem['tone_name']] = elem['score']
                #print elem['score']

            maximum = max(watson_mood_values, key=watson_mood_values.get)
            #print(maximum, mood_values[maximum])
            #return maximum
        else:
            maximum = random.choice(moods)

        #return result to parent
        conn.send(maximum)
        conn.close()

    ##########################################################################
    def send_to_arduino(self,input_mood):
        try:
            self.ard.flush
            #convert from unicode
            input_mood = str(input_mood)
            print ("Python value sent: {0}".format(input_mood))
            #currently writes a string to Serial on Arduino
            #this can be changed
            self.ard.write(input_mood)
            self.ard.flush
        except:
            print("Failed to write to Arduino!")

        time.sleep(1)

##############################################################################
if __name__ == '__main__':

    chat = Chatbot()

    #wait for Arduino
    time.sleep(2)

    while(1):

        #use Google Speech Recongiziton to get user input
        question = chat.get_input

        #send user input to both Cleverbot API and Watson Tone Analyzer API
        #mutiple Procs to ensure Parallelism
        parent_conn,child_conn = Pipe()
        p1 = Process(target=chat.query_cleverbot,args=(question,))
        p1.start()
        p2 = Process(target=chat.query_watson,args=(child_conn,question,))
        p2.start()
        input_mood=parent_conn.recv()
        p1.join()
        p2.join()

        #send string to arduino for apporiate motor response.
        chat.send_to_arduino(input_mood)
