int input = 0;

void setup() {              
  pinMode(3, OUTPUT);
  Serial.begin(9600); 
}

void loop() {
    input = Serial.read();
    if (input == '0'){
      analogWrite(3, 0);
    }
    if (input == '1'){
      analogWrite(3, 64);
    }
    if (input == '2'){
      analogWrite(3, 127);
    }
    if (input == '3'){
      analogWrite(3, 192);
    }
    if (input == '4'){
      analogWrite(3,225);
    }
}

