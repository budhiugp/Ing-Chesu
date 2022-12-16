using System;
using UnityEngine;

public class ScanCheckVertical : ScanCheck
{
    public ScanCheckVertical(ManagerCheck csManagerCheck, GeneratorMovePiece csGeneratorMovePiece, GeneratorBoardFloor csGeneratorBoardFloor) : base(csManagerCheck, csGeneratorMovePiece, csGeneratorBoardFloor)
    {
    }
    
    private bool _isStill;
    private bool _isStillSave;
    private bool _isReturn;

    public void ScanCheckDirection(int iFile, int iRank, bool isWhiteKing)
    {
        //Debug.Log(this + " ScanCheckDirection Begin : \niFile = " + iFile + ", iRank = " + iRank + ", isWhiteKing = " + isWhiteKing);

        //ValidateCheck(iFile, iRank, isWhiteKing, DataPiece.EnumMovementType.Vertical, SetIsStillToFalse);

        //Top
        _isStill = true;
        for (int i = 1; i <= 7; i++)
        {
            if (!_isStill || iRank + i > 7) break;
            ValidateCheck(iFile, iRank + i, isWhiteKing, DataPiece.EnumMovementType.Vertical, SetIsStillToFalse);
        }

        //Down
        _isStill = true;
        for (int i = 1; i <= 7; i++)
        {
            if (!_isStill || iRank - i < 0) break;
            ValidateCheck(iFile, iRank - i, isWhiteKing, DataPiece.EnumMovementType.Vertical, SetIsStillToFalse);
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

        //Top
        _isStillSave = true;
        for (int i = 1; i <= 7; i++)
        {
            if (!_isStillSave || i_rank + i > 7) break;
            if(_isReturn) return;
            ValidateCheckSave(i_file, i_rank + i, isWhiteKing, DataPiece.EnumMovementType.Vertical, SetIsStillSaveToFalse, SetIsReturn, csPrefabBoardFloor);
        }

        //Down
        _isStillSave = true;
        for (int i = 1; i <= 7; i++)
        {
            if (!_isStillSave || i_rank - i < 0) break;
            if(_isReturn) return;
            ValidateCheckSave(i_file, i_rank - i, isWhiteKing, DataPiece.EnumMovementType.Vertical, SetIsStillSaveToFalse, SetIsReturn, csPrefabBoardFloor);
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
