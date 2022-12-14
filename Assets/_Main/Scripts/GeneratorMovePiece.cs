using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorMovePiece : MonoBehaviour
{
    [Header("Classes")]
    [SerializeField] private GeneratorBoardFloor _csGeneratorBoardFloor;
    [SerializeField] private CustomDebug _csCustomDebug;
    private MovePieceVertical _csMovePieceVertical;
    private MovePieceHorizontal _csMovePieceHorizontal;
    private MovePieceDiagonal _csMovePieceDiagonal;
    private MovePieceKnight _csMovePieceKnight;
    private MovePiecePawn _csMovePiecePawn;
    private MovePieceKing _csMovePieceKing;

    [Header("Temp")]
    private List<PrefabBoardFloor> _listPrefabBoardFloorDestinationHighlight = new List<PrefabBoardFloor>();
    private bool _isStill;

    private void Start() {
        _csMovePieceVertical = new MovePieceVertical(this, _csGeneratorBoardFloor);
        _csMovePieceHorizontal = new MovePieceHorizontal(this, _csGeneratorBoardFloor);
        _csMovePieceDiagonal = new MovePieceDiagonal(this, _csGeneratorBoardFloor);
        _csMovePieceKnight = new MovePieceKnight(this, _csGeneratorBoardFloor);
        _csMovePiecePawn = new MovePiecePawn(this, _csGeneratorBoardFloor);
        _csMovePieceKing = new MovePieceKing(this, _csGeneratorBoardFloor);
    }

    public void GenerateMovePiece(PrefabPiece csPrefabPiece)
    {
        //Debug.Log(_csCustomDebug.DebugColor(this.name + " GenerateMovePiece") + " Begin");

        ClearPrefabBoardFloorHighlight();

        PrefabBoardFloor cs_prefabboardfloor_current = csPrefabPiece.CsPrefabBoardFloorCurrent;

        foreach (DataPiece.EnumMovementType enum_movement_type in csPrefabPiece.CsDataPiece.ListMovementType)
        {
            switch (enum_movement_type)
            { //vertical, horizontal, diagonal, knight, pawn, king
                case DataPiece.EnumMovementType.Vertical:
                    _csMovePieceVertical.GenerateMovePiece(cs_prefabboardfloor_current, csPrefabPiece);
                    break;
                case DataPiece.EnumMovementType.Horizontal:
                    _csMovePieceHorizontal.GenerateMovePiece(cs_prefabboardfloor_current, csPrefabPiece);
                    break;
                case DataPiece.EnumMovementType.Diagonal:
                    _csMovePieceDiagonal.GenerateMovePiece(cs_prefabboardfloor_current, csPrefabPiece);
                    break;
                case DataPiece.EnumMovementType.Knight:
                    _csMovePieceKnight.GenerateMovePiece(cs_prefabboardfloor_current, csPrefabPiece);
                    break;
                case DataPiece.EnumMovementType.Pawn:
                    _csMovePiecePawn.GenerateMovePiece(cs_prefabboardfloor_current, csPrefabPiece);
                    break;
                default: //King
                    _csMovePieceKing.GenerateMovePiece(cs_prefabboardfloor_current, csPrefabPiece);
                    break;
            }
        }
    }

    public void SetHighlightFloor(PrefabBoardFloor csPrefabBoardFloor)
    {
        csPrefabBoardFloor.TurnOnHighlight();

        _listPrefabBoardFloorDestinationHighlight.Add(csPrefabBoardFloor);
    }

    public void ClearPrefabBoardFloorHighlight()
    {
        foreach (PrefabBoardFloor cs_prefabboardfloor in _listPrefabBoardFloorDestinationHighlight)
        {
            cs_prefabboardfloor.TurnOffHighlight();
        }

        _listPrefabBoardFloorDestinationHighlight.Clear();
    }
}
