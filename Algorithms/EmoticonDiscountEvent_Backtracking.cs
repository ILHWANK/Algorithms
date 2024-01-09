using System;

/* 사이트 : 프로그래머스
 * 문제 : 이모티콘 할인행사
 * Level : 2
 * 링크 : https://school.programmers.co.kr/learn/courses/30/lessons/150368
 * 기타 : Backtracking 버전
 */

namespace Algorithms
{
    public class EmoticonDiscountEvent_Backtracking
    {
        public static void EmoticonDiscountEvent_Backtracking_Main()
        {
            // 사용자 구매 기준 할인율 및 가격
            int[,] tempUsers = { { 40, 2900 }, { 23, 10000 }, { 11, 5200 }, { 5, 5900 }, { 40, 3100 }, { 27, 9200 }, { 32, 6900 } };
            //int[,] tempUsers = {{40, 10000}, {25, 10000} };

            // 각 이모티콘별 가격
            int[] tempEmoticons = { 1300, 1500, 1600, 4900 };
            //int[] tempEmoticons = { 7000, 9000};

            int[] answer = new int[2];

            solution(tempUsers, tempEmoticons);

            Console.WriteLine(string.Format("Answer : {0}, {1}", answer[0], answer[1]));

            int[] solution(int[,] users, int[] emoticons)
            {
                emoticon_DFS(users, emoticons, new int[emoticons.Length], 0, emoticons.Length);
                
                return answer;
            }

            void emoticon_DFS(int[,] pUsers, int[] pEmoticons, int[] pEmoticonDiscounts, int pDepth, int pLastDepth)
            {
                if (pDepth == pLastDepth) // 이모티콘 수만큼 탐색 후 각 단계별 Discount 기준으로 계산 후 결과에 따른 tempAnswer 수정
                {
                    int subscription = 0;
                    int totalPay = 0;

                    for (int i = 0; i < pUsers.GetLength(0); i++)
                    {
                        int pay = 0;

                        for (int j = 0; j < pEmoticonDiscounts.Length; j++)
                        {
                            if (pUsers[i, 0] <= pEmoticonDiscounts[j])
                            {
                                pay = pay + (pEmoticons[j] * (100 - pEmoticonDiscounts[j]) / 100);
                            }
                        }
                        if (pUsers[i, 1] <= pay)
                        {
                            subscription++;
                        }
                        else
                        {
                            totalPay += pay;
                        }
                    }

                    if (answer[0] < subscription)
                    {
                        answer[0] = subscription;
                        answer[1] = totalPay;
                    }
                    else if (answer[0] == subscription)
                    {
                        answer[1] = answer[1] < totalPay ? totalPay : answer[1];
                    }

                    return; // 이전 재귀함수 단계로 돌아다 탐색 반복
                }

                int[] discounts = { 10, 20, 30, 40 }; // 10 ~ 40 까지 모든 결과를 탐색

                for (int i = 0; i < discounts.Length; ++i)
                {
                    pEmoticonDiscounts[pDepth] = discounts[i];
                    emoticon_DFS(pUsers, pEmoticons, pEmoticonDiscounts, pDepth + 1, pLastDepth); // 마지막 Depth(pDepth) 까지 pDepth + 1 
                }
            }
        }
    }
}