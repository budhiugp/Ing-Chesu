using UnityEngine;

public class ScanCheckHorizontal : ScanCheck
{
    public ScanCheckHorizontal(ManagerCheck csManagerCheck, GeneratorMovePiece csGeneratorMovePiece, GeneratorBoardFloor csGeneratorBoardFloor) : base(csManagerCheck, csGeneratorMovePiece, csGeneratorBoardFloor)
    {
    }

    private bool _isStill;

    public void ScanCheckDirection(int iFile, int iRank, bool isWhite)
    {
        //Debug.Log(this + " ScanCheckDirection Begin : \niFile = " + iFile + ", iRank = " + iRank + ", isWhite = " + isWhite);

        //Left
        _isStill = true;
        for (int i = 1; i <= 7; i++)
        {
            if (!_isStill || iFile - i < 0) break;
            ValidateCheck(iFile - i, iRank, isWhite, DataPiece.EnumMovementType.Horizontal, SetIsStillToFalse);
        }

        //Right
        _isStill = true;
        for (int i = 1; i <= 7; i++)
        {
            if (!_isStill || iFile + i > 7) break;
            ValidateCheck(iFile + i, iRank, isWhite, DataPiece.EnumMovementType.Horizontal, SetIsStillToFalse);
        }
    }

    private void SetIsStillToFalse()
    {
        _isStill = false;
    }
}



