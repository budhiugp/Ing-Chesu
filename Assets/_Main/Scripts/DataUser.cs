[System.Serializable]

public class DataUser
{
    public DataUser(string sUserName)
    {
        SUserName = sUserName;
    }

    public string SUserName;

    public string DebugThis()
    {
        return "SUserName = " + SUserName;
    }

    public void ClearData()
    {
        SUserName = "";
    }
}
