using System;

/* 사이트 : 프로그래머스
 * 문제 : 배달
 * Level : 2
 * 링크 : https://school.programmers.co.kr/learn/courses/30/lessons/12978
 * 기타 : 다익스트라 알고리즘 연습
 */

namespace Algorithms
{
    public class Delivery
    {
        public static void Delivery_Main()
        {
            int n = 6;
            int[,] tempRoads = { { 1, 2, 1 },{ 1, 3, 2 },{ 2, 3, 2 },{ 3, 4, 3 },{ 3, 5, 2 },{ 3, 5, 3 },{ 5, 6, 1 } };
            int k = 4;

            Console.WriteLine(string.Format("Answer : {0}", solution(n, tempRoads, k)));

            int solution(int N, int[,] road, int K)
            {
                int answer = 0;
                int[, ] roadMap = new int[N, N];

                // road Array 기준으로 roadMap 생성
                for (int i = 0; i < N; ++i)
                {
                    for (int j = 0; j < N; ++j)
                        roadMap[i, j] = int.MaxValue;
                }

                for (int i = 0; i < road.GetLength(0); ++i)
                {
                    int x = road[i, 0] - 1;
                    int y = road[i, 1] - 1;
                    int rich = road[i, 2];

                    if (roadMap[x, y] != 0 || roadMap[y, x] != 0)
                    {
                        roadMap[x, y] = Math.Min(roadMap[x, y], rich);
                        roadMap[y, x] = Math.Min(roadMap[y, x], rich);
                    }
                }

                int[] distances = Dijkstra(0, roadMap, N, K);

                for (int i = 0; i < distances.Length; ++i)
                {
                    if (distances[i] <= K) answer++;
                }

                return answer;
            }

            // 추후 다른 문제 풀이를 위해 Answer 정답이 아닌 Array 를 반환
			int[] Dijkstra(int pStart, int[, ] pRoadMap, int pN, int pK)
			{
                int[] distances = new int[pN];
                bool[] visits = new bool[pN];

                // 각 지점 까지의 최초 거리 저장
                for (int i = 0; i < pN; ++i)
                    distances[i] = pRoadMap[0, i];

                distances[pStart] = 0;
                visits[pStart] = true;

                for (int i = 0; i < pN - 1; ++i) // 시작 노드 검색 제외
                {
                    int curIndex = -1;
                    int min = int.MaxValue;

                    // 아직 방문하지 않은 노드 중 최단거리 검색
                    for (int j = 0; j < pN; ++j)
                    {
                        if (visits[j]) continue;
                        if (distances[j] == int.MaxValue || distances[j] >= min) continue;
                        
                        min = distances[j];
                        curIndex = j;
                    }

                    visits[curIndex] = true;

                    for (int j = 0; j < pN; ++j)
                    {
                        if (visits[j]) continue;
                        if (pRoadMap[curIndex, j] == int.MaxValue) continue;

                        // 다른 노드를 거처서 가는 거리가 더 가까운 경우 해당 거리로 업데이트
                        if (distances[curIndex] + pRoadMap[curIndex, j] < distances[j])
                            distances[j] = distances[curIndex] + pRoadMap[curIndex, j];
                    }
                }

                return distances;
			}
		}
	}
}
