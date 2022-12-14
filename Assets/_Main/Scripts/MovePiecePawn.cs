using UnityEngine;

public class MovePiecePawn : MovePiece
{
    public MovePiecePawn(GeneratorMovePiece csGeneratorMovePiece, GeneratorBoardFloor csGeneratorBoardFloor) : base(csGeneratorMovePiece, csGeneratorBoardFloor)
    {
    }

    public void GenerateMovePiece(PrefabBoardFloor csPrefabBoardFloorCurrent, PrefabPiece csPrefabPiece)
    {
        Debug.Log("MovePiecePawn GenerateMovePiece Begin : \ncsPrefabBoardFloorCurrent : \n" + csPrefabBoardFloorCurrent.DebugThis());

        int i_maxstep;

        int i_file = csPrefabBoardFloorCurrent.IFile;
        int i_rank = csPrefabBoardFloorCurrent.IRank;

        if (csPrefabPiece.IsOnFirstFloor) i_maxstep = 2;
        else i_maxstep = 1;

        //Top/Down
        _isStill = true;
        if (csPrefabPiece.CsDataPiece.isWhite)
        {
            for (int i = 1; i <= i_maxstep; i++)
            {
                if (!_isStill) break;
                if (i_rank + i <= 7) ValidateFloorPawnFront(i_file, i_rank + i, i);
            }
        }
        else
        {
            for (int i = 1; i <= i_maxstep; i++)
            {
                if (!_isStill) break;
                if (i_rank - i >= 0) ValidateFloorPawnFront(i_file, i_rank - i, i);
            }
        }

        //Top/Down Left
        if (csPrefabPiece.CsDataPiece.isWhite)
        {
            if (i_file - 1 >= 0 && i_rank + 1 <= 7) ValidateFloorPawnDiagonal(i_file - 1, i_rank + 1, csPrefabPiece.CsDataPiece.isWhite);
        }
        else
        {
            if (i_file - 1 >= 0 && i_rank - 1 >= 0) ValidateFloorPawnDiagonal(i_file - 1, i_rank - 1, csPrefabPiece.CsDataPiece.isWhite);
        }

        //Top/Down Right
        if (csPrefabPiece.CsDataPiece.isWhite)
        {
            if (i_file + 1 <= 7 && i_rank + 1 <= 7) ValidateFloorPawnDiagonal(i_file + 1, i_rank + 1, csPrefabPiece.CsDataPiece.isWhite);
        }
        else
        {
            if (i_file + 1 <= 7 && i_rank - 1 >= 0) ValidateFloorPawnDiagonal(i_file + 1, i_rank - 1, csPrefabPiece.CsDataPiece.isWhite);
        }

        //EnPassant
        //Top/Down Left
        if (csPrefabPiece.CsDataPiece.isWhite)
        {
            if (i_file - 1 >= 0 && i_rank + 1 <= 7) ValidateFloorPawnEnPassant(i_file - 1, i_rank + 1, csPrefabBoardFloorCurrent.IRank, csPrefabPiece.CsDataPiece.isWhite);
        }
        else
        {
            if (i_file - 1 >= 0 && i_rank - 1 >= 0) ValidateFloorPawnEnPassant(i_file - 1, i_rank - 1, csPrefabBoardFloorCurrent.IRank, csPrefabPiece.CsDataPiece.isWhite);
        }

        //Top/Down Right
        if (csPrefabPiece.CsDataPiece.isWhite)
        {
            if (i_file + 1 <= 7 && i_rank + 1 <= 7) ValidateFloorPawnEnPassant(i_file + 1, i_rank + 1, csPrefabBoardFloorCurrent.IRank, csPrefabPiece.CsDataPiece.isWhite);
        }
        else
        {
            if (i_file + 1 <= 7 && i_rank - 1 >= 0) ValidateFloorPawnEnPassant(i_file + 1, i_rank - 1, csPrefabBoardFloorCurrent.IRank, csPrefabPiece.CsDataPiece.isWhite);
        }
    }

    private void ValidateFloorPawnFront(int iFile, int iRank, int iStep)
    {
        PrefabBoardFloor cs_prefabboardfloor = _csGeneratorBoardFloor.GetPrefabBoardFloorByFileNRank(iFile, iRank);

        if (cs_prefabboardfloor.CsPrefabPieceStepOn == null)
        {
            _csGeneratorMovePiece.SetHighlightFloor(cs_prefabboardfloor);

            if (iStep == 2)
            {
                cs_prefabboardfloor.SetFloorEnPassantable();
            }
            else
            {
                cs_prefabboardfloor.SetFloorDefault();
            }

            if (iRank == 0 || iRank == 7)
            {
                cs_prefabboardfloor.SetFloorPromotion();
            }
        }
        else
        {
            _isStill = false;
        }
    }

    private void ValidateFloorPawnDiagonal(int iFile, int iRank, bool isWhite)
    {
        PrefabBoardFloor cs_prefabboardfloor = _csGeneratorBoardFloor.GetPrefabBoardFloorByFileNRank(iFile, iRank);

        if (cs_prefabboardfloor.CsPrefabPieceStepOn != null)
        {
            if (cs_prefabboardfloor.CsPrefabPieceStepOn.CsDataPiece.isWhite != isWhite)
            {
                _csGeneratorMovePiece.SetHighlightFloor(cs_prefabboardfloor);
            }
        }
    }

    private void ValidateFloorPawnEnPassant(int iFile, int iRank, int iRankCurrent, bool isWhite)
    {
        PrefabBoardFloor cs_prefabboardfloor = _csGeneratorBoardFloor.GetPrefabBoardFloorByFileNRank(iFile, iRank);
        PrefabBoardFloor cs_prefabboardfloor_enpassant = _csGeneratorBoardFloor.GetPrefabBoardFloorByFileNRank(iFile, iRankCurrent);

        if (cs_prefabboardfloor.CsPrefabPieceStepOn == null && cs_prefabboardfloor_enpassant.CsPrefabPieceStepOn != null)
        {
            char c_piece_id = char.ToLower(cs_prefabboardfloor_enpassant.CsPrefabPieceStepOn.CsDataPiece.CId);

            if (cs_prefabboardfloor_enpassant.CsPrefabPieceStepOn.CsDataPiece.isWhite != isWhite)
            {
                if (c_piece_id.Equals('p') && cs_prefabboardfloor_enpassant.CsPrefabPieceStepOn.IsEnPassantable)
                {
                    _csGeneratorMovePiece.SetHighlightFloor(cs_prefabboardfloor);
                    cs_prefabboardfloor.SetFloorEnPassant(cs_prefabboardfloor_enpassant);
                }
            }
        }
    }
}