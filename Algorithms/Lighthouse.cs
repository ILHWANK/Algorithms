using System;
using System.Collections.Generic;

/* 사이트 : 프로그래머스
 * 문제 : 등대
 * Level : 3
 * 링크 : https://school.programmers.co.kr/learn/courses/30/lessons/133500
 */

namespace Algorithms
{
    public class Lighthouse
    {
        public static void Lighthouse_Main()
        {
            //int[,] testlighthouse = { { 1, 2 }, { 1, 3 }, { 1, 4 }, { 1, 5 }, { 5, 6 }, { 5, 7 }, { 5, 8 } }; // 예시1
            int[,] testlighthouse = { { 4, 1 }, { 5, 1 }, { 5, 6 }, { 7, 6 }, { 1, 2 }, { 1, 3 }, { 6, 8 }, { 2, 9 }, { 9, 10 }}; // 예시2
            //int[,] testlighthouse = { { 4, 1 }, { 5, 1 }, { 5, 6 }, { 7, 6 }, { 1, 2 }, { 1, 3 }, { 6, 8 }, { 2, 9 }, { 9, 10 }, { 11, 12 }, { 10, 11 }, { 9, 13 }, { 13, 14 }, { 14, 15 }, { 15, 16 }, { 7, 8 } }; // 기타 예시1
            //int[,] testlighthouse = { { 7, 3 }, { 1, 2 }, { 2, 5 }, { 1, 4 }, { 4, 6 }, { 1, 3 }, { 7, 8 } }; // 기타 예시1
            //int[,] testlighthouse = { { 4, 5 }, { 3, 1 }, { 2, 1 }, { 2, 4 }}; // 기타 예시1

            int answer = 0;

            bool[] checkNodes;
            bool[] checkOnOffs;
            bool[] parentNodes;

            Dictionary<int, Stack<int>> lighthouseDictionary = new Dictionary<int, Stack<int>>();

            Console.WriteLine(string.Format("answer : {0}", solution(testlighthouse.GetLength(0), testlighthouse)));

            int solution(int n, int[,] lighthouse)
            {
                checkNodes  = new bool[n + 2];
                checkOnOffs = new bool[n + 2];
                parentNodes = new bool[n + 2];

                for (int i = 0; i < lighthouse.GetLength(0); ++i)
                {
                    int node1  = lighthouse[i, 0];
                    int node2  = lighthouse[i, 1];

                    twoWayTreeCreate(node1, node2);
                    twoWayTreeCreate(node2, node1);
                }

                int startNode = 0;

                foreach (KeyValuePair<int, Stack<int>> entry in lighthouseDictionary)
                {
                    startNode = entry.Key;
                    break;
                }

                lighthouse_DFS(lighthouseDictionary[startNode], startNode);

                return answer;
            }

            void twoWayTreeCreate(int pItem1, int pItem2)
            {
                Stack<int> tempNodeList = new Stack<int>();

                if (checkNodes[pItem1] == false)
                {
                    checkNodes[pItem1] = true;
                    tempNodeList.Push(pItem2);

                    lighthouseDictionary[pItem1] = tempNodeList;
                }
                else
                {
                    tempNodeList = lighthouseDictionary[pItem1];
                    tempNodeList.Push(pItem2);

                    lighthouseDictionary[pItem1] = tempNodeList;
                }
            }

            // 깊이 우선 탐색(DFS)을 진행 하면서 탐색 Node Light OnOff 여부 확인
            void lighthouse_DFS(Stack<int> pStack, int pPeek)
            {
                List<int> checkList = new List<int>();

                while (pStack.Count > 0)
                {
                    int peek = pStack.Peek();

                    if (parentNodes[peek] == false) // 부모 노드 인 경우 예외처리
                    {
                        parentNodes[peek] = true;

                        if (checkNodes[peek])
                        {
                            checkList.Add(pStack.Peek());

                            pStack.Pop();
                            lighthouse_DFS(lighthouseDictionary[peek], peek);
                        }
                        else
                        {
                            pStack.Pop();
                        }
                    }
                    else
                    {
                        pStack.Pop();
                    }
                }

                int offCount = 0;
                bool isOn = false;

                for (int i = 0; i < checkList.Count; ++i)
                {
                    if (checkNodes[checkList[i]] == false)
                    {
                        isOn = true;
                        break;
                    }

                    if(checkOnOffs[checkList[i]] == false) offCount++;
                }

                // 자식 Node(등대) 가 하나라도 꺼져 있거나  
                if (offCount > 0 || isOn)
                {
                    if (checkOnOffs[pPeek] == false)
                    {
                        checkOnOffs[pPeek] = true;
                        answer++;
                    }
                }
            }
        }
    }
}