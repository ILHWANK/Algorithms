using System;
namespace Algorithms
{
    public class AlgorithmsMain
    {
        public static void Main(string[] args)
        {
            // 1. 등대
            Lighthouse.Lighthouse_Main();

            // 2. 표현 가능한 이진트리
            ExpressionableBinaryTrees.ExpressionableBinaryTrees_Main();

            // 3. 미로 탈출 명령어
            MazeOfEscape.MazeOfEscape_Main();

            // 4. 요격 시스템
            AnInterceptionSystem.AnInterceptionSystem_Main();

            // 5. 혼자서 하는 틱택토
            AlonePlayTic_Tac_To.AlonePlayTicTacTo_Main();

            // 6_1. 이모티콘 할인행사
            EmoticonDiscountEvent.EmoticonDiscountEvent_Main();

            // 6_2. 이모티콘 할인행사_DFS
            EmoticonDiscountEvent_Backtracking.EmoticonDiscountEvent_Backtracking_Main();

            // 7. N-Queen
            N_Queen.N_Queen_Main();

            // 8. 부대 복귀
            ReturnOfTheMilitaryUnit.ReturnOfTheMilitaryUnit_Main();

            // 9. 풍선 터트리기
            PoppingBalloons.PoppingBalloons_Main();

            // 10. 섬 연결하기
            IslandConnection.IslandConnection_Main();

            // 11. 배달
            Delivery.Delivery_Main();

            // 12. 가장 큰 수
            LargestNumber.LargestNumber_Main();

            // 13. 피보나치 수
            FibonacciNumber.FibonacciNumber_Main();
        }
    }
}
