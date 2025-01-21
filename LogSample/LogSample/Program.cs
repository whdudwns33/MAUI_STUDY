// 로그 프로그램
// 1. 기록 내용 : 시간, 메서드, 결과값
// 2. 오류 메세지?
// 3. 로그 기록 메서드 내용 : 해당 파일 경로, 해당 메서드 이름, 해당 메서드 상태값
using LogSample;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using LogSample.Util;
using System.Reflection;


class Program
{
    static void Main(string[] args)
    {
        Log.WriteLog(LogType.Info, "프로그램 시작 IN", Log.GetFilePath(MethodBase.GetCurrentMethod().Name), MethodEnter.Enter, true);

        int end = 0;
        while(end != 2)
        {
            try
            {
                Console.WriteLine($"{end}. 기록할 내용을 입력하세요.");
                string logData = Console.ReadLine();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Log.WriteLog(LogType.Error, ex.ToString(), Log.GetFilePath(MethodBase.GetCurrentMethod().Name), MethodEnter.Enter, true);
            } 

            end++;
        }
    }
}
