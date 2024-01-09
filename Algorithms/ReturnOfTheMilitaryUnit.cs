using System;
using System.Collections.Generic;

/* 사이트 : 프로그래머스
 * 문제 : 부대복귀
 * Level : 3
 * 링크 : https://school.programmers.co.kr/learn/courses/30/lessons/132266
 * 기타 : 다익스트라 알고리즘으로 접근 했으나 거리가 1로 동일 하여 BFS 로 전환 및 많은 데이터로 HashSet, SortDictionary 활용
 */

namespace Algorithms
{
    public class ReturnOfTheMilitaryUnit
    {
        public static void ReturnOfTheMilitaryUnit_Main()
        {
            /*
            int tempN = 5;
            int[,] tempRoads = { { 1, 2 }, { 1, 4 }, { 2, 4 }, { 2, 5 }, { 4, 5 }};
            int[] tempSources = { 1, 3, 5};
            int tempDestination = 5;
            */

            /*
            int tempN = 3;
            int[,] tempRoads = { {1, 2 }, { 1, 3 }, { 2, 3 }};
            int[] tempSources = { 2, 3 };
            int tempDestination = 3;
            */

            int tempN = 9;
            int[,] tempRoads = { { 1, 2 }, { 1, 3 }, { 1, 4 },
                                 { 2, 5 }, { 3, 6 }, { 5, 7 }, { 7, 8}, { 8, 9},
                                 { 2, 3}, { 5, 6}, { 2, 6}, { 6, 7} };

            int[] tempSources = { 9, 6, 4 };
            int tempDestination = 1;

            int[] answer;

            // 데이터 량이 많아 SortedDictionary 사용
            SortedDictionary<int, List<int>> graphDictionary = new SortedDictionary<int, List<int>>();
 
            solution(tempN, tempRoads, tempSources, tempDestination);

            Console.Write("answer : ");

            for (int i = 0; i < answer.Length; ++i) Console.Write(answer[i] + " ");

            int[] solution(int n, int[,] roads, int[] sources, int destination)
            {
                answer = new int[sources.Length];

                for (int i = 0; i < roads.GetLength(0); ++i)
                {
                    twoWayTreeCreate(roads[i, 0], roads[i, 1]);
                    twoWayTreeCreate(roads[i, 1], roads[i, 0]);
                }

                // 출발 지와 도착 지가 같은 경우 0, 아닌 경우 -1 로 추기화
                for (int i = 0; i < answer.Length; ++i)
                    answer[i] = sources[i] == destination ? 0 : -1;

                // 출발 지점 sources 가 아닌 시작 지점을 출발지로 선택(최초 1회 탐색으로 모든 Sources 탐색 가능) 
                BFS(destination, sources);

                return answer;
            }

            void twoWayTreeCreate(int pItem1, int pItem2)
            {
                List<int> nodeList = new List<int>();

                if (graphDictionary.ContainsKey(pItem1))
                    nodeList = graphDictionary[pItem1];

                nodeList.Add(pItem2);

                graphDictionary[pItem1] = nodeList;
            }

            // 각 Node 사이 시간이 동일 하기 때문에 다익스트라 대신 BFS 알고리즘 사용
            void BFS(int pStartNode, int[] pSources) 
            {
                Queue<int> bfsQueue = new Queue<int>();

                // 검색 속도 및 중복 추가를 방지 하기 위해 HashSet 활용
                HashSet<int> visiteList   = new HashSet<int>();
                HashSet<int> curNodeList  = new HashSet<int>();
                HashSet<int> nextNodeList = new HashSet<int>();

                int distance         = 1;
                int breadthCount     = graphDictionary[pStartNode].Count;
                int nextBreadthCount = 0;

                bfsQueue.Enqueue(pStartNode);
                visiteList.Add(pStartNode);

                // 너비 우선 탐색 시작
                while (bfsQueue.Count != 0)
                {
                    pStartNode = bfsQueue.Dequeue();

                    if (breadthCount == 0) // 너비 우선 탐색 완료 확인 후 거리(distance) 증가 및  pSources 에 있는 경우 answer distance 병경
                    {
                        for (int i = 0; i < pSources.Length; ++i)
                            if (curNodeList.Contains(pSources[i])) answer[i] = distance;

                        breadthCount = nextBreadthCount;

                        distance++;

                        curNodeList.Clear();
                        nextNodeList.Clear();
                    }

                    // 다음 너비 확인 후 nextBreadthCount 수 저장
                    for (int i = 0; i < graphDictionary[pStartNode].Count; ++i)
                    {
                        int node = graphDictionary[pStartNode][i];

                        if (!visiteList.Contains(node))
                        {
                            bfsQueue.Enqueue(node);

                            curNodeList.Add(node);
                            visiteList.Add(node);
                            
                            for (int j = 0; j < graphDictionary[node].Count; ++j)
                            {
                                if (!visiteList.Contains(graphDictionary[node][j]))
                                    nextNodeList.Add(graphDictionary[node][j]);
                            }

                            if (nextNodeList.Contains(node)) nextNodeList.Remove(node);

                            breadthCount--;
                        }
                    }

                    nextBreadthCount = nextNodeList.Count;
                }
            }
        }
    }
}
