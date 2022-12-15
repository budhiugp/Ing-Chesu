using UnityEngine;

public class MovePieceKing : MovePiece
{
    public MovePieceKing(GeneratorMovePiece csGeneratorMovePiece, GeneratorBoardFloor csGeneratorBoardFloor) : base(csGeneratorMovePiece, csGeneratorBoardFloor)
    {
    }

    public void GenerateMovePiece(PrefabBoardFloor csPrefabBoardFloorCurrent, PrefabPiece csPrefabPiece)
    {
        Debug.Log("MovePieceKing GenerateMovePiece Begin : \ncsPrefabBoardFloorCurrent : \n" + csPrefabBoardFloorCurrent.DebugThis());

        int i_file = csPrefabBoardFloorCurrent.IFile;
        int i_rank = csPrefabBoardFloorCurrent.IRank;

        //Top
        if (i_rank + 1 <= 7) ValidateFloorKing(i_file, i_rank + 1, csPrefabPiece.CsDataPiece.isWhite);

        //Down
        if (i_rank - 1 >= 0) ValidateFloorKing(i_file, i_rank - 1, csPrefabPiece.CsDataPiece.isWhite);

        //Left
        if (i_file - 1 >= 0) ValidateFloorKing(i_file - 1, i_rank, csPrefabPiece.CsDataPiece.isWhite);

        //Right
        if (i_file + 1 <= 7) ValidateFloorKing(i_file + 1, i_rank, csPrefabPiece.CsDataPiece.isWhite);

        //Top Left
        if (i_file - 1 >= 0 && i_rank + 1 <= 7) ValidateFloorKing(i_file - 1, i_rank + 1, csPrefabPiece.CsDataPiece.isWhite);

        //Top Right
        if (i_file + 1 <= 7 && i_rank + 1 <= 7) ValidateFloorKing(i_file + 1, i_rank + 1, csPrefabPiece.CsDataPiece.isWhite);

        //Down Left
        if (i_file - 1 >= 0 && i_rank - 1 >= 0) ValidateFloorKing(i_file - 1, i_rank - 1, csPrefabPiece.CsDataPiece.isWhite);

        //Down Right
        if (i_file + 1 <= 7 && i_rank - 1 >= 0) ValidateFloorKing(i_file + 1, i_rank - 1, csPrefabPiece.CsDataPiece.isWhite);

        //Castling
        if (!csPrefabPiece.IsOnFirstFloor) return;

        //Castling Left
        _isStill = true;
        for (int i = 3; i <= 4; i++)
        {
            if (!_isStill || i_file < 0) break;
            ValidateFloorCastling(i_file - i, i_rank, true);
        }

        //Right
        _isStill = true;
        for (int i = 3; i <= 4; i++)
        {
            if (!_isStill || i_file > 7) break;
            ValidateFloorCastling(i_file + i, i_rank, false);
        }
    }

    private void ValidateFloorKing(int iFile, int iRank, bool isWhite)
    {
        PrefabBoardFloor cs_prefabboardfloor = _csGeneratorBoardFloor.GetPrefabBoardFloorByFileNRank(iFile, iRank);

        if (cs_prefabboardfloor.CsPrefabPieceStepOn == null)
        {
            _csGeneratorMovePiece.SetHighlightFloorKing(cs_prefabboardfloor);
        }
        else
        {
            if (cs_prefabboardfloor.CsPrefabPieceStepOn.CsDataPiece.isWhite != isWhite)
            {
                _csGeneratorMovePiece.SetHighlightFloorKing(cs_prefabboardfloor);
            }
        }
    }

