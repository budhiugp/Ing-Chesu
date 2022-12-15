using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ManagerMovePiece : MonoBehaviour
{
    [Header("Repositories")]
    [SerializeField] private RepositoryUser _scrObjRepoUser;

    [Header("Classes")]
    [SerializeField] private GeneratorBoardFloor _csGeneratorBoardFloor;
    [SerializeField] private GeneratorMovePiece _csGeneratorMovePiece;
    [SerializeField] private EliminatorPiece _csEliminatorPiece;
    [SerializeField] private PromotionPiece _csPromotionPiece;
    [SerializeField] private ManagerCheck _csManagerCheck;
    [SerializeField] private BoardReferee _csBoardReferee;
    [SerializeField] private CustomDebug _csCustomDebug;

    [Header("Temp")]
    private PrefabPiece _csPrefabPieceActive;
    private PrefabPiece _csPrefabPieceMoving;
    private PrefabBoardFloor _csPrefabBoardFloorHistoryStart;
    private PrefabBoardFloor _csPrefabBoardFloorHistoryFinish;
    private PrefabPiece _csPrefabPiecePromoted;

    public void SelectPiece(PrefabPiece csPrefabPiece)
    {
        Debug.Log(_csCustomDebug.DebugColor(this.name + " SelectPiece") + " Begin : \ncsPrefabPiece : " + csPrefabPiece.CsDataPiece.DebugThis());

        if (_csPrefabPieceActive == csPrefabPiece)
        {
            ClearPrefabPieceActive();
            _csGeneratorMovePiece.ClearPrefabBoardFloorHighlight();
            return;
        }

        ClearPrefabPieceActive();

        csPrefabPiece.ActivatePiece();

        _csPrefabPieceActive = csPrefabPiece;

        _csGeneratorMovePiece.GenerateMovePiece(csPrefabPiece);
    }

    public void EliminatePiece(PrefabPiece csPrefabPiece)
    {
        _csEliminatorPiece.EliminatePiece(csPrefabPiece);
    }

    public void SelectFloor(PrefabBoardFloor csPrefabBoardFloor, PrefabBoardFloor.EnumSelectFloorType selectFloorType, UnityEvent uniEvAddon)
    {
        Debug.Log(_csCustomDebug.DebugColor(this.name + " SelectFloor") + " Begin : \ncsPrefabBoardFloor : " + csPrefabBoardFloor.DebugThis() + "\nselectFloorType = " + selectFloorType);

        switch (selectFloorType)
        {
            case PrefabBoardFloor.EnumSelectFloorType.Default:
                SelectFloorDefault(csPrefabBoardFloor);
                if (uniEvAddon != null) uniEvAddon.Invoke();
                break;
            case PrefabBoardFloor.EnumSelectFloorType.Castling:
                SelectFloorDefault(csPrefabBoardFloor);
                if (uniEvAddon != null) uniEvAddon.Invoke();
                break;
            case PrefabBoardFloor.EnumSelectFloorType.Promotion:
                SelectFloorDefault(csPrefabBoardFloor);
                _csPromotionPiece.DisplayPromotionPiece(csPrefabBoardFloor);
                if (uniEvAddon != null) uniEvAddon.Invoke();
                break;
            case PrefabBoardFloor.EnumSelectFloorType.EnPassantable:
                SelectFloorDefault(csPrefabBoardFloor);
                if (uniEvAddon != null) uniEvAddon.Invoke();
                break;
            case PrefabBoardFloor.EnumSelectFloorType.EnPassant:
                SelectFloorDefault(csPrefabBoardFloor);
                if (uniEvAddon != null) uniEvAddon.Invoke();
                break;
            default:

                break;
        }
    }

    private void SelectFloorDefault(PrefabBoardFloor csPrefabBoardFloor)
    {
        if (csPrefabBoardFloor.CsPrefabPieceStepOn != null)
        {
            _csEliminatorPiece.EliminatePiece(csPrefabBoardFloor.CsPrefabPieceStepOn);
        }

        SetPrefabBoardHistory(csPrefabBoardFloor);

        _csPrefabPieceMoving = _csPrefabPieceActive;

        _csPrefabPieceActive.MovePiece(csPrefabBoardFloor);

        ClearPrefabPieceActive();
        _csGeneratorMovePiece.ClearPrefabBoardFloorHighlight();
    }

    public void ResponseMovePiece()
    {
        Debug.Log("ResponseMovePiece i_file = " + _csPrefabPieceMoving.CsPrefabBoardFloorCurrent.IFile + ", i_rank = " + _csPrefabPieceMoving.CsPrefabBoardFloorCurrent.IRank);

        _csManagerCheck.LookCheck(_scrObjRepoUser.CsDataUserPlayer.IsWhite);

        _csBoardReferee.NextTurn();
    }

    private void ClearPrefabPieceActive()
    {
        if (_csPrefabPieceActive != null)
        {
            _csPrefabPieceActive.DeactivatePiece();
            _csPrefabPieceActive = null;
        }
    }

    private void SetPrefabBoardHistory(PrefabBoardFloor csPrefabBoardFloor)
    {
        if (_csPrefabBoardFloorHistoryStart != null) _csPrefabBoardFloorHistoryStart.TurnOffHistory();
        if (_csPrefabBoardFloorHistoryFinish != null) _csPrefabBoardFloorHistoryFinish.TurnOffHistory();

        _csPrefabBoardFloorHistoryStart = _csPrefabPieceActive.CsPrefabBoardFloorCurrent;
        _csPrefabBoardFloorHistoryFinish = csPrefabBoardFloor;

        _csPrefabBoardFloorHistoryStart.TurnOnHistory();
        _csPrefabBoardFloorHistoryFinish.TurnOnHistory();
    }
}
