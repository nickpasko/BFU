#include <stdio.h>

int main()
{
    FILE* f;
    int number;
    int cnt = 0;
    for (f = fopen("input.txt", "r"); !feof(f); cnt++)
    {
        fscanf(f, "%d", &number);
    }
    int *arr = new int[cnt];
    rewind(f);
    int k=0;
    for (int i=0; i<cnt; i++)
    {
        fscanf(f, "%d", &number);
        int j;
        for (j=0; j<i; j++)
            if (arr[j]==number) break;
        if (i==j)
            arr[k++]=number;
    }
    fclose(f);
    for (int i=0; i<k-1; i++)
        for (int j=0; j<k-1-i; j++)
            if (arr[j]<arr[j+1])
            {
                int temp=arr[j];
                arr[j]=arr[j+1];
                arr[j+1]=temp;
            }
    for (f = fopen("output.txt", "w"); k>1; k--)
        fprintf(f, "%d ", arr[k-1]);
    fprintf(f, "%d", arr[0]);
    delete [] arr;
    fclose(f);
    return 0;
}
