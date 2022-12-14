using UnityEngine;

public class MovePieceKnight : MovePiece
{
    public MovePieceKnight(GeneratorMovePiece csGeneratorMovePiece, GeneratorBoardFloor csGeneratorBoardFloor) : base(csGeneratorMovePiece, csGeneratorBoardFloor)
    {
    }

    public void GenerateMovePiece(PrefabBoardFloor csPrefabBoardFloorCurrent, PrefabPiece csPrefabPiece)
    {
        Debug.Log("MovePieceKnight GenerateMovePiece Begin : \ncsPrefabBoardFloorCurrent : \n" + csPrefabBoardFloorCurrent.DebugThis());

        int i_file = csPrefabBoardFloorCurrent.IFile;
        int i_rank = csPrefabBoardFloorCurrent.IRank;

        //Top Left 1
        if (i_file - 1 >= 0 && i_rank + 2 <= 7) ValidateFloor(i_file - 1, i_rank + 2, csPrefabPiece.CsDataPiece.isWhite);

        //Top Left 2
        if (i_file - 2 >= 0 && i_rank + 1 <= 7) ValidateFloor(i_file - 2, i_rank + 1, csPrefabPiece.CsDataPiece.isWhite);

        //Top Right 1
        if (i_file + 1 <= 7 && i_rank + 2 <= 7) ValidateFloor(i_file + 1, i_rank + 2, csPrefabPiece.CsDataPiece.isWhite);

        //Top Right 2
        if (i_file + 2 <= 7 && i_rank + 1 <= 7) ValidateFloor(i_file + 2, i_rank + 1, csPrefabPiece.CsDataPiece.isWhite);

        //Down Left 1
        if (i_file - 1 >= 0 && i_rank - 2 >= 0) ValidateFloor(i_file - 1, i_rank - 2, csPrefabPiece.CsDataPiece.isWhite);

        //Down Left 2
        if (i_file - 2 >= 0 && i_rank - 1 >= 0) ValidateFloor(i_file - 2, i_rank - 1, csPrefabPiece.CsDataPiece.isWhite);

        //Down Left 1
        if (i_file + 1 <= 7 && i_rank - 2 >= 0) ValidateFloor(i_file + 1, i_rank - 2, csPrefabPiece.CsDataPiece.isWhite);

        //Down Left 2
        if (i_file + 2 <= 7 && i_rank - 1 >= 0) ValidateFloor(i_file + 2, i_rank - 1, csPrefabPiece.CsDataPiece.isWhite);
    }
}

