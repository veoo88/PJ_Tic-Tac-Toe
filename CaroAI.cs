using System;
using System.Collections.Generic;
using System.Drawing;

namespace Tic_Tac_toe_1
{
    public class CaroAI
    {
        private static Random random = new Random();

        // Điểm đánh giá các thế cờ
        private const int SCORE_WIN = 20000000;          // 5 quân (Thắng tuyệt đối)
        private const int SCORE_OPEN_FOUR = 2000000;     // 4 quân hở 2 đầu (Tất thắng nước sau)
        private const int SCORE_BLOCKED_FOUR = 200000;   // 4 quân hở 1 đầu (Nguy hiểm cấp 1)
        private const int SCORE_OPEN_THREE = 50000;      // 3 quân hở 2 đầu (Rất nguy hiểm)
        private const int SCORE_BLOCKED_THREE = 4000;    // 3 quân hở 1 đầu
        private const int SCORE_OPEN_TWO = 800;          // 2 quân hở 2 đầu
        private const int SCORE_BLOCKED_TWO = 100;       // 2 quân hở 1 đầu
        private const int SCORE_ONE = 10;                // 1 quân

        public static Point FindBestMove(CaroBoard board, int aiPlayer, AIMode mode)
        {
            switch (mode)
            {
                case AIMode.Easy:
                    return GetEasyMove(board, aiPlayer);
                case AIMode.Medium:
                    return GetMediumMove(board, aiPlayer);
                case AIMode.Hard:
                default:
                    return GetHardMove(board, aiPlayer);
            }
        }

        public static Point? GetHint(CaroBoard board, int humanPlayer)
        {
            if (board.UndoHistory.Count == 0)
                return new Point(board.Cols / 2, board.Rows / 2);

            return GetHardMove(board, humanPlayer);
        }

        #region Candidate Moves Selection

        /// <summary>
        /// Lọc ra các ô trống nằm trong bán kính radius (mặc định 2) quanh các ô đã có quân.
        /// Giúp giảm không gian tìm kiếm từ 300+ ô xuống còn 15-30 ô tiềm năng nhất.
        /// </summary>
        public static List<Point> GetCandidateMoves(CaroBoard board, int radius = 2)
        {
            var candidates = new HashSet<Point>();

            if (board.UndoHistory.Count == 0)
            {
                candidates.Add(new Point(board.Cols / 2, board.Rows / 2));
                return new List<Point>(candidates);
            }

            for (int r = 0; r < board.Rows; r++)
            {
                for (int c = 0; c < board.Cols; c++)
                {
                    if (board.Grid[r, c] != 0)
                    {
                        for (int dr = -radius; dr <= radius; dr++)
                        {
                            for (int dc = -radius; dc <= radius; dc++)
                            {
                                int nr = r + dr;
                                int nc = c + dc;
                                if (board.InBoard(nr, nc) && board.Grid[nr, nc] == 0)
                                {
                                    candidates.Add(new Point(nc, nr));
                                }
                            }
                        }
                    }
                }
            }

            if (candidates.Count == 0)
            {
                candidates.Add(new Point(board.Cols / 2, board.Rows / 2));
            }

            return new List<Point>(candidates);
        }

        #endregion

        #region Easy AI

        private static Point GetEasyMove(CaroBoard board, int aiPlayer)
        {
            int humanPlayer = (aiPlayer == 1) ? 2 : 1;
            var candidates = GetCandidateMoves(board, 1);

            // 1. Kiểm tra nếu có nước thắng ngay thì đánh
            foreach (var pt in candidates)
            {
                if (CanWinAt(board, pt.Y, pt.X, aiPlayer))
                    return pt;
            }

            // 2. Chặn nước thắng ngay của người chơi (với tỉ lệ 80% để người mới dễ thở)
            if (random.Next(100) < 85)
            {
                foreach (var pt in candidates)
                {
                    if (CanWinAt(board, pt.Y, pt.X, humanPlayer))
                        return pt;
                }
            }

            // 3. Đánh ngẫu nhiên vào các ô kề cận
            if (candidates.Count > 0)
            {
                return candidates[random.Next(candidates.Count)];
            }

            return new Point(board.Cols / 2, board.Rows / 2);
        }

        #endregion

        #region Medium AI

        private static Point GetMediumMove(CaroBoard board, int aiPlayer)
        {
            int humanPlayer = (aiPlayer == 1) ? 2 : 1;
            var candidates = GetCandidateMoves(board, 2);

            // 1. Nước thắng ngay
            foreach (var pt in candidates)
            {
                if (CanWinAt(board, pt.Y, pt.X, aiPlayer))
                    return pt;
            }

            // 2. Nước chặn thắng ngay của người chơi
            foreach (var pt in candidates)
            {
                if (CanWinAt(board, pt.Y, pt.X, humanPlayer))
                    return pt;
            }

            Point bestMove = candidates[0];
            long maxScore = long.MinValue;

            foreach (var pt in candidates)
            {
                long attackScore = EvaluatePoint(board, pt.Y, pt.X, aiPlayer);
                long defenseScore = EvaluatePoint(board, pt.Y, pt.X, humanPlayer);

                long totalScore = attackScore + (long)(defenseScore * 1.2);

                if (totalScore > maxScore)
                {
                    maxScore = totalScore;
                    bestMove = pt;
                }
            }

            return bestMove;
        }

