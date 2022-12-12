using System.Linq;

public class RuntimeSetSetter<T> : RoboRyanTron.Unite2017.Sets.RuntimeSet<T>
{
    //Open Close Principle, Open For Extension, Close For Modification
    
    public void SetItems(string stringdata)
    {
        T[] arrData = JsonHelper.getJsonArray<T>(stringdata);
        Items = arrData.ToList();
    }

    public void ClearItems()
    {
        Items.Clear();
    }
}
