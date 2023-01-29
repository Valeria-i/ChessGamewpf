﻿namespace ChessBoard
{
    public enum State
    {
        Empty,       // пусто
        WhiteKing,   // король
        WhiteQueen,  // ферзь
        WhiteRook,   // ладья
        WhiteKnight, // конь
        WhiteBishop, // слон
        WhitePawn,   // пешка
        BlackKing,
        BlackQueen,
        BlackRook,
        BlackKnight,
        BlackBishop,
        BlackPawn
    }
    /// <summary>
    /// Перечислим возможные цвета фигур
    /// </summary>
    public enum ColorFigure 
    {
        White,
        Black
    }
}