using System;

namespace Tic_Tac_toe_1
{
    public enum CellState
    {
        Empty = 0,
        Player1 = 1, // X
        Player2 = 2  // O (hoặc Máy)
    }

    public enum AIMode
    {
        Easy = 0,
        Medium = 1,
        Hard = 2
    }

    public enum GameRule
    {
        VietnameseCaro = 0, // 5 quân liên tiếp, bị chặn 2 đầu bởi quân đối phương thì KHÔNG thắng
        FreeGomoku = 1      // 5 quân liên tiếp bất kỳ (kể cả bị chặn) là thắng
    }

    public enum GameMode
    {
        PvP = 0, // 2 Người chơi
        PvE = 1  // Người chơi với Máy
    }

    public enum FirstTurn
    {
        Player1 = 0, // X đi trước
        Player2 = 1  // O (Máy) đi trước
    }
}

