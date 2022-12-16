using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorMovePiece : MonoBehaviour
{
    [Header("Repositories")]
    [SerializeField] private RepositoryBoard _scrObjRepoBoard;

    [Header("Classes")]
    [SerializeField] private GeneratorBoardFloor _csGeneratorBoardFloor;
    [SerializeField] private ManagerCheck _csManagerCheck;
    [SerializeField] private CustomDebug _csCustomDebug;
    private MovePieceVertical _csMovePieceVertical;
    private MovePieceHorizontal _csMovePieceHorizontal;
    private MovePieceDiagonal _csMovePieceDiagonal;
    private MovePieceKnight _csMovePieceKnight;
    private MovePiecePawn _csMovePiecePawn;
    private MovePieceKing _csMovePieceKing;

    [Header("Temp")]
    [SerializeField] private List<PrefabBoardFloor> _listPrefabBoardFloorDestinationHighlight = new List<PrefabBoardFloor>();
    [SerializeField] private List<PrefabBoardFloor> _listPrefabBoardFloorSave = new List<PrefabBoardFloor>();
    [SerializeField] private List<PrefabBoardFloor> _listPrefabBoardFloorNotSave = new List<PrefabBoardFloor>();
    private bool _isStill;

    public ManagerCheck CsManagerCheck
    {
        get
        {
            return _csManagerCheck;
        }
    }

    private void Start()
    {
        _csMovePieceVertical = new MovePieceVertical(this, _csGeneratorBoardFloor);
        _csMovePieceHorizontal = new MovePieceHorizontal(this, _csGeneratorBoardFloor);
        _csMovePieceDiagonal = new MovePieceDiagonal(this, _csGeneratorBoardFloor);
        _csMovePieceKnight = new MovePieceKnight(this, _csGeneratorBoardFloor);
        _csMovePiecePawn = new MovePiecePawn(this, _csGeneratorBoardFloor);
        _csMovePieceKing = new MovePieceKing(this, _csGeneratorBoardFloor);
    }

    public void GenerateMovePiece(PrefabPiece csPrefabPiece)
    {
        //Debug.Log(_csCustomDebug.DebugColor(this.name + " GenerateMovePiece") + " Begin _csManagerCheck.ListDataCheck.Count = " + _csManagerCheck.ListDataCheck.Count);

        ClearPrefabBoardFloorHighlight();

        PrefabBoardFloor cs_prefabboardfloor_current = csPrefabPiece.CsPrefabBoardFloorCurrent;

        /*if (_csManagerCheck.ListDataCheck.Count == 0) //On Not Check
        {

        }
        else //On Check
        {
            //scan for available move (not affect on friend piece)

        }*/

        foreach (DataPiece.EnumMovementType enum_movement_type in csPrefabPiece.CsDataPiece.ListMovementType)
        {
            switch (enum_movement_type)
            { //vertical, horizontal, diagonal, knight, pawn, king
                case DataPiece.EnumMovementType.Vertical:
                    _csMovePieceVertical.GenerateMovePiece(cs_prefabboardfloor_current, csPrefabPiece);
                    break;
                case DataPiece.EnumMovementType.Horizontal:
                    _csMovePieceHorizontal.GenerateMovePiece(cs_prefabboardfloor_current, csPrefabPiece);
                    break;
                case DataPiece.EnumMovementType.Diagonal:
                    _csMovePieceDiagonal.GenerateMovePiece(cs_prefabboardfloor_current, csPrefabPiece);
                    break;
                case DataPiece.EnumMovementType.Knight:
                    _csMovePieceKnight.GenerateMovePiece(cs_prefabboardfloor_current, csPrefabPiece);
                    break;
                case DataPiece.EnumMovementType.Pawn:
                    _csMovePiecePawn.GenerateMovePiece(cs_prefabboardfloor_current, csPrefabPiece);
                    break;
                default: //King
                    _csMovePieceKing.GenerateMovePiece(cs_prefabboardfloor_current, csPrefabPiece);
                    break;
            }
        }
    }

    public void GenerateMovePieceSave(bool isWhiteTurn)
    {
        Debug.Log(_csCustomDebug.DebugColor(this.name + " GenerateMovePieceSave") + " Begin");

        _listPrefabBoardFloorSave.Clear();
        _listPrefabBoardFloorNotSave.Clear();

        if (isWhiteTurn) _csMovePieceKing.GenerateMovePieceSave(_csManagerCheck.CsPrefabPieceKingWhite);
        else _csMovePieceKing.GenerateMovePieceSave(_csManagerCheck.CsPrefabPieceKingBlack);
    }

    public void AddListPrefabBoardFloorSave(PrefabBoardFloor csPrefabBoardFloor)
    {
        if (!_listPrefabBoardFloorSave.Contains(csPrefabBoardFloor)) _listPrefabBoardFloorSave.Add(csPrefabBoardFloor);
    }

    public void AddListPrefabBoardFloorNotSave(PrefabBoardFloor csPrefabBoardFloor)
    {
        if (!_listPrefabBoardFloorNotSave.Contains(csPrefabBoardFloor)) _listPrefabBoardFloorNotSave.Add(csPrefabBoardFloor);
    }

    public void SetHighlightFloor(PrefabBoardFloor csPrefabBoardFloor)
    {
        Debug.LogWarning("SetHighlightFloor csPrefabBoardFloor = " + csPrefabBoardFloor.DebugThis());

        if (_scrObjRepoBoard.CsDataBoardGame.IsOnCheck)
        {
            //if csPrefabBoardFloor can block vertical scan, HighlightFloor(csPrefabBoardFloor);
            //scanforkingcheck
            foreach (DataCheck cs_datacheck in _csManagerCheck.ListDataCheck)
            {
                if (cs_datacheck.CsPrefabBoardFloor == csPrefabBoardFloor)
                {
                    HighlightFloor(csPrefabBoardFloor);
                }
            }
        }
        else
        {
            HighlightFloor(csPrefabBoardFloor);
        }
    }

    public void SetHighlightFloorKing(PrefabBoardFloor csPrefabBoardFloor)
    {
        //Debug.LogWarning("SetHighlightFloorKing csPrefabBoardFloor = " + csPrefabBoardFloor.DebugThis());

        //foreach(PrefabBoardFloor cs_prefabboardfloor in _listPrefabBoardFloorSave){
        //    if(cs_prefabboardfloor.IFile == csPrefabBoardFloor.IFile && cs_prefabboardfloor.IRank == csPrefabBoardFloor.IFile)
        //}

        if (_listPrefabBoardFloorSave.Contains(csPrefabBoardFloor))
        {
            HighlightFloor(csPrefabBoardFloor);
        }
    }

    private void HighlightFloor(PrefabBoardFloor csPrefabBoardFloor)
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
