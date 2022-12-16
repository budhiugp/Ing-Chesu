using UnityEngine;

public class ScanCheckKnight : ScanCheck
{
    public ScanCheckKnight(ManagerCheck csManagerCheck, GeneratorMovePiece csGeneratorMovePiece, GeneratorBoardFloor csGeneratorBoardFloor) : base(csManagerCheck, csGeneratorMovePiece, csGeneratorBoardFloor)
    {
    }

    public void ScanCheckDirection(int iFile, int iRank, bool isWhite)
    {
        //Debug.Log(this + " ScanCheckDirection Begin : \niFile = " + iFile + ", iRank = " + iRank + ", isWhite, DataPiece.EnumMovementType.Knight, null = " + isWhite, DataPiece.EnumMovementType.Knight, null);

        //Top Left 1
        if (iFile - 1 >= 0 && iRank + 2 <= 7) ValidateCheck(iFile - 1, iRank + 2, isWhite, DataPiece.EnumMovementType.Knight, SetIsStillToFalse);

        //Top Left 2
        if (iFile - 2 >= 0 && iRank + 1 <= 7) ValidateCheck(iFile - 2, iRank + 1, isWhite, DataPiece.EnumMovementType.Knight, SetIsStillToFalse);

        //Top Right 1
        if (iFile + 1 <= 7 && iRank + 2 <= 7) ValidateCheck(iFile + 1, iRank + 2, isWhite, DataPiece.EnumMovementType.Knight, SetIsStillToFalse);

        //Top Right 2
        if (iFile + 2 <= 7 && iRank + 1 <= 7) ValidateCheck(iFile + 2, iRank + 1, isWhite, DataPiece.EnumMovementType.Knight, SetIsStillToFalse);

        //Down Left 1
        if (iFile - 1 >= 0 && iRank - 2 >= 0) ValidateCheck(iFile - 1, iRank - 2, isWhite, DataPiece.EnumMovementType.Knight, SetIsStillToFalse);

        //Down Left 2
        if (iFile - 2 >= 0 && iRank - 1 >= 0) ValidateCheck(iFile - 2, iRank - 1, isWhite, DataPiece.EnumMovementType.Knight, SetIsStillToFalse);

        //Down Left 1
        if (iFile + 1 <= 7 && iRank - 2 >= 0) ValidateCheck(iFile + 1, iRank - 2, isWhite, DataPiece.EnumMovementType.Knight, SetIsStillToFalse);

        //Down Left 2
        if (iFile + 2 <= 7 && iRank - 1 >= 0) ValidateCheck(iFile + 2, iRank - 1, isWhite, DataPiece.EnumMovementType.Knight, SetIsStillToFalse);
    }

    private void SetIsStillToFalse()
    {
        //Null
    }
}

