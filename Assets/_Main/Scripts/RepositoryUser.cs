using UnityEngine;

[CreateAssetMenu(fileName = "RepositoryUser", menuName = "Repository User")]
public class RepositoryUser : ScriptableObject
{
    public DataUser CsDataUser;

    [SerializeField] private bool _setDebugWhite;

    public string DebugThis()
    {
        return "DataUser :\n" + CsDataUser.DebugThis();
    }

    public void ClearData()
    {
        CsDataUser.ClearData();
    }

    public void Debug()
    {
        CsDataUser.IsWhite = _setDebugWhite;
    }
}