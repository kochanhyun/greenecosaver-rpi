#include <stdio.h>
#include <string.h>
#include <errno.h>

#include <wiringSerial.h>

int main ()
{
  int sp;
  char spc[20];

  if ((sp = serialOpen("/dev/ttyUSB1", 9600)) < 0)
  {
    printf("Not Connected\n") ;
    return 1 ;
  }

  while(1)
  {

	//putchar();
	//fflush (stdout) ;
    sprintf(spc, "%d", serialGetchar(sp));
	FILE *fp;
	fp = fopen("Data/data.txt", "w");
	fprintf(fp, spc);
	fclose(fp);

	system("sudo mono UDP.exe");
  }

  return 0;
}

