using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorMovePiece : MonoBehaviour
{
    [Header("Classes")]
    [SerializeField] private GeneratorBoardFloor _csGeneratorBoardFloor;
    [SerializeField] private CustomDebug _csCustomDebug;

    [Header("Temp")]
    private List<PrefabBoardFloor> _listPrefabBoardFloorDestinationHighlight = new List<PrefabBoardFloor>();
    private bool _isStill;

    public void GenerateMovePiece(PrefabPiece csPrefabPiece)
    {
        Debug.Log(_csCustomDebug.DebugColor(this.name + " GenerateMovePiece") + " Begin");

        ClearPrefabBoardFloorHighlight();

        PrefabBoardFloor cs_prefabboardfloor_current = csPrefabPiece.CsPrefabBoardFloorCurrent;

        foreach (DataPiece.EnumMovementType enum_movement_type in csPrefabPiece.CsDataPiece.ListMovementType)
        {
            switch (enum_movement_type)
            { //vertical, horizontal, diagonal, knight, pawn, king
                case DataPiece.EnumMovementType.Vertical:
                    GenerateVerticalMovePiece(cs_prefabboardfloor_current, csPrefabPiece);
                    break;
                case DataPiece.EnumMovementType.Horizontal:
                    GenerateHorizontalMovePiece(cs_prefabboardfloor_current, csPrefabPiece);
                    break;
                case DataPiece.EnumMovementType.Diagonal:
                    GenerateDiagonalMovePiece(cs_prefabboardfloor_current, csPrefabPiece);
                    break;
                case DataPiece.EnumMovementType.Knight:
                    GenerateKnightMovePiece(cs_prefabboardfloor_current, csPrefabPiece);
                    break;
                case DataPiece.EnumMovementType.Pawn:
                    GeneratePawnMovePiece(cs_prefabboardfloor_current, csPrefabPiece);
                    break;
                default: //King
                    GenerateKingMovePiece(cs_prefabboardfloor_current, csPrefabPiece);
                    break;
            }
        }
    }

    private void GenerateVerticalMovePiece(PrefabBoardFloor csPrefabBoardFloorCurrent, PrefabPiece csPrefabPiece)
    {
        Debug.Log(_csCustomDebug.DebugColor(this.name + " GenerateVerticalMovePiece") + " Begin : \ncsPrefabBoardFloorCurrent : \n" + csPrefabBoardFloorCurrent.DebugThis());

        int i_file = csPrefabBoardFloorCurrent.IFile;
        int i_rank = csPrefabBoardFloorCurrent.IRank;

        //Top
        _isStill = true;
        for (int i = 1; i <= 7; i++)
        {
            if (!_isStill || i_rank + i > 7) break;
            ValidateFloorDefault(i_file, i_rank + i, csPrefabPiece.CsDataPiece.isWhite);
        }

        //Down
        _isStill = true;
        for (int i = 1; i <= 7; i++)
        {
            if (!_isStill || i_rank - i < 0) break;
            ValidateFloorDefault(i_file, i_rank - i, csPrefabPiece.CsDataPiece.isWhite);
        }
    }

    private void GenerateHorizontalMovePiece(PrefabBoardFloor csPrefabBoardFloorCurrent, PrefabPiece csPrefabPiece)
    {
        Debug.Log(_csCustomDebug.DebugColor(this.name + " GenerateHorizontalMovePiece") + " Begin : \ncsPrefabBoardFloorCurrent : \n" + csPrefabBoardFloorCurrent.DebugThis());

        int i_file = csPrefabBoardFloorCurrent.IFile;
        int i_rank = csPrefabBoardFloorCurrent.IRank;

        //Left
        _isStill = true;
        for (int i = 1; i <= 7; i++)
        {
            if (!_isStill || i_file - i < 0) break;
            ValidateFloorDefault(i_file - i, i_rank, csPrefabPiece.CsDataPiece.isWhite);
        }

        //Right
        _isStill = true;
        for (int i = 1; i <= 7; i++)
        {
            if (!_isStill || i_file + i > 7) break;
            ValidateFloorDefault(i_file + i, i_rank, csPrefabPiece.CsDataPiece.isWhite);
        }
    }

    private void GenerateDiagonalMovePiece(PrefabBoardFloor csPrefabBoardFloorCurrent, PrefabPiece csPrefabPiece)
    {
        Debug.Log(_csCustomDebug.DebugColor(this.name + " GenerateDiagonalMovePiece") + " Begin : \ncsPrefabBoardFloorCurrent : \n" + csPrefabBoardFloorCurrent.DebugThis());

        int i_file = csPrefabBoardFloorCurrent.IFile;
        int i_rank = csPrefabBoardFloorCurrent.IRank;

        //Top Left
        _isStill = true;
        for (int i = 1; i <= 7; i++)
        {
            if (!_isStill || i_file - i < 0 || i_rank + i > 7) break;
            ValidateFloorDefault(i_file - i, i_rank + i, csPrefabPiece.CsDataPiece.isWhite);
        }

        //Top Right
        _isStill = true;
        for (int i = 1; i <= 7; i++)
        {
            if (!_isStill || i_file + i > 7 || i_rank + i > 7) break;
            ValidateFloorDefault(i_file + i, i_rank + i, csPrefabPiece.CsDataPiece.isWhite);
        }

        //Down Left
        _isStill = true;
        for (int i = 1; i <= 7; i++)
        {
            if (!_isStill || i_file - i < 0 || i_rank - i < 0) break;
            ValidateFloorDefault(i_file - i, i_rank - i, csPrefabPiece.CsDataPiece.isWhite);
        }

        //Down Right
        _isStill = true;
        for (int i = 1; i <= 7; i++)
        {
            if (!_isStill || i_file + i > 7 || i_rank - i < 0) break;
            ValidateFloorDefault(i_file + i, i_rank - i, csPrefabPiece.CsDataPiece.isWhite);
        }
    }

    private void GenerateKnightMovePiece(PrefabBoardFloor csPrefabBoardFloorCurrent, PrefabPiece csPrefabPiece)
    {
        Debug.Log(_csCustomDebug.DebugColor(this.name + " GenerateKnightMovePiece") + " Begin : \ncsPrefabBoardFloorCurrent : \n" + csPrefabBoardFloorCurrent.DebugThis());

        int i_file = csPrefabBoardFloorCurrent.IFile;
        int i_rank = csPrefabBoardFloorCurrent.IRank;

        //Top Left 1
        if (i_file - 1 >= 0 && i_rank + 2 <= 7) ValidateFloorDefault(i_file - 1, i_rank + 2, csPrefabPiece.CsDataPiece.isWhite);

        //Top Left 2
        if (i_file - 2 >= 0 && i_rank + 1 <= 7) ValidateFloorDefault(i_file - 2, i_rank + 1, csPrefabPiece.CsDataPiece.isWhite);

        //Top Right 1
        if (i_file + 1 <= 7 && i_rank + 2 <= 7) ValidateFloorDefault(i_file + 1, i_rank + 2, csPrefabPiece.CsDataPiece.isWhite);

        //Top Right 2
        if (i_file + 2 <= 7 && i_rank + 1 <= 7) ValidateFloorDefault(i_file + 2, i_rank + 1, csPrefabPiece.CsDataPiece.isWhite);

        //Down Left 1
        if (i_file - 1 >= 0 && i_rank - 2 >= 0) ValidateFloorDefault(i_file - 1, i_rank - 2, csPrefabPiece.CsDataPiece.isWhite);

        //Down Left 2
        if (i_file - 2 >= 0 && i_rank - 1 >= 0) ValidateFloorDefault(i_file - 2, i_rank - 1, csPrefabPiece.CsDataPiece.isWhite);

        //Down Left 1
        if (i_file + 1 <= 7 && i_rank - 2 >= 0) ValidateFloorDefault(i_file + 1, i_rank - 2, csPrefabPiece.CsDataPiece.isWhite);

        //Down Left 2
        if (i_file + 2 <= 7 && i_rank - 1 >= 0) ValidateFloorDefault(i_file + 2, i_rank - 1, csPrefabPiece.CsDataPiece.isWhite);
    }

    private void GeneratePawnMovePiece(PrefabBoardFloor csPrefabBoardFloorCurrent, PrefabPiece csPrefabPiece)
    {
        Debug.Log(_csCustomDebug.DebugColor(this.name + " GeneratePawnMovePiece") + " Begin : \ncsPrefabBoardFloorCurrent : \n" + csPrefabBoardFloorCurrent.DebugThis() + "\nIsOnFirstFloor = " + csPrefabPiece.IsOnFirstFloor);

        int i_maxstep;

        int i_file = csPrefabBoardFloorCurrent.IFile;
        int i_rank = csPrefabBoardFloorCurrent.IRank;

        if (csPrefabPiece.IsOnFirstFloor) i_maxstep = 2;
        else i_maxstep = 1;

        //Top/Down
        _isStill = true;
        if (csPrefabPiece.CsDataPiece.isWhite)
        {
            for (int i = 1; i <= i_maxstep; i++)
            {
                if(!_isStill) break;
                if (i_rank + i <= 7) ValidateFloorB(i_file, i_rank + i);
            }
        }
        else
        {
            for (int i = 1; i <= i_maxstep; i++)
            {
                if(!_isStill) break;
                if (i_rank - i >= 0) ValidateFloorB(i_file, i_rank - i);
            }
        }

        //Top/Down Left
        if (csPrefabPiece.CsDataPiece.isWhite)
        {
            if (i_file - 1 >= 0 && i_rank + 1 <= 7) ValidateFloorA(i_file - 1, i_rank + 1, csPrefabPiece.CsDataPiece.isWhite);
        }
        else
        {
            if (i_file - 1 >= 0 && i_rank - 1 >= 0) ValidateFloorA(i_file - 1, i_rank - 1, csPrefabPiece.CsDataPiece.isWhite);
        }

        //Top/Down Right
        if (csPrefabPiece.CsDataPiece.isWhite)
        {
            if (i_file + 1 <= 7 && i_rank + 1 <= 7) ValidateFloorA(i_file + 1, i_rank + 1, csPrefabPiece.CsDataPiece.isWhite);
        }
        else
        {
            if (i_file + 1 <= 7 && i_rank - 1 >= 0) ValidateFloorA(i_file + 1, i_rank - 1, csPrefabPiece.CsDataPiece.isWhite);
        }
    }

    private void GenerateKingMovePiece(PrefabBoardFloor csPrefabBoardFloorCurrent, PrefabPiece csPrefabPiece)
    {
        Debug.Log(_csCustomDebug.DebugColor(this.name + " GenerateKingMovePiece") + " Begin : \ncsPrefabBoardFloorCurrent : \n" + csPrefabBoardFloorCurrent.DebugThis() + "\nIsOnFirstFloor = " + csPrefabPiece.IsOnFirstFloor);

        int i_maxstep;

        int i_file = csPrefabBoardFloorCurrent.IFile;
        int i_rank = csPrefabBoardFloorCurrent.IRank;

        if (csPrefabPiece.IsOnFirstFloor) i_maxstep = 2; //To Do Swap with Rook
        else i_maxstep = 1;

        //Top
        if (i_rank + 1 <= 7) ValidateFloorC(i_file, i_rank + 1);

        //Down
        if (i_rank - 1 >= 0) ValidateFloorC(i_file, i_rank - 1);

        //Left
        if (i_file - 1 >= 0) ValidateFloorC(i_file - 1, i_rank);

        //Right
        if (i_file + 1 <= 7) ValidateFloorC(i_file + 1, i_rank);

        //Top Left
        if (i_file - 1 >= 0 && i_rank + 1 <= 7) ValidateFloorC(i_file - 1, i_rank + 1);

        //Top Right
        if (i_file + 1 <= 7 && i_rank + 1 <= 7) ValidateFloorC(i_file + 1, i_rank + 1);

        //Down Left
        if (i_file - 1 >= 0 && i_rank - 1 >= 0) ValidateFloorC(i_file - 1, i_rank - 1);

        //Down Right
        if (i_file + 1 <= 7 && i_rank - 1 >= 0) ValidateFloorC(i_file + 1, i_rank - 1);
    }

    private void ValidateFloorDefault(int iFile, int iRank, bool isWhite) //Default
    {
        PrefabBoardFloor cs_prefabboardfloor = _csGeneratorBoardFloor.GetPrefabBoardFloorByFileNRank(iFile, iRank);

        if (cs_prefabboardfloor.CsPrefabPieceStepOn == null)
        {
            SetHighlightFloor(cs_prefabboardfloor);
        }
        else
        {
            if (cs_prefabboardfloor.CsPrefabPieceStepOn.CsDataPiece.isWhite != isWhite)
            {
                SetHighlightFloor(cs_prefabboardfloor);
            }

            _isStill = false;
        }
    }

    private void ValidateFloorA(int iFile, int iRank, bool isWhite) //Pawn Diagonal
    {
        PrefabBoardFloor cs_prefabboardfloor = _csGeneratorBoardFloor.GetPrefabBoardFloorByFileNRank(iFile, iRank);

        if (cs_prefabboardfloor.CsPrefabPieceStepOn != null)
        {
            if (cs_prefabboardfloor.CsPrefabPieceStepOn.CsDataPiece.isWhite != isWhite)
            {
                SetHighlightFloor(cs_prefabboardfloor);
            }
        }
    }

    private void ValidateFloorB(int iFile, int iRank) //Pawn Front
    {
        PrefabBoardFloor cs_prefabboardfloor = _csGeneratorBoardFloor.GetPrefabBoardFloorByFileNRank(iFile, iRank);

        if (cs_prefabboardfloor.CsPrefabPieceStepOn == null)
        {
            SetHighlightFloor(cs_prefabboardfloor);
        }
        else
        {
            _isStill = false;
        }
    }

    private void ValidateFloorC(int iFile, int iRank) //King
    {
        PrefabBoardFloor cs_prefabboardfloor = _csGeneratorBoardFloor.GetPrefabBoardFloorByFileNRank(iFile, iRank);

        if (cs_prefabboardfloor.CsPrefabPieceStepOn == null)
        {
            SetHighlightFloor(cs_prefabboardfloor);
        }
    }

    private void SetHighlightFloor(PrefabBoardFloor csPrefabBoardFloor)
    {
        csPrefabBoardFloor.TurnOnHighlight();

        _listPrefabBoardFloorDestinationHighlight.Add(csPrefabBoardFloor);
    }

    public void ClearPrefabBoardFloorHighlight()
    {
        foreach (PrefabBoardFloor cs_prefabboardfloor in _listPrefabBoardFloorDestinationHighlight)
        {
            cs_prefabboardfloor.TurnOffHighlight();
        }

        _listPrefabBoardFloorDestinationHighlight.Clear();
    }
}
