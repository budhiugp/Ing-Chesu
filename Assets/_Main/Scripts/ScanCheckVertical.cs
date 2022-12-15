using System;
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

    public void ScanCheckDirectionSave(PrefabBoardFloor csPrefabBoardFloor, bool isWhite)
    {
        /*
        Debug.Log(this + " ScanCheckDirectionSave Begin : \ncsPrefabBoardFloor : \n" + csPrefabBoardFloor.DebugThis() + ", isWhite = " + isWhite);
    
        int i_file = csPrefabBoardFloor.IFile;
        int i_rank = csPrefabBoardFloor.IRank;

        //Top
        _isStill = true;
        for (int i = 1; i <= 7; i++)
        {
            if (!_isStill || i_rank + i > 7) break;
            ValidateCheckSave(i_file, i_rank + i, isWhite, DataPiece.EnumMovementType.Vertical, SetIsStillToFalse, csPrefabBoardFloor);
        }

        //Down
        _isStill = true;
        for (int i = 1; i <= 7; i++)
        {
            if (!_isStill || i_rank - i < 0) break;
            ValidateCheckSave(i_file, i_rank - i, isWhite, DataPiece.EnumMovementType.Vertical, SetIsStillToFalse, csPrefabBoardFloor);
        }
        */
    }

    private void SetIsStillToFalse()
    {
        _isStill = false;
    }
}
