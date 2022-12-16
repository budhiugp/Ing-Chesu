using UnityEngine;

public class ScanCheckHorizontal : ScanCheck
{
    public ScanCheckHorizontal(ManagerCheck csManagerCheck, GeneratorMovePiece csGeneratorMovePiece, GeneratorBoardFloor csGeneratorBoardFloor) : base(csManagerCheck, csGeneratorMovePiece, csGeneratorBoardFloor)
    {
    }

    private bool _isStill;
    private bool _isStillSave;
    private bool _isReturn;

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

    public void ScanCheckDirectionSave(PrefabBoardFloor csPrefabBoardFloor, bool isWhiteKing)
    {
        int i_file = csPrefabBoardFloor.IFile;
        int i_rank = csPrefabBoardFloor.IRank;

        _isReturn = false;

        //Left
        _isStill = true;
        for (int i = 1; i <= 7; i++)
        {
            if (!_isStillSave || i_file - i < 0) break;
            if(_isReturn) return;
            ValidateCheckSave(i_file - i, i_rank, isWhiteKing, DataPiece.EnumMovementType.Horizontal, SetIsStillSaveToFalse, SetIsReturn, csPrefabBoardFloor);
        }

        //Right
        _isStill = true;
        for (int i = 1; i <= 7; i++)
        {
            if (!_isStillSave || i_file + i > 7) break;
            if(_isReturn) return;
            ValidateCheckSave(i_file + i, i_rank, isWhiteKing, DataPiece.EnumMovementType.Horizontal, SetIsStillSaveToFalse, SetIsReturn, csPrefabBoardFloor);
        }
    }

    private void SetIsStillSaveToFalse()
    {
        _isStillSave = false;
    }

    private void SetIsReturn()
    {
        _isReturn = true;
    }
}



