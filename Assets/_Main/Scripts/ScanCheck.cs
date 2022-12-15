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

    protected virtual void ValidateCheck(int iFile, int iRank, bool isWhite, DataPiece.EnumMovementType enumMovementType, Action actResponse)
    {
        //Debug.Log("ScanCheck ValidateCheck Begin \niFile = " + iFile + ", iRank = " + iRank + ", isWhite = " + isWhite + "\nenumMovementType = " + enumMovementType);

        PrefabBoardFloor cs_prefabboardfloor = _csGeneratorBoardFloor.GetPrefabBoardFloorByFileNRank(iFile, iRank);

        if (cs_prefabboardfloor.CsPrefabPieceStepOn != null)
        {
            char c_piece_id = Char.ToLower(cs_prefabboardfloor.CsPrefabPieceStepOn.CsDataPiece.CId);

            if (cs_prefabboardfloor.CsPrefabPieceStepOn.CsDataPiece.isWhite == isWhite)
            {
                switch (enumMovementType)
                {
                    case DataPiece.EnumMovementType.Vertical:
                        if (c_piece_id.Equals('r') || c_piece_id.Equals('q'))
                        {
                            _csManagerCheck.SetScanCheck(isWhite, cs_prefabboardfloor);
                            actResponse();
                        }
                        break;
                    case DataPiece.EnumMovementType.Horizontal:
                        if (c_piece_id.Equals('r') || c_piece_id.Equals('q'))
                        {
                            _csManagerCheck.SetScanCheck(isWhite, cs_prefabboardfloor);
                            actResponse();
                        }
                        break;
                    case DataPiece.EnumMovementType.Diagonal:
                        if (c_piece_id.Equals('b') || c_piece_id.Equals('q') || c_piece_id.Equals('p'))
                        {
                            _csManagerCheck.SetScanCheck(isWhite, cs_prefabboardfloor);
                            actResponse();
                        }
                        break;
                    case DataPiece.EnumMovementType.Knight:
                        if (c_piece_id.Equals('n'))
                        {
                            _csManagerCheck.SetScanCheck(isWhite, cs_prefabboardfloor);
                        }
                        break;
                    default:
                        Debug.LogWarning("ScanCheck Line Switch Case Default");
                        break;
                }
            }
        }
    }

    protected virtual void ValidateCheckSave(int iFile, int iRank, bool isWhite, DataPiece.EnumMovementType enumMovementType, Action actResponse, PrefabBoardFloor csPrefabBoardFloorShadow)
    {
        //Debug.Log("ScanCheck ValidateCheck Begin \niFile = " + iFile + ", iRank = " + iRank + ", isWhite = " + isWhite + "\nenumMovementType = " + enumMovementType);

        PrefabBoardFloor cs_prefabboardfloor = _csGeneratorBoardFloor.GetPrefabBoardFloorByFileNRank(iFile, iRank);

        if (cs_prefabboardfloor.CsPrefabPieceStepOn != null)
        {
            char c_piece_id = Char.ToLower(cs_prefabboardfloor.CsPrefabPieceStepOn.CsDataPiece.CId);

            if (cs_prefabboardfloor.CsPrefabPieceStepOn.CsDataPiece.isWhite != isWhite)
            {
                switch (enumMovementType)
                {
                    case DataPiece.EnumMovementType.Vertical:
                        if (c_piece_id.Equals('r') || c_piece_id.Equals('q'))
                        {

                        }
                        else
                        {
                            _csGeneratorMovePiece.AddListPrefabBoardFloorSave(csPrefabBoardFloorShadow);
                        }

                        actResponse();
                        break;
                    case DataPiece.EnumMovementType.Horizontal:
                        if (c_piece_id.Equals('r') || c_piece_id.Equals('q'))
                        {
                            _csManagerCheck.SetScanCheck(isWhite, cs_prefabboardfloor);
                            actResponse();
                            _csGeneratorMovePiece.AddListPrefabBoardFloorSave(cs_prefabboardfloor);
                        }
                        break;
                    case DataPiece.EnumMovementType.Diagonal:
                        if (c_piece_id.Equals('b') || c_piece_id.Equals('q') || c_piece_id.Equals('p'))
                        {
                            _csManagerCheck.SetScanCheck(isWhite, cs_prefabboardfloor);
                            actResponse();
                            _csGeneratorMovePiece.AddListPrefabBoardFloorSave(cs_prefabboardfloor);
                        }
                        break;
                    case DataPiece.EnumMovementType.Knight:
                        if (c_piece_id.Equals('n'))
                        {
                            _csManagerCheck.SetScanCheck(isWhite, cs_prefabboardfloor);
                        }
                        break;
                    default:
                        Debug.LogWarning("ScanCheck Line Switch Case Default");
                        break;
                }
            }
        }
    }
}
