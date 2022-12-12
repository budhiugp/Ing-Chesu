using UnityEngine;

public class PrefabPiece : MonoBehaviour
{
    [SerializeField] private DataPiece _csDataPiece;
    [SerializeField] private bool _isEnemy;

    [SerializeField] private PrefabBoardFloor _csPrefabBoardFloorCurrent;

    private ManagerMovePiece _csManagerMovePiece;
    [SerializeField] private BehaviourMoveTransformB _csBehaviourMoveTransformB;

    public DataPiece CsDataPiece
    {
        get
        {
            return _csDataPiece;
        }
        set
        {
            _csDataPiece = value;
            InstantiatePiece(value.GameObjPiece);
        }
    }

    public void SetIsEnemy(bool isWhite)
    {
        if (_csDataPiece.isWhite == isWhite) _isEnemy = true;
        else _isEnemy = false;
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

    private void InstantiatePiece(GameObject gameObjPiece)
    {
        GameObject gameobj_piece = Instantiate(gameObjPiece, this.transform);

        gameobj_piece.transform.localPosition = Vector3.zero;

        gameobj_piece.GetComponent<BehaviourIPointerClick>().UniEvClick.AddListener(delegate
        {
            SelectPiece();
        });
    }

    public void SelectPiece()
    {
        if (_isEnemy)
        {
            Debug.Log("This is an Enemy's Piece");
            _csManagerMovePiece.ValidateEnemy(this);
        }
        else
        {
            _csManagerMovePiece.HighlightFloor(this);
        }
    }

    public void MovePiece(PrefabBoardFloor csPrefabBoardFloor)
    {
        Vector3 v3_pos = new Vector3(csPrefabBoardFloor.transform.localPosition.x, transform.localPosition.y, csPrefabBoardFloor.transform.localPosition.z);

        _csBehaviourMoveTransformB.MovePosition(v3_pos);

        CsPrefabBoardFloorCurrent = csPrefabBoardFloor;
    }
}
