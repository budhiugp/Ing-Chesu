using UnityEngine;

public class ManagerCheck : MonoBehaviour
{
    [Header("Classes")]
    [SerializeField] private GeneratorBoardFloor _csGeneratorBoardFloor;
    [SerializeField] private GeneratorMovePiece _csGeneratorMovePiece;
    [SerializeField] private DisplayerCheck _csDisplayerCheck;
    [SerializeField] private CustomDebug _csCustomDebug;

    private ScanCheckVertical _csScanCheckVertical;
    private ScanCheckHorizontal _csScanCheckHorizontal;
    private ScanCheckDiagonal _csScanCheckDiagonal;
    private ScanCheckKnight _csScanCheckKnight;

    [Header("Temp")]
    [SerializeField] private PrefabPiece _csPrefabPieceKingWhite;
    [SerializeField] private PrefabPiece _csPrefabPieceKingBlack;

    public PrefabPiece CsPrefabPieceKingWhite
    {
        set
        {
            _csPrefabPieceKingWhite = value;
        }
    }

    public PrefabPiece CsPrefabPieceKingBlack
    {
        set
        {
            _csPrefabPieceKingBlack = value;
        }
    }

    private void Start()
    {
        _csScanCheckVertical = new ScanCheckVertical(this, _csGeneratorMovePiece, _csGeneratorBoardFloor);
        _csScanCheckHorizontal = new ScanCheckHorizontal(this, _csGeneratorMovePiece, _csGeneratorBoardFloor);
        _csScanCheckDiagonal = new ScanCheckDiagonal(this, _csGeneratorMovePiece, _csGeneratorBoardFloor);
        _csScanCheckKnight = new ScanCheckKnight(this, _csGeneratorMovePiece, _csGeneratorBoardFloor);
    }

    public void DisplayCheck(bool isWhite, PrefabPiece csPrefabPiece)
    {
        string s_check = "";

        if (isWhite)
        {
            Debug.Log(_csCustomDebug.DebugColor(this.name + " DisplayCheck", 4) + " Begin Black King is Check by " + csPrefabPiece.CsDataPiece.SName);

            s_check = "Black King is Check by " + csPrefabPiece.CsDataPiece.SName;
        }
        else
        {
            Debug.Log(_csCustomDebug.DebugColor(this.name + " DisplayCheck", 6) + " Begin White King is Check by " + csPrefabPiece.CsDataPiece.SName);

            s_check = "White King is Check by " + csPrefabPiece.CsDataPiece.SName;
        }

        _csDisplayerCheck.ShowDisplayCheck(s_check);
    }

    public void LookCheck(bool isWhite)
    {
        //Debug.Log(_csCustomDebug.DebugColor(this.name + " LookCheck") + " Begin : \nisWhite = " + isWhite);

        int i_file = 0;
        int i_rank = 0;

        if (isWhite)
        {
            i_file = _csPrefabPieceKingBlack.CsPrefabBoardFloorCurrent.IFile;
            i_rank = _csPrefabPieceKingBlack.CsPrefabBoardFloorCurrent.IRank;

            Debug.Log("LookCheck _csPrefabPieceKingBlack.CsPrefabBoardFloorCurrent.IFile = " + _csPrefabPieceKingBlack.CsPrefabBoardFloorCurrent.IFile + "\n_csPrefabPieceKingBlack.CsPrefabBoardFloorCurrent.IRank = " + _csPrefabPieceKingBlack.CsPrefabBoardFloorCurrent.IRank);
        }
        else
        {
            i_file = _csPrefabPieceKingWhite.CsPrefabBoardFloorCurrent.IFile;
            i_rank = _csPrefabPieceKingWhite.CsPrefabBoardFloorCurrent.IRank;

            Debug.Log("LookCheck _csPrefabPieceKingWhite.CsPrefabBoardFloorCurrent.IFile = " + _csPrefabPieceKingWhite.CsPrefabBoardFloorCurrent.IFile + "\n_csPrefabPieceKingWhite.CsPrefabBoardFloorCurrent.IRank = " + _csPrefabPieceKingWhite.CsPrefabBoardFloorCurrent.IRank);
        }

        //To Do Coroutine

        _csScanCheckVertical.ScanCheckDirection(i_file, i_rank, isWhite);
        _csScanCheckHorizontal.ScanCheckDirection(i_file, i_rank, isWhite);
        _csScanCheckDiagonal.ScanCheckDirection(i_file, i_rank, isWhite);
        _csScanCheckKnight.ScanCheckDirection(i_file, i_rank, isWhite);
    }

    public void PreventCheckWhite(bool isWhite)
    {
        Debug.Log(_csCustomDebug.DebugColor(this.name + " PreventCheckWhite") + " Begin isWhite = " + isWhite);

        
    }
}
