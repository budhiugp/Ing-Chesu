using UnityEngine;
using UnityEngine.Events;

public class PrefabBoardFloor : MonoBehaviour
{
    public enum EnumSelectFloorType { Default, Castling, Promotion, EnPassantable, EnPassant }
    public EnumSelectFloorType SelectFloorType;

    [SerializeField] private DataBoardFloor _csDataBoardFloor;
    private ManagerMovePiece _csManagerMovePiece;

    [SerializeField] private UnityEvent _uniEvTurnOnHighlight;
    [SerializeField] private UnityEvent _uniEvTurnOffHighlight;

    [SerializeField] private UnityEvent _uniEvTurnOnHistory;
    [SerializeField] private UnityEvent _uniEvTurnOffHistory;

    [SerializeField] private PrefabPiece _csPrefabPieceStepOn;

    private UnityEvent _uniEvAddon = new UnityEvent();

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
        _csManagerMovePiece.SelectFloor(this, SelectFloorType, _uniEvAddon);
    }

    private void ResetSelectFloorType()
    {
        SelectFloorType = EnumSelectFloorType.Default;

        _uniEvAddon.RemoveAllListeners();
    }

    public void SetFloorDefault()
    {
        Debug.LogWarning("SetFloorDefault Call");

        SelectFloorType = EnumSelectFloorType.Default;

        _uniEvAddon.AddListener(delegate
        {
            Debug.LogWarning("SetFloorDefault _uniEvAddon.AddListener _csPrefabPieceStepOn.IsEnPassantable = " + _csPrefabPieceStepOn.IsEnPassantable);

            _csPrefabPieceStepOn.IsEnPassantable = false;
            
            ResetSelectFloorType();
        });
    }

    public void SetFloorCastling(PrefabPiece csPrefabPiece, PrefabBoardFloor csPrefabBoardFloor)
    {
        SelectFloorType = EnumSelectFloorType.Castling;

        _uniEvAddon.AddListener(delegate
        {
            csPrefabPiece.MovePiece(csPrefabBoardFloor);

            ResetSelectFloorType();
        });
    }

    public void SetFloorPromotion()
    {
        SelectFloorType = EnumSelectFloorType.Promotion;

        _uniEvAddon.AddListener(delegate
        {
            ResetSelectFloorType();
        });
    }

    public void SetFloorEnPassantable()
    {
        SelectFloorType = EnumSelectFloorType.EnPassantable;

        _uniEvAddon.AddListener(delegate
        {
            _csPrefabPieceStepOn.IsEnPassantable = true;

            ResetSelectFloorType();
        });
    }

    public void SetFloorEnPassant(PrefabBoardFloor csPrefabBoardFloor)
    {
        SelectFloorType = EnumSelectFloorType.EnPassant;

        _uniEvAddon.AddListener(delegate
        {
            _csManagerMovePiece.EliminatePiece(csPrefabBoardFloor.CsPrefabPieceStepOn);
            csPrefabBoardFloor.SteppedOff();

            ResetSelectFloorType();
        });
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
