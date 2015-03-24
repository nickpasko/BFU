#include "stdafx.h"
#include <iostream>
#include <string>
#include <fstream>

using namespace std;

int _tmain(int argc, _TCHAR* argv[])
{
	int budget;
	string filename;

	cin >> filename >> budget;
	ifstream input(filename + ".tsv");

	string regionname[1000];
	int population[1000];
	int i = 0;

	while (!input.eof()){
	input >> regionname[i] >> population[i];
	i=i+1;
	}
	int n = i;
	int sum = 0;

	for (int i = 0; i < n; i++){
	sum = sum + population[i];
	}

	cout << budget / sum <<"\n" ;

	ofstream output("output.tsv");
	for (int i = 0; i < n; i++){
	output << regionname[i] << "	" << (population[i] * budget / sum) << "\n";
	}

	input.close();
	output.close();

	return 0;

}