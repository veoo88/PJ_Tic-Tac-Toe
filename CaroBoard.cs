using System;
using System.Collections.Generic;
using System.Drawing;

namespace Tic_Tac_toe_1
{
    public class CaroMove
    {
        public int Row { get; set; }
        public int Col { get; set; }
        public int Player { get; set; } // 1 = X, 2 = O
        public int MoveIndex { get; set; }

        public Point Point
        {
            get { return new Point(Col, Row); }
        }

        public CaroMove(int row, int col, int player, int moveIndex = 0)
        {
            Row = row;
            Col = col;
            Player = player;
            MoveIndex = moveIndex;
        }
    }

    public class CaroBoard
    {
        public int Rows { get; private set; }
        public int Cols { get; private set; }
        public int[,] Grid { get; private set; }

        public Stack<CaroMove> UndoHistory { get; private set; }
        public Stack<CaroMove> RedoHistory { get; private set; }

        public List<Point> LastWinningLine { get; private set; }
        public Point? LastMove
        {
            get
            {
                if (UndoHistory != null && UndoHistory.Count > 0)
                    return UndoHistory.Peek().Point;
                return null;
            }
        }

        public GameRule Rule { get; set; }

        public CaroBoard(int rows = 18, int cols = 22)
        {
            Rows = rows;
            Cols = cols;
            Grid = new int[Rows, Cols];
            UndoHistory = new Stack<CaroMove>();
            RedoHistory = new Stack<CaroMove>();
            LastWinningLine = new List<Point>();
            Rule = GameRule.VietnameseCaro;
        }

        public void Reset()
        {
            Array.Clear(Grid, 0, Grid.Length);
            UndoHistory.Clear();
            RedoHistory.Clear();
            LastWinningLine.Clear();
        }

        public bool InBoard(int r, int c)
        {
            return r >= 0 && r < Rows && c >= 0 && c < Cols;
        }

        public bool IsValidMove(int r, int c)
        {
            return InBoard(r, c) && Grid[r, c] == 0;
        }

        public CaroMove MakeMove(int r, int c, int player)
        {
            if (!IsValidMove(r, c)) return null;

            Grid[r, c] = player;
            var move = new CaroMove(r, c, player, UndoHistory.Count + 1);
            UndoHistory.Push(move);
            RedoHistory.Clear(); // Nước mới sẽ xóa Redo
            return move;
        }

        public CaroMove Undo()
        {
            if (UndoHistory.Count == 0) return null;

            var last = UndoHistory.Pop();
            Grid[last.Row, last.Col] = 0;
            RedoHistory.Push(last);
            LastWinningLine.Clear();
            return last;
        }

        public CaroMove Redo()
        {
            if (RedoHistory.Count == 0) return null;

            var next = RedoHistory.Pop();
            Grid[next.Row, next.Col] = next.Player;
            UndoHistory.Push(next);
            LastWinningLine.Clear();
            return next;
        }

        public bool IsFull()
        {
            for (int r = 0; r < Rows; r++)
            {
                for (int c = 0; c < Cols; c++)
                {
                    if (Grid[r, c] == 0) return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Kiểm tra xem nước cờ vừa hạ tại (row, col) có tạo thành thế thắng hay không.
        /// </summary>
        public bool CheckWin(int row, int col, out List<Point> winLine)
        {
            winLine = new List<Point>();
            int player = Grid[row, col];
            if (player == 0) return false;

            int opponent = (player == 1) ? 2 : 1;

            int[][] directions = new int[][]
            {
                new int[] { 0, 1 },   // Ngang (Horizontal)
                new int[] { 1, 0 },   // Dọc (Vertical)
                new int[] { 1, 1 },   // Chéo chính (Diagonal \)
                new int[] { 1, -1 }   // Chéo phụ (Anti-diagonal /)
            };

            foreach (var dir in directions)
            {
                int dr = dir[0];
                int dc = dir[1];

                List<Point> line = new List<Point>();
                line.Add(new Point(col, row));

                // 1. Quét theo chiều tiến
                int rForward = row + dr;
                int cForward = col + dc;
                while (InBoard(rForward, cForward) && Grid[rForward, cForward] == player)
                {
                    line.Add(new Point(cForward, rForward));
                    rForward += dr;
                    cForward += dc;
                }

                // 2. Quét theo chiều lùi
                int rBackward = row - dr;
                int cBackward = col - dc;
                while (InBoard(rBackward, cBackward) && Grid[rBackward, cBackward] == player)
                {
                    line.Insert(0, new Point(cBackward, rBackward));
                    rBackward -= dr;
                    cBackward -= dc;
                }

                int count = line.Count;

                // Nếu có đủ từ 5 quân liên tiếp
                if (count >= 5)
                {
                    if (Rule == GameRule.FreeGomoku)
                    {
                        winLine = line;
                        LastWinningLine = line;
                        return true;
                    }
                    else // Luật Caro Việt Nam: Chặn 2 đầu không thắng
                    {
                        // Kiểm tra 2 đầu xem có BỊ QUÂN ĐỐI PHƯƠNG chặn hay không.
                        // Lưu ý chuẩn: Mép bàn cờ KHÔNG tính là quân chặn của đối phương!
                        bool headBlocked = InBoard(rForward, cForward) && (Grid[rForward, cForward] == opponent);
                        bool tailBlocked = InBoard(rBackward, cBackward) && (Grid[rBackward, cBackward] == opponent);

                        // Chỉ khi CẢ 2 ĐẦU đều bị quân địch chặn thì mới không thắng
                        if (!(headBlocked && tailBlocked))
                        {
                            winLine = line;
                            LastWinningLine = line;
                            return true;
                        }
                    }
                }
            }

            return false;
        }
    }
}

