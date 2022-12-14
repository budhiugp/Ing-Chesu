[System.Serializable]
public class DataBoardFloor
{
    public char CXIndex;
    public char CYIndex;

    public int IFile;
    public int IRank;

    public int IMoveValue;

    public string DebugThis()
    {
        return "IFile = " + IFile + ", IRank = " + IRank + "\nCXIndex = " + CXIndex + ", CYIndex = " + CYIndex;
    }
}
