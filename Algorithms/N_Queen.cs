using System;

/* 사이트 : 프로그래머스
 * 문제 : N-Queen
 * Level : 2
 * 링크 : https://school.programmers.co.kr/learn/courses/30/lessons/12952
 * 기타 : BackTracking 활용
 */

namespace Algorithms
{
    public class N_Queen
    {
        public static void N_Queen_Main()
        {
            int tempAnswer = 0;

            Console.WriteLine(string.Format("answer : {0}", solution(5)));

            int solution(int n)
            {
                int answer = 0;
                int[] checks = new int[n];

                for (int i = 0; i < checks.Length; ++i)
                {
                    checks[i] = -1;
                }

                backTracking(0, n, checks);
                return tempAnswer;
            }

            // DFS 와 동일 하게 깊이 우선 탐색을 진행하다가 예외가 있는 경우 다음 노드로 넘어감
            void backTracking(int pDepth , int pLastDepth, int[] pChecks)
            {
                if (pDepth == pLastDepth)
                {
                    tempAnswer++;

                    return;
                }

                for (int i = 0 ; i < pLastDepth; ++i)
                {
                    if (isCheck(i, pDepth, pChecks))
                    {
                        pChecks[pDepth] = i;
                        backTracking(pDepth + 1, pLastDepth, pChecks);
                        pChecks[pDepth] = -1;
                    }
                }
            }

            // 방문할 필요가 없는 경우 확인
            bool isCheck(int pN, int pDepth, int[] pChecks) {
                bool isBool = true;

                for (int i = 0; i < pChecks.Length; ++i)
                {
                    if (-1 < pChecks[i])
                    {
                        if (pChecks[i] == pN)
                        {
                            isBool = false;

                            break;
                        }
                        else if (pChecks[i] + (pDepth - i) == pN)
                        {
                            isBool = false;

                            break;
                        }
                        else if (pChecks[i] - (pDepth - i) == pN)
                        {
                            isBool = false;

                            break;
                        }
                    }
                }

                return isBool;
            }
        }
    }
}
