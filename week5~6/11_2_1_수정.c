#include <stdio.h>
#include <math.h>
#define PHI 3.141592
long total_days(int year, int month, int day);
void print_biorhythm(long total, int tyr, int month);
char bio_status(int val, int mod);

int main(void)
{
    printf("바이오리듬 계산기 프로그램입니다.\n");
    printf("Enter를 입력하면 실행됩니다.");
    char c;
    scanf("%c", &c);
    if(c != '\n') {
        printf("다른 버튼을 누르셨습니다, 프로그램이 종료됩니다. 좋은 하루되세요! *^^*\n");
        return 0;
    }
    system("cls");
    int byr, bmon, bday;
    int tyr, tmon, tday;
    long total=0;
    printf("반갑습니다! 바이오리듬 계산 프로그램에 오신 것을 환영합니다.\n");
    printf("특정월의 바이오리듬을 계산하는 프로그램입니다.\n");
    printf("첫번째 날짜와 두번째 날짜를 입력하고 Enter 하세요.\n");
    printf("첫번째 날짜가 두번째 날짜보다 앞서야 합니다. \n\n");
    printf("생년 월일을 입력하세요 (ex: 1983 5 21) \n");
    scanf("%d%d%d", &byr, &bmon, &bday);
    printf("보시고 싶은 년도와 월을 입력하세요. (ex: 2004 11) \n");
    scanf("%d%d", &tyr, &tmon);
    if(tyr < byr || (tyr == byr && tmon <= bmon)) {
        printf("날짜 정보가 잘못 입력되었습니다.\n");
        printf("바이오리듬 계산기를 종료합니다.");
        return 0;
    }
    tday=1;
    total=total_days(tyr, tmon, tday)-total_days(byr, bmon, bday);
    printf("두 날짜 사이의 날짜수는 %ld일 입니다. \n\n", total);
    printf("바이오리듬 결과:\n");
    printf("저조기(-), 고조기(+), 위험기(D)\n");
    print_biorhythm(total, tyr, tmon);
    return 0;
}
void print_biorhythm(long total, int year, int month)
{
  //[함수 11.2.2]의 정의부분 참고
    int dayindex;
    int physical, emotion, intellect;
    int lastDay[]={31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31};
    if(!(year%4) && year%100 || !(year%400)) lastDay[1]++;
    for(dayindex=1; dayindex<=lastDay[month - 1]; dayindex++)
    {
        physical=total%23;
        emotion=total%28;
        intellect=total%33;
        printf("%d월 %2d일", month, dayindex);
        printf(" 신체:%2d %c ", physical, bio_status(physical, 23));
        printf(" 감정:%2d %c ", emotion, bio_status(emotion, 28));
        printf(" 지성:%2d %c\n", intellect, bio_status(intellect, 33));
        total++;
    }
}
char bio_status(int v, int mod)
{
  //[함수 11.2.1]의 정의부분 참고
   char result;
   double r;
   r=sin(v*3.141592/(mod/2.0));
   if (r < -0.2)
        result='-';
   else if ((-0.2<=r) && (r<=0.2))
        result='D';
   else
    result='+';
   return result;
}

long total_days(int year, int month, int day)
{
  //[함수 2.3.2]의 정의부분 참고
    int months[]={31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31};
    int i;
    long total=0L;
    total=(year-1)*365L+(year-1)/4-(year-1)/100+(year-1)/400;
    if(!(year%4) && year%100 || !(year%400))
        months[1]++;
    for(i=0; i<month-1; i++)
        total += months[i];
    total+=day;
    return total;
}
