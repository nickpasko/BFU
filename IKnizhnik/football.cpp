#include <iostream>
#include <cstdio>

void f(int n, int **a) {
	setlocale(LC_ALL, "Russian");
	for (int i = 0; i < n - 1; i++){
		for (int j = i + 1; j < n; j++)
			printf("Команда%d - Команда%d: Счёт %d-%d\n", i+1, j+1, a[i][j], a[j][i]);
	}
}
