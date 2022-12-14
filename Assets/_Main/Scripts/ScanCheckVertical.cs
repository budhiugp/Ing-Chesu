using UnityEngine;

public class ScanCheckVertical : ScanCheck
{
    public ScanCheckVertical(ManagerCheck csManagerCheck, GeneratorMovePiece csGeneratorMovePiece, GeneratorBoardFloor csGeneratorBoardFloor) : base(csManagerCheck, csGeneratorMovePiece, csGeneratorBoardFloor)
    {
    }

    private bool _isStill;

    public void ScanCheckDirection(int iFile, int iRank, bool isWhite)
    {
        //Debug.Log(this + " ScanCheckDirection Begin : \niFile = " + iFile + ", iRank = " + iRank + ", isWhite = " + isWhite);

        //Top
        _isStill = true;
        for (int i = 1; i <= 7; i++)
        {
            if (!_isStill || iRank + i > 7) break;
            ValidateCheck(iFile, iRank + i, isWhite, DataPiece.EnumMovementType.Vertical, SetIsStillToFalse);
        }

        //Down
        _isStill = true;
        for (int i = 1; i <= 7; i++)
        {
            if (!_isStill || iRank - i < 0) break;
            ValidateCheck(iFile, iRank - i, isWhite, DataPiece.EnumMovementType.Vertical, SetIsStillToFalse);
        }
    }

    private void SetIsStillToFalse()
    {
        _isStill = false;
    }
}
