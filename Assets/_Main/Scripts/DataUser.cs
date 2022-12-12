[System.Serializable]

public class DataUser
{
    public DataUser(string sUserName)
    {
        SUserName = sUserName;
    }

    public string SUserName;
    public bool IsWhite;

    public string DebugThis()
    {
        return "SUserName = " + SUserName + "\nIsWhite = " + IsWhite;
    }

    public void ClearData()
    {
        SUserName = "";
        IsWhite = false;
    }
}
