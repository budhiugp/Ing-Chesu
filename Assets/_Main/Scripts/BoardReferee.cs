using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardReferee : MonoBehaviour
{
    [Header("Repositories")]
    [SerializeField] private RepositoryBoard _scrObjRepoBoard;
    [SerializeField] private RepositoryUser _scrObjRepoUser;

    [Header("Classes")]
    [SerializeField] private DisplayerPhase _csDisplayerPhase;
    [SerializeField] private GeneratorMovePiece _csGeneratorMovePiece;
    [SerializeField] private CustomDebug _csCustomDebug;

    [Header("Other")]
    [SerializeField] private bool _isGameOver;

    [Header("Temp")]
    [SerializeField] private DataUser _csDataUserCurrent;

    public void StartPlaySequence()
    {
        Debug.Log(_csCustomDebug.DebugColor(this.name + " StartPlaySequence") + " Begin");

        _scrObjRepoBoard.CsDataBoardGame.IsWhiteTurn = true;
        _isGameOver = false;

        _csDataUserCurrent = new DataUser("");

        PlayerTurnSequence();
    }

    private void PlayerTurnSequence()
    {
        Debug.Log(_csCustomDebug.DebugColor(this.name + " PlayerTurnSequence") + " Begin");

        if (_isGameOver)
        {
            //To Do Call Result
        }
        else
        {
            _csDataUserCurrent = (_scrObjRepoUser.CsDataUserPlayer.IsWhite == _scrObjRepoBoard.CsDataBoardGame.IsWhiteTurn) ? _scrObjRepoUser.CsDataUserPlayer : _scrObjRepoUser.CsDataUserAI;

            string s_phasename = "";

            if (_csDataUserCurrent.SUserName.Equals(_scrObjRepoUser.CsDataUserPlayer.SUserName))
            {
                s_phasename = "It's Your Start";
            }
            else
            {
                s_phasename = "It's Player " + _csDataUserCurrent.SUserName + "'s Turn";
            }

            _csGeneratorMovePiece.GenerateMovePieceSave(_scrObjRepoBoard.CsDataBoardGame.IsWhiteTurn);

            _csDisplayerPhase.StartPhase(s_phasename, PlayerTurn);
        }
    }

    private void PlayerTurn()
    {
        Debug.Log(_csCustomDebug.DebugColor(this.name + " PlayerTurn") + " Begin on Player " + _csDataUserCurrent.SUserName);
    }

    public void NextTurn()
    {
        _scrObjRepoBoard.CsDataBoardGame.IsWhiteTurn = !_scrObjRepoBoard.CsDataBoardGame.IsWhiteTurn;

        PlayerTurnSequence();
    }
}
