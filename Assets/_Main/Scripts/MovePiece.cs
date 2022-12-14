public class MovePiece
{
    public MovePiece(GeneratorMovePiece csGeneratorMovePiece, GeneratorBoardFloor csGeneratorBoardFloor)
    {
        _csGeneratorMovePiece = csGeneratorMovePiece;
        _csGeneratorBoardFloor = csGeneratorBoardFloor;
    }

    protected GeneratorMovePiece _csGeneratorMovePiece;
    protected GeneratorBoardFloor _csGeneratorBoardFloor;

    protected bool _isStill;

    protected virtual void ValidateFloor(int iFile, int iRank, bool isWhite)
    {
        PrefabBoardFloor cs_prefabboardfloor = _csGeneratorBoardFloor.GetPrefabBoardFloorByFileNRank(iFile, iRank);

        if (cs_prefabboardfloor.CsPrefabPieceStepOn == null)
        {
            _csGeneratorMovePiece.SetHighlightFloor(cs_prefabboardfloor);
        }
        else
        {
            if (cs_prefabboardfloor.CsPrefabPieceStepOn.CsDataPiece.isWhite != isWhite)
            {
                _csGeneratorMovePiece.SetHighlightFloor(cs_prefabboardfloor);
            }

            _isStill = false;
        }
    }
}
