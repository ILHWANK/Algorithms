using System;
using System.Collections.Generic;

/* 사이트 : 프로그래머스
 * 문제 : 이모티콘 할인행사
 * Level : 2
 * 링크 : https://school.programmers.co.kr/learn/courses/30/lessons/150368
 * 기타 : Tuple 및 재귀함수 활용 단, 시간이 너무 오래 걸려 DFS 또는 백트래킹으로 추가 구현
 */

namespace Algorithms
{
    public class EmoticonDiscountEvent
    {
        public static void EmoticonDiscountEvent_Main()
        {
            // 사용자 구매 기준 할인율 및 가격
            int[,] tempUsers = { {40, 2900}, {23, 10000}, {11, 5200}, {5, 5900}, {40, 3100}, {27, 9200}, {32, 6900} };
            //int[,] tempUsers = {{40, 10000}, {25, 10000} };

            // 각 이모티콘별 가격
            int[] tempEmoticons = { 1300, 1500, 1600, 4900};
            //int[] tempEmoticons = { 7000, 9000};

            int[] tempAnswer = { };

            tempAnswer = solution(tempUsers, tempEmoticons);

            Console.WriteLine(String.Format("answer : {0}, {1}", tempAnswer[0], tempAnswer[1]));

            int[] solution(int[,] users, int[] emoticons)
            {
                int[] answer = new int[] {0, 0};
                int[] discount = { 40, 30, 20, 10 };

                Dictionary<int, List<int>> discountPriceDictionary = new Dictionary<int, List<int>>();

                for (int j = 0; j < emoticons.Length; ++j)
                {
                    List<int> discountPrice = new List<int>();

                    for (int i = 0; i < discount.Length; ++i)
                    {
                        int tempEmoticonPrice = emoticons[j] - (emoticons[j] / 100 * discount[i]);

                        discountPrice.Add(tempEmoticonPrice);
                    }

                    discountPriceDictionary[j] = discountPrice;
                    Console.WriteLine(string.Format("{0}, {1}, {2}, {3}", discountPrice[0], discountPrice[1], discountPrice[2], discountPrice[3]));
                }

                int[] indexs = new int[emoticons.Length];

                answer = tempDictionary(discountPriceDictionary, users, indexs, answer, 0).Item4;

                return answer;
            }

            Tuple<Dictionary<int, List<int>>, int[, ], int[], int[], int>
                tempDictionary(Dictionary<int, List<int>> pDictionary, int[,] pUsers, int[] pIndex, int[] pCurAnswer, int pCount)
            {
                Tuple<Dictionary<int, List<int>>, int[,], int[], int[], int> returnTuple;

                for (int i = 0; i < pIndex.Length - 1; ++i)
                {
                    var tempIndex = Math.Pow(4, pIndex.Length - i - 1);

                    if (tempIndex <= pCount && pCount % tempIndex == 0)
                    {
                        pIndex[i]++;

                        if (i != 0 && pIndex.Length <= pIndex[i]) pIndex[i] = 0;
                    }
                }

                if (pCount >= 4)
                    pIndex[pIndex.Length - 1] = pCount % 4;
                else
                    pIndex[pIndex.Length - 1] = pCount;

                if (4 <= pIndex[0])
                {
                    returnTuple = new Tuple<Dictionary<int, List<int>>, int[,], int[], int[], int>(pDictionary, pUsers, pIndex, pCurAnswer, pCount);
                    return returnTuple;
                }
                else
                {
                    int subscription = 0;
                    int pay = 0;
                    int totalPay = 0;

                    for (int i = 0; i < pUsers.GetLength(0); ++i)
                    {
                        // 구매하는 이모티콘
                        pay = 0;
                        for (int j = 0; j < pDictionary.Count; ++j)
                        {
                            if (pUsers[i, 0] <= (4 - pIndex[j]) * 10)
                            {
                                pay += pDictionary[j][pIndex[j]];
                            }
                        }

                        if (pUsers[i, 1] <= pay)
                            subscription++;
                        else
                            totalPay += pay;
                    }

                    if (pCurAnswer[0] < subscription)
                    {
                        pCurAnswer[0] = subscription;
                        pCurAnswer[1] = totalPay;
                    }
                    else if (pCurAnswer[0] == subscription)
                    {
                        pCurAnswer[1] = pCurAnswer[1] < totalPay ? totalPay : pCurAnswer[1];
                    }

                    pCount++;

                    Console.WriteLine(string.Format("{0}, {1}", pIndex[0], pIndex[1]));

                    return tempDictionary(pDictionary, pUsers, pIndex, pCurAnswer, pCount);
                }
            }
        }
    }
}