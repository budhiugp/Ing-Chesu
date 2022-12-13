using UnityEngine;
using UnityEngine.Events;

public class PrefabBoardFloor : MonoBehaviour
{
    [SerializeField] private DataBoardFloor _csDataBoardFloor;
    private ManagerMovePiece _csManagerMovePiece;

    [SerializeField] private UnityEvent _uniEvTurnOnHighlight;
    [SerializeField] private UnityEvent _uniEvTurnOffHighlight;

    [SerializeField] private UnityEvent _uniEvTurnOnHistory;
    [SerializeField] private UnityEvent _uniEvTurnOffHistory;

    [SerializeField] private PrefabPiece _csPrefabPieceStepOn;

    public DataBoardFloor CsDataBoardFloor
    {
        set
        {
            _csDataBoardFloor = value;
        }
    }

    public ManagerMovePiece CsManagerMovePiece
    {
        set
        {
            _csManagerMovePiece = value;
        }
    }

    public PrefabPiece CsPrefabPieceStepOn
    {
        get
        {
            return _csPrefabPieceStepOn;
        }
    }

    public char CXIndex
    {
        get
        {
            return _csDataBoardFloor.CXIndex;
        }
    }

    public char CYIndex
    {
        get
        {
            return _csDataBoardFloor.CYIndex;
        }
    }

    public int IFile
    {
        get
        {
            return _csDataBoardFloor.IFile;
        }
    }

    public int IRank
    {
        get
        {
            return _csDataBoardFloor.IRank;
        }
    }

    public int IMoveValue
    {
        get
        {
            return _csDataBoardFloor.IMoveValue;
        }
    }

    public void SteppedOn(PrefabPiece csPrefabPiece)
    {
        _csPrefabPieceStepOn = csPrefabPiece;
    }

    public void SteppedOff()
    {
        _csPrefabPieceStepOn = null;
    }

    public void TurnOnHighlight()
    {
        _uniEvTurnOnHighlight.Invoke();
    }

    public void TurnOffHighlight()
    {
        _uniEvTurnOffHighlight.Invoke();
    }

    public void SelectFloor()
    {
        _csManagerMovePiece.SelectFloor(this);
    }

    public void TurnOnHistory()
    {
        _uniEvTurnOnHistory.Invoke();
    }

    public void TurnOffHistory()
    {
        _uniEvTurnOffHistory.Invoke();
    }

    public string DebugThis()
    {
        string s_issteppedon = (_csPrefabPieceStepOn == null) ? "Null" : _csPrefabPieceStepOn.CsDataPiece.DebugThis();
        return "_csDataBoardFloor : \n" + _csDataBoardFloor.DebugThis() + "\n_csPrefabPieceStepOn = " + s_issteppedon;
    }
}
