using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class ManagerCheck : MonoBehaviour
{
    [Header("Repositories")]
    [SerializeField] private RepositoryBoard _scrObjRepoBoard;

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
    [SerializeField] private List<DataCheck> _listDataCheck = new List<DataCheck>();
    [SerializeField] private bool _isScanCheckSet;
    //[SerializeField] private bool _isScanCheckByWhite;

    public PrefabPiece CsPrefabPieceKingWhite
    {
        get
        {
            return _csPrefabPieceKingWhite;
        }
        set
        {
            _csPrefabPieceKingWhite = value;
        }
    }

    public PrefabPiece CsPrefabPieceKingBlack
    {
        get
        {
            return _csPrefabPieceKingBlack;
        }
        set
        {
            _csPrefabPieceKingBlack = value;
        }
    }

    public List<DataCheck> ListDataCheck
    {
        get
        {
            return _listDataCheck;
        }
    }

    private void Start()
    {
        _csScanCheckVertical = new ScanCheckVertical(this, _csGeneratorMovePiece, _csGeneratorBoardFloor);
        _csScanCheckHorizontal = new ScanCheckHorizontal(this, _csGeneratorMovePiece, _csGeneratorBoardFloor);
        _csScanCheckDiagonal = new ScanCheckDiagonal(this, _csGeneratorMovePiece, _csGeneratorBoardFloor);
        _csScanCheckKnight = new ScanCheckKnight(this, _csGeneratorMovePiece, _csGeneratorBoardFloor);
    }

    public void SetScanCheck(bool isWhite, PrefabBoardFloor csPrefabBoardFloor)
    {
        //Debug.Log(_csCustomDebug.DebugColor(this.name + " SetScanCheck") + " Begin");

        DataCheck cs_datacheck = new DataCheck(csPrefabBoardFloor.CsPrefabPieceStepOn, csPrefabBoardFloor);

        _listDataCheck.Add(cs_datacheck);

        CancelInvoke("ReadScanCheck");

        if (!_isScanCheckSet) Invoke("ReadScanCheck", 1f);
    }

    private void ReadScanCheck()
    {
        Debug.Log(_csCustomDebug.DebugColor(this.name + " ReadScanCheck") + " Begin");

        _isScanCheckSet = true;

        string s_check = "Check By ";
    
        foreach (DataCheck cs_datacheck in _listDataCheck)
        {
            if (cs_datacheck.CsPrefabPiece.CsDataPiece.isWhite)
            {
                Debug.Log(_csCustomDebug.DebugColor(this.name + " DisplayCheck", 4) + " Begin Black King is Check by " + cs_datacheck.CsPrefabPiece.CsDataPiece.SName + " On IFile = " + cs_datacheck.CsPrefabBoardFloor.IFile + " IRank = " + cs_datacheck.CsPrefabBoardFloor.IRank);
            }
            else
            {
                Debug.Log(_csCustomDebug.DebugColor(this.name + " DisplayCheck", 6) + " Begin White King is Check by " + cs_datacheck.CsPrefabPiece.CsDataPiece.SName + " On IFile = " + cs_datacheck.CsPrefabBoardFloor.IFile + " IRank = " + cs_datacheck.CsPrefabBoardFloor.IRank);
            }

            s_check += cs_datacheck.CsPrefabPiece.CsDataPiece.SName + "[" + cs_datacheck.CsPrefabBoardFloor.IFile + "," + cs_datacheck.CsPrefabBoardFloor.IRank + "], ";
        }

        if (_listDataCheck.Count > 0)
        {
            _csDisplayerCheck.ShowDisplayCheck(s_check);

            _scrObjRepoBoard.CsDataBoardGame.IsOnCheck = true;
        }
        else
        {

        }
    }

    public void LookCheck(bool isWhiteKing)
    {
        //Debug.Log(_csCustomDebug.DebugColor(this.name + " LookCheck") + " Begin : \nisWhite = " + isWhite);
        _listDataCheck.Clear();

        _scrObjRepoBoard.CsDataBoardGame.IsOnCheck = false;

        _isScanCheckSet = false;

        //_isScanCheckByWhite = isWhite;

        int i_file = 0;
        int i_rank = 0;

        if (isWhiteKing)
        {
            i_file = _csPrefabPieceKingWhite.CsPrefabBoardFloorCurrent.IFile;
            i_rank = _csPrefabPieceKingWhite.CsPrefabBoardFloorCurrent.IRank;

            Debug.Log("LookCheck for White King on IFile = " + _csPrefabPieceKingWhite.CsPrefabBoardFloorCurrent.IFile + "\n_csPrefabPieceKingWhite.CsPrefabBoardFloorCurrent.IRank = " + _csPrefabPieceKingWhite.CsPrefabBoardFloorCurrent.IRank);
        }
        else
        {
            i_file = _csPrefabPieceKingBlack.CsPrefabBoardFloorCurrent.IFile;
            i_rank = _csPrefabPieceKingBlack.CsPrefabBoardFloorCurrent.IRank;

            Debug.Log("LookCheck for Black King on IFile = " + _csPrefabPieceKingBlack.CsPrefabBoardFloorCurrent.IFile + "\n_csPrefabPieceKingBlack.CsPrefabBoardFloorCurrent.IRank = " + _csPrefabPieceKingBlack.CsPrefabBoardFloorCurrent.IRank);
        }

        _csScanCheckVertical.ScanCheckDirection(i_file, i_rank, isWhiteKing);
        _csScanCheckHorizontal.ScanCheckDirection(i_file, i_rank, isWhiteKing);
        _csScanCheckDiagonal.ScanCheckDirection(i_file, i_rank, isWhiteKing);
        _csScanCheckKnight.ScanCheckDirection(i_file, i_rank, isWhiteKing);
    }

    public void PreventCheckWhite(bool isWhite)
    {
        Debug.Log(_csCustomDebug.DebugColor(this.name + " PreventCheckWhite") + " Begin isWhite = " + isWhite);
    }

    public void ScanCheckFloorSave(PrefabBoardFloor csPrefabBoardFloor, bool isWhite)
    {
        Debug.Log(_csCustomDebug.DebugColor(this.name + " ScanCheckFloorSave") + " Begin on iFile = " + csPrefabBoardFloor.IFile + ", iRank = " + csPrefabBoardFloor.IRank + "\nisWhite = " + isWhite);

        _csScanCheckVertical.ScanCheckDirectionSave(csPrefabBoardFloor, isWhite);
        _csScanCheckHorizontal.ScanCheckDirectionSave(csPrefabBoardFloor, isWhite);
        //Diagonal
        //Knight
    }
}
