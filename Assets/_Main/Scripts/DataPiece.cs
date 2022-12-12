using UnityEngine;

[System.Serializable]
public class DataPiece
{
    public char CId;
    public string SName;
    public GameObject GameObjPiece;
    public bool isWhite;

    public string DebugThis()
    {
        return "CId = " + CId + ", SName = " + SName;
    }
}
