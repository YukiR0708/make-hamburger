//日本語対応
using UnityEngine;
using UnityEngine.UI;

public class Board : SingletonMonoBehaviour<Board> 
{
    [SerializeField, Tooltip("横の要素数")] int _rows = 0;
    public int Rows => _rows;
    [SerializeField, Tooltip("縦の要素数")] int _columns = 0;
    public int Column => _columns;
    GridLayoutGroup _gridLayoutGroup = default;
    [SerializeField,Tooltip("CellのPrefab")]Cell _cellPrefab = default;
    [Tooltip("Cellの配列")] Cell[,] cells;
    public Cell[,] Cells => cells;

    protected override bool dontDestroyOnLoad => throw new System.NotImplementedException();

    private void Start()
    {
        TryGetComponent<GridLayoutGroup>(out _gridLayoutGroup);
        var parent = _gridLayoutGroup.gameObject.transform;
        cells = new Cell[_columns, _rows];
        for (var c = 0; c < _columns; c++)
        {
            for (var r = 0; r < _rows; r++)
            {
                var cell = Instantiate(_cellPrefab);
                cells[c, r] = cell;
                cell.transform.SetParent(parent);
            }
        }
    }
}
