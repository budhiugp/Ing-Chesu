using UnityEngine;

[CreateAssetMenu(fileName = "RepositoryBoard", menuName = "Repository Board")]
public class RepositoryBoard : ScriptableObject
{
    public DataBoardGame CsDataBoardGame;

    public string DebugThis()
    {
        return "CsDataBoardGame :\n" + CsDataBoardGame.DebugThis();
    }
}