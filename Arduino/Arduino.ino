int switchPin1 = 7;  // botones
int switchPin2 = 8;  // botones
int switchPin3 = 9;

int Pin1 = A3; // potenciometros
int Pin2 = A0; // // potenciometros

int data1;
int data2;
int data3;
int data4;

int dato;
int dato2;
int dato5;

void setup()
{
  Serial.begin(9600);
  pinMode(switchPin1, INPUT);  // set digital pin 0 as input
  pinMode(switchPin2, INPUT);  // set digital pin 0 as input
  pinMode(switchPin3, INPUT);
  
  pinMode(Pin1, INPUT);
  pinMode(Pin2, INPUT);
  
}

void loop()
{
  if (digitalRead(switchPin1) == HIGH) // if the switch is pressed
  {
    dato = 1;      
  }
  else if (digitalRead(switchPin1) == LOW){
    dato = 0;    
    }
  
  if (digitalRead(switchPin2) == HIGH) // if the switch is pressed
  {
    dato2 = 2;
    
  }
  else if (digitalRead(switchPin2) == LOW){
    dato2 = 0;    
    }
    
  if (digitalRead(switchPin3) == HIGH) // if the switch is pressed
  {
    dato5 = 3;    
  }
  
  else if (digitalRead(switchPin3) == LOW){
    dato5 = 4;    
    }
    
  
  

  data1 = analogRead(Pin1);
  data2 = analogRead(Pin2);

  data3 = map(data1, 0, 1023, 3, 1023);
  data4 = map(data2, 0, 1023, 3, 1023);

  Serial.print(dato);
  Serial.print(",");
  Serial.print(dato2);
  Serial.print(",");

  Serial.print(data4);
  Serial.print(",");
  Serial.print(data3);

  Serial.print(",");
  Serial.println(dato5);  
  Serial.flush();
  delay(20);
  
}
