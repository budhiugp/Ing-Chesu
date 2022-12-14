using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PrefabButtonPromotionPiece : MonoBehaviour
{
    [SerializeField] private Text _textPieceName;

    [SerializeField] private DataPiece _csDataPiece;

    [HideInInspector] public UnityEvent UniEvSelectPromotionPiece;

    public DataPiece CsDataPiece
    {
        set
        {
            _csDataPiece = value;
            _textPieceName.text = value.SName;
        }
    }

    public void SelectPromotionPiece()
    {
        UniEvSelectPromotionPiece.Invoke();
    }
}