        #endregion

        #region Hard / Master AI (Heuristic Matrix + Double Threat Detection)

        private static Point GetHardMove(CaroBoard board, int aiPlayer)
        {
            int humanPlayer = (aiPlayer == 1) ? 2 : 1;
            var candidates = GetCandidateMoves(board, 2);

            // 1. Ưu tiên tuyệt đối: Đánh thắng ngay nếu có
            foreach (var pt in candidates)
            {
                if (CanWinAt(board, pt.Y, pt.X, aiPlayer))
                    return pt;
            }

            // 2. Ưu tiên tuyệt đối: Chặn ngay nếu người chơi có nước thắng
            foreach (var pt in candidates)
            {
                if (CanWinAt(board, pt.Y, pt.X, humanPlayer))
                    return pt;
            }

            // 3. Đánh giá toàn diện các thế cờ
            Point bestMove = candidates[0];
            long bestScore = long.MinValue;

            int centerR = board.Rows / 2;
            int centerC = board.Cols / 2;

            foreach (var pt in candidates)
            {
                long attackScore = EvaluatePoint(board, pt.Y, pt.X, aiPlayer);
                long defenseScore = EvaluatePoint(board, pt.Y, pt.X, humanPlayer);

                // Nếu người chơi chuẩn bị tạo thế 4 hở 2 đầu hoặc gài bẫy đôi, phòng thủ tối đa
                long score = (long)(attackScore * 1.1) + (long)(defenseScore * 1.3);

                // Ưu tiên chiếm vị trí trung tâm bàn cờ
                double distanceToCenter = Math.Sqrt(Math.Pow(pt.Y - centerR, 2) + Math.Pow(pt.X - centerC, 2));
                score += (long)(10 - distanceToCenter);

                if (score > bestScore)
                {
                    bestScore = score;
                    bestMove = pt;
                }
            }

            return bestMove;
        }

        #endregion

        #region Pattern Evaluation Engine

        private static bool CanWinAt(CaroBoard board, int r, int c, int player)
        {
            board.Grid[r, c] = player;
            List<Point> winLine;
            bool win = board.CheckWin(r, c, out winLine);
            board.Grid[r, c] = 0;
            return win;
        }

        private static long EvaluatePoint(CaroBoard board, int r, int c, int player)
        {
            board.Grid[r, c] = player;
            long score = 0;

            int[][] directions = new int[][]
            {
                new int[] { 0, 1 },
                new int[] { 1, 0 },
                new int[] { 1, 1 },
                new int[] { 1, -1 }
            };

            int open3Count = 0;
            int blocked4Count = 0;

            foreach (var dir in directions)
            {
                int count;
                int openEnds;
                int patternScore = ScoreDirection(board, r, c, dir[0], dir[1], player, out count, out openEnds);
                score += patternScore;

                if (count == 3 && openEnds == 2) open3Count++;
                if (count == 4 && openEnds == 1) blocked4Count++;
            }

            // Bẫy đôi: Tạo ra 2 thế 3 mở (3-3) hoặc 1 thế 3 mở + 1 thế 4 chặn (3-4) -> Thế cờ sát thủ
            if (open3Count >= 2 || (open3Count >= 1 && blocked4Count >= 1))
            {
                score += SCORE_OPEN_FOUR;
            }

            board.Grid[r, c] = 0;
            return score;
        }

        private static int ScoreDirection(CaroBoard board, int r, int c, int dr, int dc, int player, out int count, out int openEnds)
        {
            int opponent = (player == 1) ? 2 : 1;
            count = 1;
            openEnds = 0;

            // Chiều tiến
            int rF = r + dr;
            int cF = c + dc;
            while (board.InBoard(rF, cF) && board.Grid[rF, cF] == player)
            {
                count++;
                rF += dr;
                cF += dc;
            }
            if (board.InBoard(rF, cF) && board.Grid[rF, cF] == 0)
                openEnds++;

            // Chiều lùi
            int rB = r - dr;
            int cB = c - dc;
            while (board.InBoard(rB, cB) && board.Grid[rB, cB] == player)
            {
                count++;
                rB -= dr;
                cB -= dc;
            }
            if (board.InBoard(rB, cB) && board.Grid[rB, cB] == 0)
                openEnds++;

            // Luật Caro Việt Nam: 5 quân bị đối thủ chặn 2 đầu không thắng
            if (board.Rule == GameRule.VietnameseCaro && count == 5)
            {
                bool headOpp = board.InBoard(rF, cF) && board.Grid[rF, cF] == opponent;
                bool tailOpp = board.InBoard(rB, cB) && board.Grid[rB, cB] == opponent;
                if (headOpp && tailOpp)
                    return 0;
            }

            if (count >= 5)
                return SCORE_WIN;

            if (openEnds == 0)
                return 0; // Bị chặn cả 2 đầu và < 5 quân thì vô nghĩa

            if (count == 4)
                return (openEnds == 2) ? SCORE_OPEN_FOUR : SCORE_BLOCKED_FOUR;

            if (count == 3)
                return (openEnds == 2) ? SCORE_OPEN_THREE : SCORE_BLOCKED_THREE;

            if (count == 2)
                return (openEnds == 2) ? SCORE_OPEN_TWO : SCORE_BLOCKED_TWO;

            return SCORE_ONE;
        }

        #endregion
    }
}