    private void ValidateFloorCastling(int iFile, int iRank, bool isLeft)
    {
        PrefabBoardFloor cs_prefabboardfloor = _csGeneratorBoardFloor.GetPrefabBoardFloorByFileNRank(iFile, iRank);
        
        if (cs_prefabboardfloor != null && cs_prefabboardfloor.CsPrefabPieceStepOn != null)
        {
            char c_piece_id = char.ToLower(cs_prefabboardfloor.CsPrefabPieceStepOn.CsDataPiece.CId);

            if (c_piece_id.Equals('r') && cs_prefabboardfloor.CsPrefabPieceStepOn.IsOnFirstFloor)
            {
                int i_file_castling_king = (isLeft) ? iFile + 1 : iFile - 1;

                PrefabBoardFloor cs_prefabboardfloor_castling_king = _csGeneratorBoardFloor.GetPrefabBoardFloorByFileNRank(i_file_castling_king, iRank);

                _csGeneratorMovePiece.SetHighlightFloorKing(cs_prefabboardfloor_castling_king);

                int i_file_castling_rook = (isLeft) ? iFile + 2 : iFile - 2;

                PrefabBoardFloor cs_prefabboardfloor_castling_rook = _csGeneratorBoardFloor.GetPrefabBoardFloorByFileNRank(i_file_castling_rook, iRank);

                cs_prefabboardfloor_castling_king.SetFloorCastling(cs_prefabboardfloor.CsPrefabPieceStepOn, cs_prefabboardfloor_castling_rook);
            }

            _isStill = false;
        }
    }

    public void GenerateMovePieceSave(PrefabPiece csPrefabPiece)
    {
        Debug.Log("MovePieceKing GenerateMovePieceSave Begin : \ncsPrefabBoardFloorCurrent : \n" + csPrefabPiece.CsPrefabBoardFloorCurrent.DebugThis());

        int i_file = csPrefabPiece.CsPrefabBoardFloorCurrent.IFile;
        int i_rank = csPrefabPiece.CsPrefabBoardFloorCurrent.IRank;

        //Top
        if (i_rank + 1 <= 7) ValidateFloorSave(i_file, i_rank + 1, csPrefabPiece.CsDataPiece.isWhite);

        //Down
        if (i_rank - 1 >= 0) ValidateFloorSave(i_file, i_rank - 1, csPrefabPiece.CsDataPiece.isWhite);

        //Left
        if (i_file - 1 >= 0) ValidateFloorSave(i_file - 1, i_rank, csPrefabPiece.CsDataPiece.isWhite);

        //Right
        if (i_file + 1 <= 7) ValidateFloorSave(i_file + 1, i_rank, csPrefabPiece.CsDataPiece.isWhite);

        //Top Left
        if (i_file - 1 >= 0 && i_rank + 1 <= 7) ValidateFloorSave(i_file - 1, i_rank + 1, csPrefabPiece.CsDataPiece.isWhite);

        //Top Right
        if (i_file + 1 <= 7 && i_rank + 1 <= 7) ValidateFloorSave(i_file + 1, i_rank + 1, csPrefabPiece.CsDataPiece.isWhite);

        //Down Left
        if (i_file - 1 >= 0 && i_rank - 1 >= 0) ValidateFloorSave(i_file - 1, i_rank - 1, csPrefabPiece.CsDataPiece.isWhite);

        //Down Right
        if (i_file + 1 <= 7 && i_rank - 1 >= 0) ValidateFloorSave(i_file + 1, i_rank - 1, csPrefabPiece.CsDataPiece.isWhite);

        //Castling
        if (!csPrefabPiece.IsOnFirstFloor) return;

        //Castling Left
        _isStill = true;
        for (int i = 3; i <= 4; i++)
        {
            if (!_isStill || i_file < 0) break;
            //ValidateFloorCastlingSave(i_file - i, i_rank, true);
        }

        //Right
        _isStill = true;
        for (int i = 3; i <= 4; i++)
        {
            if (!_isStill || i_file > 7) break;
            //ValidateFloorCastlingSave(i_file + i, i_rank, false);
        }
    }

    private void ValidateFloorSave(int iFile, int iRank, bool isWhite)
    {
        PrefabBoardFloor cs_prefabboardfloor = _csGeneratorBoardFloor.GetPrefabBoardFloorByFileNRank(iFile, iRank);

        _csGeneratorMovePiece.CsManagerCheck.ScanCheckFloorSave(cs_prefabboardfloor, isWhite);
    }
}

