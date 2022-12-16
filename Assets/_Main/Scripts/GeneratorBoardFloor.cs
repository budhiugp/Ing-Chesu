using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorBoardFloor : MonoBehaviour
{
    [Header("Repositories")]
    [SerializeField] private RepositoryBoardFloor _scrObjRepoBoardFloor;

    [Header("Generator Components")]
    [SerializeField] private GameObject _gameObjPrefabBoardFloor;
    [SerializeField] private Transform _transGroupPrefabBoardFloor;
    [SerializeField] private Vector2 _v2FirstPos = new Vector2(-5.25f, -5.25f);
    [SerializeField] private Vector2 _v2Offset = new Vector2(1.5f, 1.5f);

    [Header("Classes")]
    [SerializeField] private ManagerMovePiece _csManagerMovePiece;
    [SerializeField] private CustomDebug _csCustomDebug;

    [Header("Other")]
    public List<PrefabBoardFloor> ListPrefabBoardFloor = new List<PrefabBoardFloor>();

    private void Start()
    {
        GenerateBoardFloor();
    }

    public void GenerateBoardFloor()
    {
        //Debug.Log(_csCustomDebug.DebugColor(this.name + " GenerateBoardFloor") + " Begin");

        ListPrefabBoardFloor.Clear();

        int i_item = 0;

        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                DataBoardFloor cs_databoardfloor = _scrObjRepoBoardFloor.Items[i_item];
                cs_databoardfloor.IFile = j;
                cs_databoardfloor.IRank = i;
                cs_databoardfloor.IMoveValue = i_item;

                GameObject gameobj_prefabboardfloor = Instantiate(_gameObjPrefabBoardFloor, _transGroupPrefabBoardFloor);
                gameobj_prefabboardfloor.name = "Floor_" + cs_databoardfloor.CXIndex + cs_databoardfloor.CYIndex;

                gameobj_prefabboardfloor.transform.localPosition = new Vector3(_v2FirstPos.x + (j * _v2Offset.x), 0f, _v2FirstPos.y + (i * _v2Offset.y));

                PrefabBoardFloor cs_prefabboardfloor = gameobj_prefabboardfloor.GetComponent<PrefabBoardFloor>();
                cs_prefabboardfloor.CsDataBoardFloor = cs_databoardfloor;
                cs_prefabboardfloor.CsManagerMovePiece = _csManagerMovePiece;

                i_item++;

                ListPrefabBoardFloor.Add(cs_prefabboardfloor);
            }
        }
    }

    public PrefabBoardFloor GetPrefabBoardFloorByFileNRank(int iFile, int iRank)
    {
        foreach (PrefabBoardFloor cs_data in ListPrefabBoardFloor)
        {
            if (cs_data.IFile == iFile && cs_data.IRank == iRank)
            {
                return cs_data;
            }
        }

        return null;
    }
}
