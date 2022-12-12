using UnityEngine;

[CreateAssetMenu(fileName = "RepositoryBoardFloor", menuName = "Repository Board Floor")]
public class RepositoryBoardFloor : RuntimeSetSetter<DataBoardFloor>
{
    public DataBoardFloor GetDataByXYIndex(char cXIndex, char cYIndex)
    {
        foreach (DataBoardFloor cs_data in Items)
        {
            if (cs_data.CXIndex.Equals(cXIndex) && cs_data.CYIndex.Equals(cYIndex))
            {
                return cs_data;
            }
        }

        return null;
    }
}

