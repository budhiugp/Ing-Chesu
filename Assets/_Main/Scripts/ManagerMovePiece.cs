using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerMovePiece : MonoBehaviour
{
    [Header("Classes")]
    [SerializeField] private GeneratorBoardFloor _csGeneratorBoardFloor;
    [SerializeField] private GeneratorMovePiece _csGeneratorMovePiece;
    [SerializeField] private EliminatorPiece _csEliminatorPiece;
    [SerializeField] private CustomDebug _csCustomDebug;

    [Header("Temp")]
    private PrefabPiece _csPrefabPieceActive;
    private PrefabBoardFloor _csPrefabBoardFloorHistoryStart;
    private PrefabBoardFloor _csPrefabBoardFloorHistoryFinish;

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

    public void SelectFloor(PrefabBoardFloor csPrefabBoardFloor)
    {
        Debug.Log(_csCustomDebug.DebugColor(this.name + " SelectFloor") + " Begin : \ncsPrefabBoardFloor : " + csPrefabBoardFloor.DebugThis());

        if(csPrefabBoardFloor.CsPrefabPieceStepOn != null)
        {
            _csEliminatorPiece.EliminatePiece(csPrefabBoardFloor.CsPrefabPieceStepOn);
        }

        SetPrefabBoardHistory(csPrefabBoardFloor);

        _csPrefabPieceActive.MovePiece(csPrefabBoardFloor);

        ClearPrefabPieceActive();
        _csGeneratorMovePiece.ClearPrefabBoardFloorHighlight();
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
