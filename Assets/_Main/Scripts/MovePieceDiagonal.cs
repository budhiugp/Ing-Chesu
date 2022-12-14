using UnityEngine;

public class MovePieceDiagonal : MovePiece
{
    public MovePieceDiagonal(GeneratorMovePiece csGeneratorMovePiece, GeneratorBoardFloor csGeneratorBoardFloor) : base(csGeneratorMovePiece, csGeneratorBoardFloor)
    {
    }

    public void GenerateMovePiece(PrefabBoardFloor csPrefabBoardFloorCurrent, PrefabPiece csPrefabPiece)
    {
        Debug.Log("MovePieceDiagonal GenerateMovePiece Begin : \ncsPrefabBoardFloorCurrent : \n" + csPrefabBoardFloorCurrent.DebugThis());

        int i_file = csPrefabBoardFloorCurrent.IFile;
        int i_rank = csPrefabBoardFloorCurrent.IRank;

        //Top Left
        _isStill = true;
        for (int i = 1; i <= 7; i++)
        {
            if (!_isStill || i_file - i < 0 || i_rank + i > 7) break;
            ValidateFloor(i_file - i, i_rank + i, csPrefabPiece.CsDataPiece.isWhite);
        }

        //Top Right
        _isStill = true;
        for (int i = 1; i <= 7; i++)
        {
            if (!_isStill || i_file + i > 7 || i_rank + i > 7) break;
            ValidateFloor(i_file + i, i_rank + i, csPrefabPiece.CsDataPiece.isWhite);
        }

        //Down Left
        _isStill = true;
        for (int i = 1; i <= 7; i++)
        {
            if (!_isStill || i_file - i < 0 || i_rank - i < 0) break;
            ValidateFloor(i_file - i, i_rank - i, csPrefabPiece.CsDataPiece.isWhite);
        }

        //Down Right
        _isStill = true;
        for (int i = 1; i <= 7; i++)
        {
            if (!_isStill || i_file + i > 7 || i_rank - i < 0) break;
            ValidateFloor(i_file + i, i_rank - i, csPrefabPiece.CsDataPiece.isWhite);
        }
    }
}

