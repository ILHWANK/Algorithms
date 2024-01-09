using System;
using System.Text;
using System.Collections.Generic;

/* 사이트 : 프로그래머스
 * 문제 : 가장 큰 수
 * Level : 2
 * 링크 : https://school.programmers.co.kr/learn/courses/30/lessons/42746
 * 기타 : 버블 정렬로 접근 했으나 시간 초과로 퀵 정렬로 변경 하여 해결
 */

namespace Algorithms
{
    public class LargestNumber
    {
        public static void LargestNumber_Main()
        {
            //int[] tempNumbers = { 6, 10, 2 };
            int[] tempNumbers = { 3, 30, 34, 5, 9 };
            //int[] tempNumbers = { 0, 0, 0, 0 };

            string[] strings = new string[1001];

            Console.WriteLine(string.Format("Answer : {0}", solution(tempNumbers)));

            string solution(int[] numbers)
            {
                int[] countSet = new int[1001];

                foreach (var n in numbers)
                {
                    countSet[n]++;
                }

                if (countSet[0] == numbers.Length)
                    return "0";

                for (int i = 0; i <= 1000; i++)
                {
                    strings[i] = Convert.ToString(i);
                }

                QuickSort(0, strings.Length - 1);

                StringBuilder stringBuilder = new StringBuilder();

                foreach (var it in strings)
                {
                    int i = Convert.ToInt32(it);

                    while (countSet[i] > 0)
                    {
                        stringBuilder.Append(it);
                        countSet[i]--;
                    }
                }

                string answer = stringBuilder.ToString();

                return answer;

                /*
                // 버블 정렬 시간 초과로 QuickSort 로 수정
                while (loof < numbers.Length) {
                    for (int i = 0; i < numbers.Length - 1; ++i)
                    {
                        int number1 = Convert.ToInt32(numbers[i].ToString() + numbers[i + 1].ToString());
                        int number2 = Convert.ToInt32(numbers[i + 1].ToString() + numbers[i].ToString());

                        if (number1 < number2)
                        {
                            int tempNUmber1 = numbers[i];
                            int tempNUmber2 = numbers[i + 1];

                            numbers[i] = tempNUmber2;
                            numbers[i + 1] = tempNUmber1;
                        }

                        strings[i] = numbers[i].ToString();
                        strings[i + 1] = numbers[i + 1].ToString();
                    }
                    loof++;
                }
                */
            }

            void QuickSort(int pStart, int pEnd) {

                if (pStart < pEnd)
                {
                    int pivot = Partition(pStart, pEnd);

                    QuickSort(pStart, pivot - 1);
                    QuickSort(pivot + 1, pEnd);
                }
            }

            int Partition(int pStart, int pEnd)
            {
                string pivot = strings[pEnd];
                int i = pStart - 1;

                for (int j = pStart; j < pEnd; j++)
                {
                    if (Convert.ToInt32(strings[j] + pivot) > Convert.ToInt32(pivot + strings[j]))
                    {
                        i++;
                        string tempValue = strings[i];
                        strings[i] = strings[j];
                        strings[j] = tempValue;
                    }
                }

                string swapValue = strings[i + 1];
                strings[i + 1] = strings[pEnd];
                strings[pEnd] = swapValue;

                return i + 1;
            }
        }
    }
}
