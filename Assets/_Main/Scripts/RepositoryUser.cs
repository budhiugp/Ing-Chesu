using UnityEngine;

[CreateAssetMenu(fileName = "RepositoryUser", menuName = "Repository User")]
public class RepositoryUser : ScriptableObject
{
    public DataUser CsDataUserPlayer;
    public DataUser CsDataUserAI;

    public string DebugThis()
    {
        return "CsDataUserPlayer :\n" + CsDataUserPlayer.DebugThis() + "\n=====\nCsDataUserAI :\n" + CsDataUserAI;
    }

    public void SelectAsWhite()
    {
        CsDataUserPlayer.IsWhite = true;
        CsDataUserAI.IsWhite = false;
    }

    public void SelectAsBlack()
    {
        CsDataUserPlayer.IsWhite = false;
        CsDataUserAI.IsWhite = true;
    }

    public void ClearDataPlayer()
    {
        CsDataUserPlayer.ClearData();
    }
}