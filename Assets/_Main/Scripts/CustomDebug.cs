using UnityEngine;

public class CustomDebug : MonoBehaviour
{
    /// <summary>
    /// Custom Debug with colors for easy recognize ^_^ . The color is white.
    /// </summary>
    public string DebugColor(string sDebug) 
    {
        return "<color=white>" + sDebug + "</color>";
    }

    /// <summary>
    /// Custom Debug with colors for easy recognize ^_^ . 
    /// 1 = green, 2 = cyan, 3 = magenta, 4 = red, 5 = yellow, 6 = blue, default = white.
    /// </summary>
    public string DebugColor(string sDebug, int iColor) 
    {
        string s_color = "";
        if(iColor == 1) s_color = "green";
        else if(iColor == 2) s_color = "cyan";
        else if(iColor == 3) s_color = "magenta";
        else if(iColor == 4) s_color = "red";
        else if(iColor == 5) s_color = "yellow";
        else if(iColor == 6) s_color = "blue";
        else s_color = "white";

        return "<color=" + s_color + ">" + sDebug + "</color>";
    }
}
