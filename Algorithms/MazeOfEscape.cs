using System;

/* 사이트 : 프로그래머스
 * 문제 : 미로 탈출 명령어
 * Level : 3
 * 링크 : https://school.programmers.co.kr/learn/courses/30/lessons/150368
 */

namespace Algorithms
{
    public class MazeOfEscape
    {
        public static void MazeOfEscape_Main()
        {
            Console.WriteLine(string.Format("1. Answer : {0}", solution(3, 4, 2, 3, 3, 1, 5)));
            Console.WriteLine(string.Format("2. Answer : {0}", solution(2, 2, 1, 1, 2, 2, 2)));
            Console.WriteLine(string.Format("3. Answer : {0}", solution(3, 3, 1, 2, 3, 3, 4)));

            string solution(int n, int m, int x, int y, int r, int c, int k)
            {
                string answer = "";
                string[] routes = { "d", "l", "r", "u" };

                int distance = getDistance(x, y, r, c);
                int[] curPosition = new int[] { x, y };

                if (distance % 2 != 0 && k % 2 == 0 || distance % 2 == 0 && k % 2 != 0 || distance > k)
                {
                    answer = "impossible";
                }
                else
                {
                    while (curPosition[0] != r || curPosition[1] != c || k > 0)
                    {
                        for (int i = 0; i < routes.Length; ++i)
                        {
                            bool isLoof = false;

                            switch (routes[i])
                            {
                                case "d":
                                    {
                                        if (curPosition[0] + 1 <= n && getDistance(curPosition[0] + 1, curPosition[1], r, c) <= k)
                                        {
                                            curPosition[0] += 1;
                                            isLoof = true;
                                        }
                                        break;
                                    }
                                case "l":
                                    {
                                        if (1 <= curPosition[1] - 1 && getDistance(curPosition[0], curPosition[1] - 1, r, c) <= k)
                                        {
                                            curPosition[1] -= 1;
                                            isLoof = true;
                                        }
                                        break;
                                    }
                                case "r":
                                    {
                                        if (curPosition[1] + 1 <= m && getDistance(curPosition[0], curPosition[1] + 1, r, c) <= k)
                                        {
                                            curPosition[1] += 1;
                                            isLoof = true;
                                        }
                                        break;
                                    }
                                case "u":
                                    {
                                        if (1 <= curPosition[0] - 1 && getDistance(curPosition[0] - 1, curPosition[1], r, c) <= k)
                                        {
                                            curPosition[0] -= 1;
                                            isLoof = true;
                                        }
                                        break;
                                    }

                                default: break;
                            }

                            if (isLoof)
                            {
                                k -= 1;
                                answer += routes[i];
                                break;
                            }
                        }
                    }
                }

                return answer;
            }

            int getDistance(int pX, int pY, int pR, int pC)
            {
                int distance = Math.Abs(pR - pX) + Math.Abs(pC - pY);

                return distance;
            }
        }
    }
}