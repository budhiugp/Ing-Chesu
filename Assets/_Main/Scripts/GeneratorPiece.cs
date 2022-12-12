using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorPiece : MonoBehaviour
{
    public enum EnumFacing { Forward, Backward }
    public EnumFacing Facing;

    [Header("Repositories")]
    [SerializeField] private RepositoryPiece _scrObjRepoPiece;
    [SerializeField] private RepositoryUser _scrObjRepoUser;

    [Header("Generator Components")]
    [SerializeField] private GameObject _gameObjPrefabPiece;
    [SerializeField] private Transform _transGroupPrefabPiece;

    [Header("Classes")]
    [SerializeField] private GeneratorBoardFloor _csGeneratorBoardFloor;
    [SerializeField] private ManagerMovePiece _csManagerMovePiece;
    [SerializeField] private CustomDebug _csCustomDebug;

    public void Initialization()
    {
        Debug.Log(_csCustomDebug.DebugColor(this.name + " Initialization") + " Begin");

        LoadFen("rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1");
    }

    public void LoadFen(string sFen)
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
        }
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
        cs_prefabpiece.SetIsEnemy(_scrObjRepoUser.CsDataUser.IsWhite);

        gameobj_piece.transform.localPosition = cs_prefabboardfloor.transform.localPosition;
    }
}
