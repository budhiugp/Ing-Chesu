using UnityEngine;

public class MovePieceHorizontal : MovePiece
{
    public MovePieceHorizontal(GeneratorMovePiece csGeneratorMovePiece, GeneratorBoardFloor csGeneratorBoardFloor) : base(csGeneratorMovePiece, csGeneratorBoardFloor)
    {
    }

    public void GenerateMovePiece(PrefabBoardFloor csPrefabBoardFloorCurrent, PrefabPiece csPrefabPiece)
    {
        //Debug.Log("MovePieceHorizontal GenerateMovePiece Begin : \ncsPrefabBoardFloorCurrent : \n" + csPrefabBoardFloorCurrent.DebugThis());

        int i_file = csPrefabBoardFloorCurrent.IFile;
        int i_rank = csPrefabBoardFloorCurrent.IRank;

        //Left
        _isStill = true;
        for (int i = 1; i <= 7; i++)
        {
            if (!_isStill || i_file - i < 0) break;
            ValidateFloor(i_file - i, i_rank, csPrefabPiece.CsDataPiece.isWhite);
        }

        //Right
        _isStill = true;
        for (int i = 1; i <= 7; i++)
        {
            if (!_isStill || i_file + i > 7) break;
            ValidateFloor(i_file + i, i_rank, csPrefabPiece.CsDataPiece.isWhite);
        }
    }
}

