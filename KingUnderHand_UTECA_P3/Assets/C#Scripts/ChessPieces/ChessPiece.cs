using UnityEngine;

public enum ChessPieceType
{
    Null = 0,
    Pawn = 1,
    Rook = 2,
    Knight = 3,
    Bishop = 4,
    Queen = 5,
}
public class ChessPiece : MonoBehaviour
{
    public int team;
    public int currentX;
    public int currentY;
    public ChessPieceType type;

    private Vector2 desiredPosition;
    private Vector2 desiredScale;

}
