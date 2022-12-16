[System.Serializable]
public class DataBoardGame
{
    public bool IsWhiteTurn;
    public bool IsOnCheck;

    public string DebugThis()
    {
        return "IsWhiteTurn = " + IsWhiteTurn + ", IsOnCheck = " + IsOnCheck;
    }
}
