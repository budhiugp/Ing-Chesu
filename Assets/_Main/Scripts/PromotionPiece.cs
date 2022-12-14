using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PromotionPiece : MonoBehaviour
{
    [Header("Repositories")]
    [SerializeField] private RepositoryPiece _scrObjRepoPiece;

    [Header("Components")]
    [SerializeField] private GameObject _gameObjPrefabButtonPromotionPiece;
    [SerializeField] private Transform _transGroupPrefabButtonPromotionPiece;

    [Header("UnityEvents")]
    [SerializeField] private UnityEvent _uniEvShowDisplay;
    [SerializeField] private UnityEvent _uniEvHideDisplay;

    [Header("Temp")]
    [SerializeField] private PrefabPiece _csPrefabPiecePromoted;
    public List<PrefabButtonPromotionPiece> ListPrefabButtonPromotionPiece = new List<PrefabButtonPromotionPiece>();

    public void DisplayPromotionPiece(PrefabBoardFloor csPrefabBoardFloor)
    {
        _csPrefabPiecePromoted = csPrefabBoardFloor.CsPrefabPieceStepOn;

        ClearPromotionPieceButtons();

        foreach (DataPiece cs_datapiece in _scrObjRepoPiece.Items)
        {
            if (cs_datapiece.isWhite == _csPrefabPiecePromoted.CsDataPiece.isWhite && !char.ToLower(cs_datapiece.CId).Equals('k') && !char.ToLower(cs_datapiece.CId).Equals('p'))
            {
                GameObject gameobj_prefab = Instantiate(_gameObjPrefabButtonPromotionPiece, _transGroupPrefabButtonPromotionPiece);

                PrefabButtonPromotionPiece cs_prefab = gameobj_prefab.GetComponent<PrefabButtonPromotionPiece>();
                cs_prefab.CsDataPiece = cs_datapiece;

                cs_prefab.UniEvSelectPromotionPiece.AddListener(delegate
                {
                    PromotePiece(cs_datapiece.CId);
                });

                ListPrefabButtonPromotionPiece.Add(cs_prefab);
            }
        }

        _uniEvShowDisplay.Invoke();
    }

    public void PromotePiece(char cPieceId)
    {
        _uniEvHideDisplay.Invoke();

        DataPiece cs_datapiece = _scrObjRepoPiece.GetDataById(cPieceId);

        _csPrefabPiecePromoted.Promotion(cs_datapiece);

        _csPrefabPiecePromoted = null;
    }

    private void ClearPromotionPieceButtons()
    {
        ListPrefabButtonPromotionPiece.Clear();

        foreach (Transform trans_child in _transGroupPrefabButtonPromotionPiece)
        {
            Destroy(trans_child.gameObject);
        }
    }
}
