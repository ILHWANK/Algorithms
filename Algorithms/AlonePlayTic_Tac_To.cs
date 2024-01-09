using System;
using System.Collections.Generic;

/* 사이트 : 프로그래머스
 * 문제 : 혼자서 하는 틱택토
 * Level : 2
 * 링크 : https://school.programmers.co.kr/learn/courses/30/lessons/160585
 */

namespace Algorithms
{
    public class AlonePlayTic_Tac_To
    {
        public static void AlonePlayTicTacTo_Main()
        {
            //string[] testString = { "O.X", ".O.", ".X." }; // case1
            //string[] testString = { "OOO", "...", "XXX" }; // case2
            //string[] testString = { "...", ".X.", "..." }; // case3
            //string[] testString = { "...", "...", "..." }; // case4
            //string[] testString = { "XO.", "XO.", ".O." }; // case5
            //string[] testString = { "OX.", "OX.", "OXO" }; // case6
            string[] testString = { "OXO", "XOX", "OXO" }; // case7

            Console.WriteLine(string.Format("2. answer : {0}", solution(testString)));

            int solution(string[] board)
            {
                int answer   = 1;
                int OCount   = 0;
                int XCount   = 0;

                int y_0 = 0;
                int y_1 = 2;

                Stack<string> yStack_0 = new Stack<string>();
                Stack<string> yStack_1 = new Stack<string>();
                Stack<string> yStack_2 = new Stack<string>();

                Stack<string> xyStack_0 = new Stack<string>();
                Stack<string> xyStack_1 = new Stack<string>();

                List<Stack<string>> stackList = new List<Stack<string>>();

                string[,] TicTacToFeild = new string[3,3];

                for (int i = 0; i < board.Length; ++i)
                {
                    TicTacToFeild[i, 0] = board[i].Substring(0, 1);
                    TicTacToFeild[i, 1] = board[i].Substring(1, 1);
                    TicTacToFeild[i, 2] = board[i].Substring(2, 1);
                }

                for (int x = 0; x < TicTacToFeild.GetLength(0); ++x)
                {
                    Stack<string> xStack = new Stack<string>();

                    for (int y = 0; y < TicTacToFeild.GetLength(1); ++y)
                    {
                        if (TicTacToFeild[x, y].Equals("O"))
                        {
                            OCount++;
                        }
                        else if (TicTacToFeild[x, y].Equals("X"))
                        {
                            XCount++;
                        }

                        // X
                        if (xStack.Count == 0)
                        {
                            if (!TicTacToFeild[x, y].Equals("."))
                                xStack.Push(TicTacToFeild[x, y]);
                        }
                        else if (xStack.Peek().Equals(TicTacToFeild[x, y]))
                        {
                            xStack.Push(TicTacToFeild[x, y]);
                        }

                        // Y
                        if (y == 0)
                        {
                            if (isStackPush(yStack_0, TicTacToFeild[x, y]))
                            {
                                yStack_0.Push(TicTacToFeild[x, y]);
                            }
                        }
                        else if (y == 1)
                        {
                            if (isStackPush(yStack_1, TicTacToFeild[x, y]))
                            {
                                yStack_1.Push(TicTacToFeild[x, y]);
                            }
                        }
                        else if (y == 2)
                        {
                            if (isStackPush(yStack_2, TicTacToFeild[x, y]))
                            {
                                yStack_2.Push(TicTacToFeild[x, y]);
                            }
                        }
                    }

                    // XY
                    if (isStackPush(xyStack_0, TicTacToFeild[x, y_0]))
                    {
                        xyStack_0.Push(TicTacToFeild[x, y_0]);
                    }

                    if (isStackPush(xyStack_1, TicTacToFeild[x, y_1]))
                    {
                        xyStack_1.Push(TicTacToFeild[x, y_1]);
                    }

                    if (isStackListAdd(xStack)) stackList.Add(xStack);

                    y_0++;
                    y_1--;
                }

                if (isStackListAdd(yStack_0)) stackList.Add(yStack_0);
                if (isStackListAdd(yStack_1)) stackList.Add(yStack_1);
                if (isStackListAdd(yStack_2)) stackList.Add(yStack_2);
                if (isStackListAdd(xyStack_0)) stackList.Add(xyStack_0);
                if (isStackListAdd(xyStack_1)) stackList.Add(xyStack_1);

                if (OCount < XCount)
                    answer = 0;
                else if (XCount <= OCount - 2)
                    answer = 0;
                else
                {
                    if (0 < stackList.Count)
                    {
                        if (1 < stackList.Count)
                        {
                            if (!stackList[0].Peek().Equals(stackList[1].Peek()))
                                answer = 0;
                        }
                        else
                        {
                            if (stackList[0].Peek().Equals("O")){
                                if (OCount == XCount) answer = 0;       
                            }
                            else
                            {
                                if (XCount < OCount) answer = 0;
                            }
                        }
                    }
                }

                return answer;
            }

            bool isStackPush(Stack<string> pStack, string pString)
            {
                if (pStack.Count == 0)
                {
                    return pString.Equals(".") ? false : true;
                }
                else if (pStack.Peek().Equals(pString)) return true;
                else return false;
            }

            bool isStackListAdd(Stack<string> pStack)
            {
                return 3 <= pStack.Count ? true : false;
            }
        }
    }
}
