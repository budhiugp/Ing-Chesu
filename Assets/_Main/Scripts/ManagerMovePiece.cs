using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerMovePiece : MonoBehaviour
{
    [Header("Classes")]
    [SerializeField] private GeneratorBoardFloor _csGeneratorBoardFloor;
    [SerializeField] private CustomDebug _csCustomDebug;

    [Header("Temp")]
    private PrefabPiece _csPrefabPieceActive;
    private List<PrefabBoardFloor> _listPrefabBoardFloorDestinationHighlight = new List<PrefabBoardFloor>();
    private PrefabBoardFloor _csPrefabBoardFloorHistoryStart;
    private PrefabBoardFloor _csPrefabBoardFloorHistoryFinish;

    public void HighlightFloor(PrefabPiece csPrefabPiece)
    {
        if (_csPrefabPieceActive == csPrefabPiece)
        {
            ClearPrefabPieceActive();
            ClearPrefabBoardFloorHighlight();
            return;
        }

        ClearPrefabPieceActive();
        ClearPrefabBoardFloorHighlight();

        csPrefabPiece.CsPrefabBoardFloorCurrent.SteppedActive();

        _csPrefabPieceActive = csPrefabPiece;

        foreach (PrefabBoardFloor cs_prefabboardfloor in _csGeneratorBoardFloor.ListPrefabBoardFloor)
        {
            if (cs_prefabboardfloor != csPrefabPiece.CsPrefabBoardFloorCurrent)
            {
                cs_prefabboardfloor.TurnOnHighlight();
                _listPrefabBoardFloorDestinationHighlight.Add(cs_prefabboardfloor);
            }
        }
    }

    public void ValidateEnemy(PrefabPiece csPrefabPiece)
    {
        //To Do Destroy Enemy

        SelectFloor(csPrefabPiece.CsPrefabBoardFloorCurrent);

        Destroy(csPrefabPiece.gameObject);
    }

    public void SelectFloor(PrefabBoardFloor csPrefabBoardFloor)
    {
        Debug.Log(_csCustomDebug.DebugColor(this.name + " SelectFloor") + " Begin : \ncsPrefabBoardFloor : " + csPrefabBoardFloor.DebugThis());

        if (_csPrefabPieceActive != null)
        {
            if (_csPrefabPieceActive.CsPrefabBoardFloorCurrent == csPrefabBoardFloor)
            {
                Debug.Log("Not Selected, You Can Not Move to Same Position");

                ClearPrefabPieceActive();
                ClearPrefabBoardFloorHighlight();
            }
            else
            {
                Debug.Log("Selected, _csPrefabBoardFloorCurrentHighlight is Not Null");

                SetPrefabBoardHistory(csPrefabBoardFloor);

                _csPrefabPieceActive.MovePiece(csPrefabBoardFloor);

                ClearPrefabPieceActive();
                ClearPrefabBoardFloorHighlight();
            }
        }
        else
        {
            Debug.Log("SelectFloor Skip, _csPrefabBoardFloorCurrentHighlight is Null");
        }
    }

    private void ClearPrefabPieceActive()
    {
        if (_csPrefabPieceActive != null)
        {
            _csPrefabPieceActive.CsPrefabBoardFloorCurrent.SteppedInactive();
            _csPrefabPieceActive = null;
        }
    }

    private void ClearPrefabBoardFloorHighlight()
    {
        foreach (PrefabBoardFloor cs_prefabboardfloor in _listPrefabBoardFloorDestinationHighlight)
        {
            cs_prefabboardfloor.TurnOffHighlight();
        }

        _listPrefabBoardFloorDestinationHighlight.Clear();
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
