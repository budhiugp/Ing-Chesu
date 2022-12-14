using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliminatorPiece : MonoBehaviour
{
    [SerializeField] private Transform _transGraveyardWhite;
    [SerializeField] private List<PrefabPiece> _listPrefabPieceWhite = new List<PrefabPiece>();
    [SerializeField] private Transform _transGraveyardBlack;
    [SerializeField] private List<PrefabPiece> _listPrefabPieceBlack = new List<PrefabPiece>();

    [Header("Classes")]
    [SerializeField] private CustomDebug _csCustomDebug;

    [Header("Other")]
    [SerializeField] private float _fPieceDistance = 1f;
    [SerializeField] private List<float> _listAvailableZPos = new List<float>();

    public void EliminatePiece(PrefabPiece csPrefabPiece)
    {
        Debug.Log(_csCustomDebug.DebugColor(this.name + " EliminatePiece") + " Begin on csPrefabPiece : " + csPrefabPiece.CsDataPiece.DebugThis());

        if (csPrefabPiece.CsDataPiece.isWhite)
        {
            csPrefabPiece.transform.SetParent(_transGraveyardWhite);

            _listPrefabPieceWhite.Add(csPrefabPiece);

            RepositionPrefabPiece(_listPrefabPieceWhite, _transGraveyardWhite);
        }
        else
        {
            csPrefabPiece.transform.SetParent(_transGraveyardBlack);

            _listPrefabPieceBlack.Add(csPrefabPiece);

            RepositionPrefabPiece(_listPrefabPieceBlack, _transGraveyardBlack);
        }

    }

    private void RepositionPrefabPiece(List<PrefabPiece> _listPrefabPiece, Transform transGraveyard)
    {
        List<float> list_available_zpos = GenerateAvailableZPositions(_listPrefabPiece.Count);

        for (int i = 0; i < _listPrefabPiece.Count; i++)
        {
            Vector3 v3_pos = new Vector3(transGraveyard.localPosition.x, transGraveyard.localPosition.y, list_available_zpos[i]);
            _listPrefabPiece[i].MovePos(v3_pos);
        }
    }

    private List<float> GenerateAvailableZPositions(int iPieceCount)
    {
        _listAvailableZPos.Clear();

        float f_length = _fPieceDistance * (iPieceCount - 1);
        float f_firstpoint = f_length / -2;

        for (int i = 0; i < iPieceCount; i++)
        {
            float f_point_z = f_firstpoint + (i * _fPieceDistance);

            _listAvailableZPos.Add(f_point_z + transform.position.z);
        }

        _listAvailableZPos.Reverse();

        return _listAvailableZPos;
    }
}
