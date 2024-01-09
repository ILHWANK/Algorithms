using System;

/* 사이트 : 프로그래머스
 * 문제 : 피보나치 
 * Level : 2
 * 링크 : https://school.programmers.co.kr/learn/courses/30/lessons/12945
 * 기타 : 재귀 함수로 피보나치를 구현 하였으나 깊이가 너무 깊어 Stack overflow 오류로 while 문 으로 수정
 */

namespace Algorithms
{
    public class FibonacciNumber
    {
        public static void FibonacciNumber_Main()
        {
            int tempN = 100000; // 문제에서 가장 큰 "N" 값

            Console.WriteLine("Answer : " + solution(tempN));

            int solution(int n)
            {
                int answer = 0;
                int value1 = 0;
                int value2 = 1;
                int fibonacciCount = 2;

                while (fibonacciCount <= n)
                {
                    // 피보나치 로 계산한 값이 int 범위를 넘어 가는 경우 예외처리
                    answer = (value1 + value2) % 1234567; 

                    value1 = value2;
                    value2 = answer;

                    fibonacciCount++;
                }

                return answer;
            }
        }
    }
}
