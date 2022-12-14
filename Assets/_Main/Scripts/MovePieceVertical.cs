using UnityEngine;

public class MovePieceVertical : MovePiece
{
    public MovePieceVertical(GeneratorMovePiece csGeneratorMovePiece, GeneratorBoardFloor csGeneratorBoardFloor) : base(csGeneratorMovePiece, csGeneratorBoardFloor)
    {
    }

    public void GenerateMovePiece(PrefabBoardFloor csPrefabBoardFloorCurrent, PrefabPiece csPrefabPiece)
    {
        //Debug.Log("MovePieceVertical GenerateMovePiece Begin : \ncsPrefabBoardFloorCurrent : \n" + csPrefabBoardFloorCurrent.DebugThis());

        int i_file = csPrefabBoardFloorCurrent.IFile;
        int i_rank = csPrefabBoardFloorCurrent.IRank;

        //Top
        _isStill = true;
        for (int i = 1; i <= 7; i++)
        {
            if (!_isStill || i_rank + i > 7) break;
            ValidateFloor(i_file, i_rank + i, csPrefabPiece.CsDataPiece.isWhite);
        }

        //Down
        _isStill = true;
        for (int i = 1; i <= 7; i++)
        {
            if (!_isStill || i_rank - i < 0) break;
            ValidateFloor(i_file, i_rank - i, csPrefabPiece.CsDataPiece.isWhite);
        }
    }
}
