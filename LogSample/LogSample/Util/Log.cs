using System.Diagnostics;

namespace LogSample.Util
{
    // 아이디어 : string format으로 로그 데이터 저장/ 파일경로, 파일명, 메서드 이름 등
    public class Log
    {
        #region 멤버변수
        /// <summary>
        /// 로그가 저장될 파일 경로
        /// </summary>
        static string filename = "C:\\Dev\\MAUI\\LogSample\\LogSample\\Log";
        /// <summary>
        /// 로그 저장용 queue : 저장되는 내용은 순차적이어야 하므로
        /// 전역변수 설정
        /// </summary>
        static Queue<LogMessage> logQueue = new Queue<LogMessage>();
        /// <summary>
        /// 로그 기록 시, 여러 Thread에서 로그를 기록할 때, lock을 걸어 대기를 걸어줌
        /// lock 내부에서 코드가 실행될 때, 같은 함수가 호출되어도 중간에 인터럽트(방해)가 생기지 않음
        /// 코드의 구성 요소
        /// 1. static:        writeLock은 클래스 수준의 멤버입니다.프로그램 실행 중에 메모리에 단 한 번만 생성되고 모든 인스턴스에서 공유됩니다.
        /// 2. readonly:      writeLock은 생성자에서만 초기화할 수 있으며, 이후 변경할 수 없습니다. 값을 변경하지 못하게 하여 동기화 객체가 불변성을 가지게 합니다.
        /// 3. object:        동기화에 사용할 수 있는 가장 단순한 참조형 타입입니다.이 객체는 lock 키워드와 함께 사용됩니다.
        /// 4. new object (): writeLock은 새로 생성된 익명 객체를 참조합니다. 이 객체는 동기화의 기준점으로 사용됩니다. 
        /// </summary>
        private static readonly object writeLock = new object();
        #endregion

        #region 메서드 
        /// <summary>
        /// 로그 기록 메서드
        /// </summary>
        /// <param name="logType">로그 타입(에러, 디버그, 경고, 정보)</param>
        /// <param name="str">로그 내용 : string.Format 사용 예정(파일경로, 파일위치, 메서드이름 등)</param>
        /// <param name="writenow">로그 기록 여부</param>
        public static void WriteLog(LogType logType ,string str, bool writenow = false)
        {
            // 디버그 창에 출력
            Debug.WriteLine(str);
            // 로그 내용을 queue에 저장 -> 순차적으로 반영하기 위함
            logQueue.Enqueue(new LogMessage(logType, str));
            if (writenow)
            {
                // lock
                // static으로 관리되는 writeLock 객체에 잠금 상태를 부여하고 다른 스레드 등에서 해당 메서드를 호출할 때, 대기하도록 한다
                // 즉, writeLock 객체는 한번만 선언되고 전역으로 관리 되기 때문에 잠금상태를 부여하면해당 lock이 풀릴 때까지, 다음 동작은 대기한다.
                lock (writeLock)
                {
                    using (StreamWriter stf = new StreamWriter(filename))
                    {
                        // 로그 Queue 메모리에 데이터 존재 시, 로그 기록 시작
                        while (logQueue.Count > 0)
                        {
                            // Queue 메모리의 로그 내용 추출
                            LogMessage logMessage = logQueue.Dequeue();
                            // 로그 기록
                            stf.Write(logMessage._message);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 로그 메세지 생성 메서드
        /// </summary>
        public string GetStringFormat()
        {
            // 현재 시간
            string dateTime = DateTime.Now.ToString();
            // 해당 파일 위치
            string filePath = Environment.CurrentDirectory;
            // 해당 메서드 이름

            string.Format("");
            return "";
        }
        #endregion
    }
}
