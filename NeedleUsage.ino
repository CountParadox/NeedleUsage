
int OUTPUT_PIN = 3;
const unsigned int TABLE_SIZE = 5;

void setup()
{
	pinMode(OUTPUT_PIN, OUTPUT);
	Serial.begin(9600);
}


void loop()
{
	unsigned int input = 0;
	input = Serial.read();
	int number_read = input - '0';
	int output_table[TABLE_SIZE] = { 0, 64, 127, 192, 225 };

	if (0 <= number_read && number_read <= TABLE_SIZE - 1)
	{
		analogWrite(OUTPUT_PIN, output_table[number_read]);
	}
}
