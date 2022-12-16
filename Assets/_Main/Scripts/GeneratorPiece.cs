using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GeneratorPiece : MonoBehaviour
{
    [Header("Repositories")]
    [SerializeField] private RepositoryPiece _scrObjRepoPiece;
    [SerializeField] private RepositoryUser _scrObjRepoUser;

    [Header("Generator Components")]
    [SerializeField] private GameObject _gameObjPrefabPiece;
    [SerializeField] private Transform _transGroupPrefabPiece;
    [SerializeField] private List<PrefabPiece> ListPrefabPieceWhite = new List<PrefabPiece>();
    [SerializeField] private List<PrefabPiece> ListPrefabPieceBlack = new List<PrefabPiece>();

    [Header("Classes")]
    [SerializeField] private GeneratorBoardFloor _csGeneratorBoardFloor;
    [SerializeField] private ManagerMovePiece _csManagerMovePiece;
    [SerializeField] private ManagerCheck _csManagerCheck;
    [SerializeField] private CustomDebug _csCustomDebug;

    [Header("UnityEvents")]
    [SerializeField] private UnityEvent _uniEvOnCompleteInitialization;

    private Coroutine _corLoadFen;

    public void Initialization()
    {
        //Debug.Log(_csCustomDebug.DebugColor(this.name + " Initialization") + " Begin");

        LoadFen("rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1"); //Default

        //LoadFen("r3k2r/8/8/8/8/8/8/R3K2R w KQkq - 0 1"); //Castling

        //LoadFen("8/8/8/8/8/8/PPPPPPPP/R7 w KQkq - 0 1"); //Promotion

        //LoadFen("8/4pppp/8/8/8/8/1PPPPPPP/R7 w KQkq - 0 1"); //EnPassant

        //LoadFen("1nbqkbn1/r2p1p1r/8/8/8/8/R2P1P1R/1NBQKBN1 w KQkq - 0 1"); //other
        //LoadFen("1nbqkbn1/r6r/8/8/8/8/R6R/1NBQKBN1 w KQkq - 0 1");
        //LoadFen("1nbqkbn1/r3r3/8/8/8/8/R3R3/1NBQKBN1 w KQkq - 0 1");
    }

    public void LoadFen(string sFen)
    {
        if (_corLoadFen != null) StopCoroutine(_corLoadFen);

        ListPrefabPieceWhite.Clear();
        ListPrefabPieceBlack.Clear();

        _corLoadFen = StartCoroutine(CorLoadFen(sFen));
    }

    private IEnumerator CorLoadFen(string sFen)
    {
        string s_fen_board = sFen.Split(' ')[0];
        int i_file = 0, i_rank = 7;

        foreach (char c_symbol in s_fen_board)
        {
            if (c_symbol == '/')
            {
                i_file = 0;
                i_rank--;
            }
            else
            {
                if (char.IsDigit(c_symbol))
                {
                    i_file += (int)char.GetNumericValue(c_symbol);
                }
                else
                {
                    DataPiece cs_datapiece = _scrObjRepoPiece.GetDataById(c_symbol);

                    if (cs_datapiece != null)
                    {
                        GeneratePiece(cs_datapiece, i_file, i_rank);
                    }
                    else
                    {
                        Debug.LogWarning("cs_datapiece is Null");
                    }

                    i_file++;
                }
            }

            yield return null;
        }

        _uniEvOnCompleteInitialization.Invoke();
    }

    private void GeneratePiece(DataPiece csDataPiece, int iFile, int iRank)
    {
        //Debug.Log(_csCustomDebug.DebugColor(this.name + " GeneratePiece") + " Begin : \ncsDataPiece : " + csDataPiece.DebugThis() + "\niFile = " + iFile + "\niRank = " + iRank);

        GameObject gameobj_piece = Instantiate(_gameObjPrefabPiece, _transGroupPrefabPiece);
        gameobj_piece.name = "Piece_" + csDataPiece.SName + "_" + iFile + iRank;

        PrefabBoardFloor cs_prefabboardfloor = _csGeneratorBoardFloor.GetPrefabBoardFloorByFileNRank(iFile, iRank);

        PrefabPiece cs_prefabpiece = gameobj_piece.GetComponent<PrefabPiece>();
        cs_prefabpiece.CsDataPiece = csDataPiece;
        cs_prefabpiece.CsPrefabBoardFloorCurrent = cs_prefabboardfloor;
        cs_prefabpiece.CsManagerMovePiece = _csManagerMovePiece;
        //Debug cs_prefabpiece.InstantiatePiece(csDataPiece.GameObjPiece, _scrObjRepoUser.CsDataUserPlayer.IsWhite == csDataPiece.isWhite);
        cs_prefabpiece.InstantiatePiece(csDataPiece.GameObjPiece, true);

        gameobj_piece.transform.localPosition = cs_prefabboardfloor.transform.localPosition;

        if(csDataPiece.isWhite) ListPrefabPieceWhite.Add(cs_prefabpiece);
        else ListPrefabPieceBlack.Add(cs_prefabpiece);

        if (csDataPiece.CId.Equals('k'))
        {
            _csManagerCheck.CsPrefabPieceKingBlack = cs_prefabpiece;
        }
        else if (csDataPiece.CId.Equals('K'))
        {
            _csManagerCheck.CsPrefabPieceKingWhite = cs_prefabpiece;
        }
    }

    public void EnablePieceWhite()
    {
        SetEnablePieceToWhite(true);
    }

    public void EnablePieceBlack()
    {
        SetEnablePieceToWhite(false);
    }

    private void SetEnablePieceToWhite(bool isWhite)
    {
        foreach(PrefabPiece cs_prefabpiece in ListPrefabPieceWhite)
        {
            cs_prefabpiece.EnablePiece(isWhite);
        }
        foreach(PrefabPiece cs_prefabpiece in ListPrefabPieceBlack)
        {
            cs_prefabpiece.EnablePiece(!isWhite);
        }
    }
}
