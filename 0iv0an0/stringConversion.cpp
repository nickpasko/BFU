#include "stringConversion.h"


void stringTurnOver(char* initialString){

	std::reverse(initialString, initialString + strlen(initialString));
	
}