// 로그 프로그램
// 1. 기록 내용 : 시간, 메서드, 결과값
// 2. 오류 메세지?
// 3. 로그 기록 메서드 내용 : 해당 파일 경로, 해당 메서드 이름, 해당 메서드 상태값
using LogSample;


class Program
{
    static void Main(string[] args)
    {
        // 로그 남기기
        Log log = new Log();
        Console.WriteLine(log.GetPathOfFile());
    }
}
