using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

// 


namespace LogSample
{
    public class Log
    {
        /// <summary>
        /// 상태값
        /// enum 타입에 따라 정리
        /// 구분은 1)메서드 진입, 2)결과값
        /// </summary>
        enum LogType
        {
            Method, // 메서드 진입 상태값
            Result  // 결과값
        }

        /// <summary>
        /// 파일 경로 조회
        /// </summary>
        public string GetPathOfFile()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string path = assembly.Location;
            return path;
        }
    }
}
