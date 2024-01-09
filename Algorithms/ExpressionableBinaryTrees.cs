using System;
using System.Collections.Generic;

/* 사이트 : 프로그래머스
 * 문제 : 표현 가능한 이진트리
 * Level : 3
 * 링크 : https://school.programmers.co.kr/learn/courses/30/lessons/150367
 * 기타 : 
 */

namespace Algorithms
{
    public class ExpressionableBinaryTrees
    {
        public static void ExpressionableBinaryTrees_Main()
        { 
            //long[] tempNumbers = { 58, 42, 94001008090000, 58, 42, 99999999999999, 58, 42, 94001008090000, 58, 42, 94001008090000, 58, 42, 94001008090000, 58, 42, 94001008090000, 58, 42, 94001008090000, 58, 42, 94001008090000, 58, 42, 94001008090000, 58, 42, 94001008090000, 58, 42, 94001008090000, 58, 42, 94001008090000, 58, 42, 94001008090000, 58, 42, 94001008090000, 58, 42, 94001008090000, 58, 42, 94001008090000, 58, 42, 94001008090000, 58, 42, 94001008090000, 58, 42, 94001008090000, 58, 42, 94001008090000, 58, 42, 94001008090000, 58, 42, 94001008090000, 58, 42, 94001008090000, 58, 42, 94001008090000, 58, 42, 94001008090000, 58, 42, 94001008090000, 58, 42, 94001008090000, 58, 42, 94001008090000, 58, 42, 94001008090000, 58, 42, 94001008090000, 58, 42, 94001008090000, 58, 42, 94001008090000, 58, 42, 94001008090000, 58, 42, 94001008090000, 58, 42, 94001008090000, 58, 42, 94001008090000, 58, 42, 94001008090000, 58, 42, 94001008090000, 58, 42, 94001008090000, 58, 42, 94001008090000, 58, 42, 94001008090000, 58, 42, 94001008090000, 58, 42, 94001008090000, 58, 42, 94001008090000, 58, 42, 94001008090000, 58, 42, 94001008090000, 58, 42, 94001008090000, 58, 42, 94001008090000, 58, 42, 94001008090000, 58, 42, 94001008090000, 58, 42, 94001008090000, 58, 42, 94001008090000, 58, 42, 94001008090000, 58, 42, 94001008090000, 58, 42, 94001008090000, 58, 42, 94001008090000, 58, 42, 94001008090000, 58, 42, 94001008090000, 58, 42, 94001008090000, 58, 42, 94001008090000, 58, 42, 94001008090000, 58, 42, 94001008090000, 58, 42, 94001008090000, 58, 42, 94001008090000, 58, 42, 94001008090000, 58, 42, 94001008090000, 58, 42, 94001008090000, 58, 42, 94001008090000, 58, 42, 94001008090000, 58, 42, 94001008090000, 58, 42, 94001008090000, 58, 42, 94001008090000, 58, 42, 94001008090000, 58, 42, 94001008090000, 58, 42, 94001008090000, 58, 42, 94001008090000, 58, 42, 94001008090000, 58, 42, 94001008090000, 58, 42, 94001008090000, 58, 42, 94001008090000, 58, 42, 94001008090000, 58, 42, 94001008090000, 58, 42, 94001008090000, 58, 42, 94001008090000, 58, 42, 94001008090000, 58, 42, 94001008090000, 58, 42, 94001008090000, 58, 42, 94001008090000 };
            long[] tempNumbers = { 63, 111, 95, 98756453729746 };
            //long[] tempNumbers = { 7, 42, 5 };

            Dictionary<int, int[]> treeDictionary = new Dictionary<int, int[]>();
            Dictionary<int, string> binaryDictionary = new Dictionary<int, string>();

            int[] answer;
            int answerNum;

            solution(tempNumbers);

            for (int i = 0; i < answer.Length; ++i) {
                Console.WriteLine(answer[i]);
            }

            int[] solution(long[] numbers)
            {
                answer = new int[numbers.Length];

                for (int i = 0; i < numbers.Length; ++i)
                {
                    treeDictionary.Clear();
                    answerNum = 1;

                    int depth = 0;
                    double addZeroCount;
                    string binaryString = Convert.ToString(numbers[i], 2);

                    while (Math.Pow(2, depth) <= binaryString.Length) depth++;

                    addZeroCount = Math.Pow(2, depth) - binaryString.Length;

                    for (int j = 1; j < addZeroCount; ++j) binaryString = "0" + binaryString;

                    int parentNode = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(binaryString.Length) / 2));

                    Queue<int> nextNode = new Queue<int>();

                    depth -= 2;

                    nextNode.Enqueue(parentNode);

                    treeCreate(nextNode, depth, depth + 1);

                    binaryDictionary.Clear();

                    for (int n = 0; n < binaryString.Length; ++n) binaryDictionary[n] = binaryString.Substring(n, 1);

                    DFS(parentNode);

                    answer[i] = answerNum;
                }

                return answer;
            }

            void treeCreate(Queue<int> pNextNode, int pValue, int maxPow)
            {
                int curPow = 1;

                while (treeDictionary.Count < Math.Pow(2, maxPow) - 1)
                {
                    int parentNode = pNextNode.Peek();
                    int[] childNodes = new int[2];

                    pNextNode.Dequeue();

                    childNodes[0] = parentNode - Convert.ToInt32(Math.Pow(2, pValue));
                    childNodes[1] = parentNode + Convert.ToInt32(Math.Pow(2, pValue));

                    treeDictionary[parentNode] = childNodes;

                    if (treeDictionary.Count == Math.Pow(2, curPow) - 1)
                    {
                        curPow++;
                        pValue--;
                    }

                    pNextNode.Enqueue(childNodes[0]);
                    pNextNode.Enqueue(childNodes[1]);
                }
            }

            // 이진법 변경 값을 기준으로 트리 탐색 후 자식 Node 에 "1" 있는 경우 이진트리로 생성 불가능한 경우로 "0" 
            void DFS(int pStartNode)
            {
                if (treeDictionary.ContainsKey(pStartNode))
                {
                    int[] nextNodes = treeDictionary[pStartNode];

                    int parentNode  = Convert.ToInt32(pStartNode - 1);
                    int childeNode1 = Convert.ToInt32(nextNodes[0] - 1);
                    int childeNode2 = Convert.ToInt32(nextNodes[1] - 1);

                    if (binaryDictionary[parentNode] == "0")
                    {
                        if (binaryDictionary[childeNode1] == "1" || binaryDictionary[childeNode2] == "1")
                        {
                            answerNum = 0;
                            return;
                        }
                    }

                    for (int i = 1; 0 <= i; --i) DFS(nextNodes[i]);
                }
            }
        }
    }
}
