[System.Serializable]

public class DataCheck
{
    public DataCheck(PrefabPiece csPrefabPiece, PrefabBoardFloor csPrefabBoardFloor)
    {
        CsPrefabPiece = csPrefabPiece;
        CsPrefabBoardFloor = csPrefabBoardFloor;
    }

    public PrefabPiece CsPrefabPiece;
    public PrefabBoardFloor CsPrefabBoardFloor;

    public string DebugThis()
    {
        return "CsPrefabPiece : \n" + CsPrefabPiece.CsDataPiece.DebugThis() + "\nCsPrefabBoardFloor : \n" + CsPrefabBoardFloor.DebugThis();
    }
}
