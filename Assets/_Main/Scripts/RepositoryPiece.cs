using UnityEngine;

[CreateAssetMenu(fileName = "RepositoryPiece", menuName = "Repository Piece")]
public class RepositoryPiece : RuntimeSetSetter<DataPiece>
{
    public DataPiece GetDataById(char sId)
    {
        foreach (DataPiece cs_data in Items)
        {
            if (cs_data.CId.Equals(sId))
            {
                return cs_data;
            }
        }

        return null;
    }
}


