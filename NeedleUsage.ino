const int needlePin = 3;
int serialReading = 0;
int lastSerialReading = 0;

void setup() {
  pinMode(needlePin, OUTPUT);
  Serial.begin(9600);
}

void loop() {
  //obtain serial input
  int serialReading = Serial.parseInt();
  //check if input changes
  if (serialReading != lastSerialReading) {
    lastSerialReading = serialReading;
    //output serial input to needle
    analogWrite(needlePin, lastSerialReading);
    Serial.print(lastSerialReading);
    Serial.print("\n");

  }
}
