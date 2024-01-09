using System;
using System.Collections.Generic;

/* 사이트 : 프로그래머스
 * 문제 : 요격 시스템
 * Level : 2
 * 링크 : https://school.programmers.co.kr/learn/courses/30/lessons/181188
 */

namespace Algorithms
{
    class AnInterceptionSystem
    {
        public static void AnInterceptionSystem_Main()
        {
            // 문제 예시
            int[,] testTargets = { { 11, 13 }, { 10, 14 }, { 5, 12 }, { 4, 8 }, { 4, 5 }, { 3, 7 }, { 1, 4 } };

            Console.WriteLine(string.Format("1. answer : {0}", solution(testTargets)));

            int solution(int[,] targets)
            {
                int answer = 0;
                List<int[]> targetList = new List<int[]>();

                // List 생성
                for (int i = 0; i < targets.GetLength(0); ++i)
                {
                    int[] target = new int[2];

                    target[0] = targets[i, 0];
                    target[1] = targets[i, 1];

                    targetList.Add(target);
                }

                // 범위 축소전 순서 정렬
                targetList.Sort(delegate (int[] S, int[] E) {
                    if (S[0] > E[0]) return 1;
                    else if (S[0] < E[0]) return -1;
                    return 0;
                });

                int curEndPosition = 100000000;// 문제 조건의 마지막 포지션
                answer++;

                // 포격 범위 축소
                for (int i = 0; i < targetList.Count; i++)
                {
                    if (curEndPosition > targetList[i][1])
                    {
                        curEndPosition = targetList[i][1];
                    }

                    // Position을 넘어 간 경우 추가
                    if (curEndPosition <= targetList[i][0])
                    {
                        curEndPosition = targetList[i][1];
                        answer++;
                    }
                }

                return answer;
            }
        }
    }
}
