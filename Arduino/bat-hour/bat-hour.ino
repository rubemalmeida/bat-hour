#define c 261
#define d 294
#define e 329
#define f 349
#define g 391
#define gS 415
#define a 440
#define aS 455
#define b 466
#define cH 523
#define cSH 554
#define dH 587
#define dSH 622
#define eH 659
#define fH 698
#define fSH 740
#define gH 784
#define gSH 830
#define aH 880

const int delayTime = 65;

const int minRedPin = 3;
const int maxRedPin = 6;
const int minBluePin = 7;
const int maxBluePin = 10;

const int minPin = minRedPin;
const int maxPin = maxBluePin;

const int speakerPin =  13;

int eachTime = 0;
int i = 0;
int j = 0;

bool turnOn = false;
String serial = "";

int counterToPlay = 0;
int counterToClear = 0;
int maxToClear = 10;



void setup() {
  
  Serial.begin(9600);
  /*while (!Serial) {
    ; // wait for serial port to connect. Needed for native USB port only
  }*/

  pinMode(speakerPin, OUTPUT);
  for(i = minPin; i <= maxPin; i++){
    pinMode(i, OUTPUT);
  }
  
  eachTime = delayTime * 4 * 6;
  //establishContact();
}

void loop() {

  serial = Serial.readString();
  Serial.println(serial);
    
  //if (Serial.available() > 0){
    if(serial == "ON"){
      turnOn = true;
    }
    else if (serial == "OFF")
    {
      turnOn = false;
    }
  //}

  if(turnOn)
  {

    /*counterToClear = 0;
    int totalTime = counterToPlay * eachTime;
    if(totalTime >= 10000){
      march();
      counterToPlay = 0;
      return;
    }*/
    
    for (i = 1; i <= 3; i++){
      RedOn();
      delay(delayTime);
      RedOff();
      delay(delayTime);
    }
    
    for (i = 1; i <= 3; i++){
      BlueOn();
      delay(delayTime);
      BlueOff();
      delay(delayTime);
    }
    
    counterToPlay = counterToPlay + 1;
  }
  else{

    if(counterToClear >= maxToClear){
      counterToPlay = 0;
      return;
    }
    
    counterToClear = counterToClear + 1;
  }
  
}



void establishContact() {
  while (Serial.available() <= 0) {
    Serial.print('A');   // send a capital A
    delay(300);
  }
}

void RedOn(){
  for (j = minRedPin; j <= maxRedPin; j++){ 
    digitalWrite(j,HIGH);
  }
}

void RedOff(){
  for (j = minRedPin; j <= maxRedPin; j++){ 
    digitalWrite(j,LOW);
  }
}

void BlueOn(){
  for (j = minBluePin; j <= maxBluePin; j++){ 
    digitalWrite(j,HIGH);
  }
}

void BlueOff(){
  for (j = minBluePin; j <= maxBluePin; j++){ 
    digitalWrite(j,LOW);
  }
}

void beep (unsigned char speakerPin, int frequencyInHertz, long timeInMilliseconds)
{
    RedOn();
    BlueOn();
    //use led to visualize the notes being played
 
    int x;
    long delayAmount = (long)(1000000/frequencyInHertz);
    long loopTime = (long)((timeInMilliseconds*1000)/(delayAmount*2));
    for (x=0;x<loopTime;x++)
    {
        digitalWrite(speakerPin,HIGH);
        delayMicroseconds(delayAmount);
        digitalWrite(speakerPin,LOW);
        delayMicroseconds(delayAmount);
    }
 
    RedOff();
    BlueOff();
    //set led back to low
 
    delay(20);
    //a little delay to make all notes sound separate
}
 
void march()
{
    //for the sheet music see:
    //http://www.musicnotes.com/sheetmusic/mtd.asp?ppn=MN0016254
    //this is just a translation of said sheet music to frequencies / time in ms
    //used 500 ms for a quart note
 
    beep(speakerPin, a, 500);
    beep(speakerPin, a, 500);
    beep(speakerPin, a, 500);
    beep(speakerPin, f, 350);
    beep(speakerPin, cH, 150);
 
    beep(speakerPin, a, 500);
    beep(speakerPin, f, 350);
    beep(speakerPin, cH, 150);
    beep(speakerPin, a, 1000);
    //first bit
 
    beep(speakerPin, eH, 500);
    beep(speakerPin, eH, 500);
    beep(speakerPin, eH, 500);
    beep(speakerPin, fH, 350);
    beep(speakerPin, cH, 150);
 
    beep(speakerPin, gS, 500);
    beep(speakerPin, f, 350);
    beep(speakerPin, cH, 150);
    beep(speakerPin, a, 1000);
    //second bit...
 
    beep(speakerPin, aH, 500);
    beep(speakerPin, a, 350);
    beep(speakerPin, a, 150);
    beep(speakerPin, aH, 500);
    beep(speakerPin, gSH, 250);
    beep(speakerPin, gH, 250);
 
    beep(speakerPin, fSH, 125);
    beep(speakerPin, fH, 125);
    beep(speakerPin, fSH, 250);
    delay(250);
    beep(speakerPin, aS, 250);
    beep(speakerPin, dSH, 500);
    beep(speakerPin, dH, 250);
    beep(speakerPin, cSH, 250);
    //start of the interesting bit
 
    beep(speakerPin, cH, 125);
    beep(speakerPin, b, 125);
    beep(speakerPin, cH, 250);
    delay(250);
    beep(speakerPin, f, 125);
    beep(speakerPin, gS, 500);
    beep(speakerPin, f, 375);
    beep(speakerPin, a, 125);
 
    beep(speakerPin, cH, 500);
    beep(speakerPin, a, 375);
    beep(speakerPin, cH, 125);
    beep(speakerPin, eH, 1000);
    //more interesting stuff (this doesn't quite get it right somehow)
 
    beep(speakerPin, aH, 500);
    beep(speakerPin, a, 350);
    beep(speakerPin, a, 150);
    beep(speakerPin, aH, 500);
    beep(speakerPin, gSH, 250);
    beep(speakerPin, gH, 250);
 
    beep(speakerPin, fSH, 125);
    beep(speakerPin, fH, 125);
    beep(speakerPin, fSH, 250);
    delay(250);
    beep(speakerPin, aS, 250);
    beep(speakerPin, dSH, 500);
    beep(speakerPin, dH, 250);
    beep(speakerPin, cSH, 250);
    //repeat... repeat
 
    beep(speakerPin, cH, 125);
    beep(speakerPin, b, 125);
    beep(speakerPin, cH, 250);
    delay(250);
    beep(speakerPin, f, 250);
    beep(speakerPin, gS, 500);
    beep(speakerPin, f, 375);
    beep(speakerPin, cH, 125);
 
    beep(speakerPin, a, 500);
    beep(speakerPin, f, 375);
    beep(speakerPin, c, 125);
    beep(speakerPin, a, 1000);
    //and we're done \ó/
}
