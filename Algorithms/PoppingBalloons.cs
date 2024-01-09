using System;

/* 사이트 : 프로그래머스
 * 문제 : 풍선 터트리기
 * Level : 3
 * 링크 : https://school.programmers.co.kr/learn/courses/30/lessons/12952
 */

namespace Algorithms
{
    public class PoppingBalloons
    {
        public static void PoppingBalloons_Main()
        {
            int[] tempAs = { -16, 27, 65, -2, 58, -92, -71, -68, -61, -33 };
            //int[] tempAs = { 9, -1, -5 };

            Console.WriteLine(string.Format("answer : {0}", solution(tempAs)));

            int solution(int[] a)
            {
                int answer   = 0;

                int minLeft  = a[0];
                int minRight = a[a.Length - 1];

                int[] minLefts  = new int[a.Length];
                int[] minRights = new int[a.Length];

                // index 별 최솟값 저장
                for (int i = 0; i < a.Length - 1; ++i)
                {
                    minLeft = minLeft < a[i] ? minLeft : a[i];
                    minLefts[i] = minLeft;
                }

                for (int i = a.Length - 1; 0 <= i; --i)
                {
                    minRight = minRight < a[i] ? minRight : a[i];
                    minRights[i] = minRight;
                }

                // 각 index 별 좌우 최솟값 비교 후 약쪽보다 작은수인 경우 제외
                for (int i = 0; i < a.Length; ++i)
                {
                    if (checkSmallNumber(i, a, minLefts, minRights))
                        answer++;
                }

                return answer;
            }

            bool checkSmallNumber(int pNumberIndex, int[] pNumbers, int[] pLeft, int[] pRight)
            {
                int smallNumberCount = 0;

                if (pLeft[pNumberIndex] < pNumbers[pNumberIndex])
                {
                    smallNumberCount++;
                }

                if (pRight[pNumberIndex] < pNumbers[pNumberIndex])
                {
                    smallNumberCount++;
                }

                return 2 <= smallNumberCount ? false : true;
            }
        }
    }
}
