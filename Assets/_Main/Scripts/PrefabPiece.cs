using UnityEngine;

public class PrefabPiece : MonoBehaviour
{
    [SerializeField] private DataPiece _csDataPiece;

    [SerializeField] private Color _colorFlickerWhite = Color.blue;
    [SerializeField] private Color _colorFlickerBlack = Color.red;

    private bool _isOnFirstFloor;

    [SerializeField] private PrefabBoardFloor _csPrefabBoardFloorCurrent;

    private ManagerMovePiece _csManagerMovePiece;
    [SerializeField] private BehaviourMoveTransformB _csBehaviourMoveTransformB;
    [SerializeField] private BehaviourMaterialFlickerA _csBehaviourMaterialFlickerA;

    public DataPiece CsDataPiece
    {
        get
        {
            return _csDataPiece;
        }
        set
        {
            _csDataPiece = value;
            _isOnFirstFloor = true;
        }
    }

    public bool IsOnFirstFloor
    {
        get
        {
            return _isOnFirstFloor;
        }
        set
        {
            _isOnFirstFloor = value;
        }
    }

    public PrefabBoardFloor CsPrefabBoardFloorCurrent
    {
        get
        {
            return _csPrefabBoardFloorCurrent;
        }
        set
        {
            if (_csPrefabBoardFloorCurrent != null) _csPrefabBoardFloorCurrent.SteppedOff();
            _csPrefabBoardFloorCurrent = value;
            value.SteppedOn(this);
        }
    }

    public ManagerMovePiece CsManagerMovePiece
    {
        set
        {
            _csManagerMovePiece = value;
        }
    }

    public void InstantiatePiece(GameObject gameObjPiece, bool isEnableClick)
    {
        GameObject gameobj_piece = Instantiate(gameObjPiece, this.transform);

        gameobj_piece.transform.localPosition = Vector3.zero;

        if (isEnableClick)
        {
            gameobj_piece.GetComponent<BehaviourIPointerClick>().UniEvClick.AddListener(delegate
            {
                SelectPiece();
            });

            _csBehaviourMaterialFlickerA.MeshRendThis = gameobj_piece.GetComponent<MeshRenderer>();
            if (CsDataPiece.isWhite) _csBehaviourMaterialFlickerA.ColorInto = _colorFlickerWhite;
            else _csBehaviourMaterialFlickerA.ColorInto = _colorFlickerBlack;
        }
        else
        {
            gameobj_piece.GetComponent<MeshCollider>().enabled = false;
        }
    }

    public void SelectPiece()
    {
        _csManagerMovePiece.SelectPiece(this);
    }

    public void ActivatePiece()
    {
        _csBehaviourMaterialFlickerA.StartFlicker();
    }

    public void DeactivatePiece()
    {
        _csBehaviourMaterialFlickerA.StopFlicker();
    }

    public void MovePiece(PrefabBoardFloor csPrefabBoardFloor)
    {
        CsPrefabBoardFloorCurrent = csPrefabBoardFloor;

        Vector3 v3_pos = new Vector3(csPrefabBoardFloor.transform.localPosition.x, transform.localPosition.y, csPrefabBoardFloor.transform.localPosition.z);

        MovePos(v3_pos);
    }

    public void MovePos(Vector3 v3Pos)
    {
        if (_isOnFirstFloor) _isOnFirstFloor = false;

        _csBehaviourMoveTransformB.MovePosition(v3Pos);
    }
}
