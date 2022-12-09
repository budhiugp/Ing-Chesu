using UnityEngine;

[CreateAssetMenu(fileName = "RepositoryUser", menuName = "Repository User")]
public class RepositoryUser : ScriptableObject
{
    public DataUser CsDataUser;

    public string DebugThis()
    {
        return "DataUser :\n" + CsDataUser.DebugThis();
    }

    public void ClearData()
    {
        CsDataUser.ClearData();
    }
}