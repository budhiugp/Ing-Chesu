public class ScanCheckDiagonal : ScanCheck
{
    public ScanCheckDiagonal(ManagerCheck csManagerCheck, GeneratorMovePiece csGeneratorMovePiece, GeneratorBoardFloor csGeneratorBoardFloor) : base(csManagerCheck, csGeneratorMovePiece, csGeneratorBoardFloor)
    {
    }

    private bool _isStill;

    public void ScanCheckDirection(int iFile, int iRank, bool isWhite)
    {
        //Top Left
        _isStill = true;
        for (int i = 1; i <= 7; i++)
        {
            if (!_isStill || iFile - i < 0 || iRank + i > 7) break;
            ValidateCheck(iFile - i, iRank + i, isWhite, DataPiece.EnumMovementType.Diagonal, SetIsStillToFalse);
        }

        //Top Right
        _isStill = true;
        for (int i = 1; i <= 7; i++)
        {
            if (!_isStill || iFile + i > 7 || iRank + i > 7) break;
            ValidateCheck(iFile + i, iRank + i, isWhite, DataPiece.EnumMovementType.Diagonal, SetIsStillToFalse);
        }

        //Down Left
        _isStill = true;
        for (int i = 1; i <= 7; i++)
        {
            if (!_isStill || iFile - i < 0 || iRank - i < 0) break;
            ValidateCheck(iFile - i, iRank - i, isWhite, DataPiece.EnumMovementType.Diagonal, SetIsStillToFalse);
        }

        //Down Right
        _isStill = true;
        for (int i = 1; i <= 7; i++)
        {
            if (!_isStill || iFile + i > 7 || iRank - i < 0) break;
            ValidateCheck(iFile + i, iRank - i, isWhite, DataPiece.EnumMovementType.Diagonal, SetIsStillToFalse);
        }
    }

    private void SetIsStillToFalse()
    {
        _isStill = false;
    }
}

