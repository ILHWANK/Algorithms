using System;
using System.Collections.Generic;

/* 사이트 : 프로그래머스
 * 문제 : 섬 연결하기
 * Level : 3
 * 링크 : https://school.programmers.co.kr/learn/courses/30/lessons/42861
 * 기타 : Greedy 알고리즘 활용
 */

namespace Algorithms
{
    public class IslandConnection
    {
        public static void IslandConnection_Main()
        {
            int tempN = 4;
            int[,] tempCosts = { { 0, 1, 1 }, { 0, 2, 2 }, { 1, 2, 5 }, { 1, 3, 5 }, { 2, 3, 8 } };
            // answer 8

            /*
            int tempN = 6;
            int[,] tempCosts = { { 0, 1, 5 }, { 0, 3, 2 }, { 0, 4, 3 }, { 1, 4, 1 }, { 3, 4, 10 }, { 1, 2, 2 }, { 2, 5, 3 }, { 4, 5, 4 } };
            // answer 11
            */

            /*
            int tempN = 5;
            int[,] tempCosts = { { 0, 1, 1 }, { 2, 3, 1 }, { 3, 4, 2 }, { 1, 2, 2 }, { 0, 4, 100 } };
            // answer 6
            */

            /*
            int tempN = 5;
            int[,] tempCosts = { { 0, 1, 1 }, { 0, 4, 5 }, { 2, 4, 1 }, { 2, 3, 1 }, { 3, 4, 1 } };
            // answer 8
            */

            /*
            int tempN = 5;
            int[,] tempCosts = { { 0, 1, 5 }, { 1, 2, 3 }, { 2, 3, 3 }, { 3, 1, 2 }, { 3, 0, 4 }, { 2, 4, 6 }, { 4, 0, 7 } };
            // answer 15
            */

            /*
            int tempN = 5;
            int[,] tempCosts = { { 0, 1, 1 }, { 3, 4, 1 }, { 1, 2, 2 }, { 2, 3, 4 } };
            // answer 5
            */

            // Greedy 알고리즘 으로 Cost 가 작은 순서 대로 확인 하기 위해서 SortedDictionary 사용
            SortedDictionary<int, List<int[]>> mappingDictionary = new SortedDictionary<int, List<int[]>>(); 
            bool[,] mappings;
            bool isConnect;

            HashSet<int> visitedList = new HashSet<int>();

            Console.WriteLine(string.Format("answer : {0}", solution(tempN, tempCosts)));

            int solution(int n, int[,] costs)
            {
                int answer = 0;
                int edge   = 0;

                mappings = new bool[n, n];

                for (int i = 0; i < costs.GetLength(0); ++i) // Tree 생성
                    TreeCreate(costs[i, 2], costs[i, 0], costs[i, 1]);

                // Cost 비용이 작은 다리랑 연결된 섬 부터 순서 대로 연결
                foreach(KeyValuePair<int, List<int[]>> item in mappingDictionary)
                {
                    List<int[]> nodeDatas = item.Value;

                    for (int i = 0; i < nodeDatas.Count; ++i)
                    {
                        isConnect = false;

                        int pStartNode = nodeDatas[i][0];
                        int pEndNode   = nodeDatas[i][1];

                        // 이미 Node 가 연결된 경우 제외 하기 위해서 방문 Node 확인
                        visitedList.Add(pStartNode);
                        GetConnect(pStartNode, pEndNode);
                        visitedList.Clear();

                        visitedList.Add(pEndNode);
                        GetConnect(pEndNode, pStartNode);
                        visitedList.Clear();

                        if (!isConnect) // 방문 한 적이 없는 경우 Edge 간선 추가 및 mappings Update
                        {
                            edge++;
                            answer += item.Key; 
                            mappings[pStartNode, pEndNode] = true;
                            mappings[pEndNode, pStartNode] = true;
                        }

                        // 길을 최소한 으로 설치해야 최소 비용을 만들 수 있기 때문에 최소한 으로 설치가 된경우 Break
                        if (edge >= n - 1) break; 
                    }

                    if (edge >= n - 1) break;
                }

                return answer;
            }

            void TreeCreate(int pItem1, int pItem2, int pItem3)
            {
                List<int[]> nodeList = new List<int[]>();
                int[] nodes = new int[2];

                if (mappingDictionary.ContainsKey(pItem1))
                    nodeList = mappingDictionary[pItem1];

                nodes[0] = pItem2;
                nodes[1] = pItem3;

                nodeList.Add(nodes);

                mappingDictionary[pItem1] = nodeList;
            }

            // 이미 서로 연경된 섬인 경우 확인
            void GetConnect(int pStartnode, int pEndNode)
            {
                int nextNode = pStartnode;

                for (int i = 0; i < mappings.GetLength(1); ++i)
                {
                    if (visitedList.Contains(i)) continue;

                    if (mappings[pStartnode, i]) {
                        nextNode = i;
                        visitedList.Add(nextNode);
                        GetConnect(nextNode, pEndNode);
                    }
                }

                if (nextNode == pEndNode)
                {
                    isConnect = true;
                    return;
                }
            }
        }
    }
}
