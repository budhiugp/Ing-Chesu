using System;
using UnityEngine;

public class ScanCheck
{
    public ScanCheck(ManagerCheck csManagerCheck, GeneratorMovePiece csGeneratorMovePiece, GeneratorBoardFloor csGeneratorBoardFloor)
    {
        _csManagerCheck = csManagerCheck;
        _csGeneratorMovePiece = csGeneratorMovePiece;
        _csGeneratorBoardFloor = csGeneratorBoardFloor;
    }

    protected ManagerCheck _csManagerCheck;
    protected GeneratorMovePiece _csGeneratorMovePiece;
    protected GeneratorBoardFloor _csGeneratorBoardFloor;

    protected virtual void ValidateCheck(int iFile, int iRank, bool isWhiteKing, DataPiece.EnumMovementType enumMovementType, Action actResponse)
    {
        //Debug.Log("ScanCheck ValidateCheck Begin \niFile = " + iFile + ", iRank = " + iRank + ", isWhite = " + isWhite + "\nenumMovementType = " + enumMovementType);

        PrefabBoardFloor cs_prefabboardfloor = _csGeneratorBoardFloor.GetPrefabBoardFloorByFileNRank(iFile, iRank);

        if (cs_prefabboardfloor.CsPrefabPieceStepOn != null)
        {
            char c_piece_id = Char.ToLower(cs_prefabboardfloor.CsPrefabPieceStepOn.CsDataPiece.CId);

            if (cs_prefabboardfloor.CsPrefabPieceStepOn.CsDataPiece.isWhite != isWhiteKing)
            {
                switch (enumMovementType)
                {
                    case DataPiece.EnumMovementType.Vertical:
                        if (c_piece_id.Equals('r') || c_piece_id.Equals('q'))
                        {
                            _csManagerCheck.SetScanCheck(isWhiteKing, cs_prefabboardfloor);
                            actResponse();
                        }
                        break;
                    case DataPiece.EnumMovementType.Horizontal:
                        if (c_piece_id.Equals('r') || c_piece_id.Equals('q'))
                        {
                            _csManagerCheck.SetScanCheck(isWhiteKing, cs_prefabboardfloor);
                            actResponse();
                        }
                        break;
                    case DataPiece.EnumMovementType.Diagonal:
                        if (c_piece_id.Equals('b') || c_piece_id.Equals('q') || c_piece_id.Equals('p'))
                        {
                            _csManagerCheck.SetScanCheck(isWhiteKing, cs_prefabboardfloor);
                            actResponse();
                        }
                        break;
                    case DataPiece.EnumMovementType.Knight:
                        if (c_piece_id.Equals('n'))
                        {
                            _csManagerCheck.SetScanCheck(isWhiteKing, cs_prefabboardfloor);
                        }
                        break;
                    default:
                        Debug.LogWarning("ScanCheck Line Switch Case Default");
                        break;
                }
            }
            else
            {
                actResponse();
            }
        }
    }

    protected virtual void ValidateCheckSave(int iFile, int iRank, bool isWhiteKing, DataPiece.EnumMovementType enumMovementType, Action actResponseStillSave, Action actResponseReturn, PrefabBoardFloor csPrefabBoardFloorShadow)
    {
        //Debug.Log("ScanCheck ValidateCheck Begin \niFile = " + iFile + ", iRank = " + iRank + ", isWhite = " + isWhite + "\nenumMovementType = " + enumMovementType);

        PrefabBoardFloor cs_prefabboardfloor = _csGeneratorBoardFloor.GetPrefabBoardFloorByFileNRank(iFile, iRank);

        if (cs_prefabboardfloor.CsPrefabPieceStepOn != null)
        {
            char c_piece_id = Char.ToLower(cs_prefabboardfloor.CsPrefabPieceStepOn.CsDataPiece.CId);

            //Debug.LogWarning("CsDataPiece = " + cs_prefabboardfloor.CsPrefabPieceStepOn.CsDataPiece.DebugThis() + "\nVS\nisWhiteKing = " + isWhiteKing);

            if (cs_prefabboardfloor.CsPrefabPieceStepOn.CsDataPiece.isWhite != isWhiteKing)
            {
                switch (enumMovementType)
                {
                    case DataPiece.EnumMovementType.Vertical:
                        if (c_piece_id.Equals('r') || c_piece_id.Equals('q'))
                        {
                            //Debug.Log("ValidateCheckSave Vertical Found Rook or Queen on iFile = " + iFile + ", iRank = " + iRank + "\nPiece : \n" + cs_prefabboardfloor.CsPrefabPieceStepOn.CsDataPiece.DebugThis());
                            _csGeneratorMovePiece.AddListPrefabBoardFloorNotSave(csPrefabBoardFloorShadow);
                            actResponseReturn();
                        }
                        else
                        {
                            //Debug.Log("ValidateCheckSave Vertical Not Found Anything, the Floor iFile = " + iFile + ", iRank = " + iRank + " is Save");
                            _csGeneratorMovePiece.AddListPrefabBoardFloorSave(csPrefabBoardFloorShadow);
                            actResponseStillSave();
                        }
                        break;
                    case DataPiece.EnumMovementType.Horizontal:
                        if (c_piece_id.Equals('r') || c_piece_id.Equals('q'))
                        {
                            //Debug.Log("ValidateCheckSave Horizontal Found Rook or Queen on iFile = " + iFile + ", iRank = " + iRank + "\nPiece : \n" + cs_prefabboardfloor.CsPrefabPieceStepOn.CsDataPiece.DebugThis());
                            _csGeneratorMovePiece.AddListPrefabBoardFloorNotSave(csPrefabBoardFloorShadow);
                            actResponseReturn();
                        }
                        else
                        {
                            //Debug.Log("ValidateCheckSave Horizontal Not Found Anything, the Floor iFile = " + iFile + ", iRank = " + iRank + " is Save");
                            _csGeneratorMovePiece.AddListPrefabBoardFloorSave(csPrefabBoardFloorShadow);
                            actResponseStillSave();
                        }

                        //actResponse();
                        break;
                    case DataPiece.EnumMovementType.Diagonal:
                        if (c_piece_id.Equals('b') || c_piece_id.Equals('q') || c_piece_id.Equals('p'))
                        {
                            _csManagerCheck.SetScanCheck(isWhiteKing, cs_prefabboardfloor);
                            actResponseStillSave();
                            _csGeneratorMovePiece.AddListPrefabBoardFloorSave(cs_prefabboardfloor);
                        }
                        break;
                    case DataPiece.EnumMovementType.Knight:
                        if (c_piece_id.Equals('n'))
                        {
                            _csManagerCheck.SetScanCheck(isWhiteKing, cs_prefabboardfloor);
                        }
                        break;
                    default:
                        Debug.LogWarning("ScanCheck Line Switch Case Default");
                        break;
                }
            }
            else
            {
                if (c_piece_id.Equals('k'))
                {
                    actResponseStillSave();
                }
                else
                {
                    switch (enumMovementType)
                    {
                        case DataPiece.EnumMovementType.Vertical:
                            _csGeneratorMovePiece.AddListPrefabBoardFloorSave(csPrefabBoardFloorShadow);
                            actResponseReturn();
                            break;
                        case DataPiece.EnumMovementType.Horizontal:
                            _csGeneratorMovePiece.AddListPrefabBoardFloorSave(csPrefabBoardFloorShadow);
                            actResponseReturn();
                            break;
                        default:
                            Debug.LogWarning("ScanCheck Line Switch Case Default");
                            break;
                    }
                }

            }
        }
    }
}
