using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DataPiece
{
    public char CId;
    public string SName;
    public GameObject GameObjPiece;
    public bool isWhite;

    public enum EnumMovementType { Vertical, Horizontal, Diagonal, Knight, Pawn, King }
    public List<EnumMovementType> ListMovementType = new List<EnumMovementType>();

    public string DebugThis()
    {
        string s_listmovementtype = ListMovementType.Count + " : ";
        for (int i = 0; i < ListMovementType.Count; i++)
        {
            s_listmovementtype += ListMovementType[i] + ", ";
        }
        return "CId = " + CId + ", SName = " + SName + ", isWhite = " + isWhite + "\nListMovementType = " + s_listmovementtype;
    }
}
