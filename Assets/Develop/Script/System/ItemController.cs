//日本語対応
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    [SerializeField] List<GameObject> _items = new();
    [Tooltip("生成するアイテム")] Dictionary<GameObject, ItemBase> _spawnItems = new();
    [SerializeField, Tooltip("生成するアイテムの数"), Range(0, 3)] int _count = 0;
    Board _board = default;

    private void Start()
    {
        _board = Board.Instance;
    }
    /// <summary> アイテムを生成するメソッド  </summary>
    public void SpawnItem()
    {
        //アイテムを抽選する（被りあり）
        for (int i = 0; i < _count;)
        {
            int itemNum = Random.Range(0, _spawnItems.Count);
            GameObject item = _items[itemNum];
            _spawnItems.Add(item, _items[itemNum].GetComponent<ItemBase>());
            //Cellの最上列のランダムな箇所にアイテムを生成する
            var r = Random.Range(0, _board.Rows);
            var c = Random.Range(0, _board.Column);
            var cell = _board.Cells[r, c];
            if (!cell.HasItem)
            {
                Instantiate(item, cell.gameObject.transform);
                cell.ChangeState();
                i++;
            }
        }
    }

    /// <summary> アイテムを下に移動するメソッド </summary>
    public void DescendItem()
    {
        foreach (var item in _spawnItems)
        {
            if (item.Value.CanDescend())
            {
                Cell oldCell = item.Key.GetComponentInParent<Cell>();
                //元の位置の親Cellの状態を変える
                oldCell.ChangeState();
                //親を1個下に切り替えて移動する
                Cell nextCell = _board.Cells[item.Value.Index[0] + 1, item.Value.Index[1]];
                item.Key.transform.SetParent(nextCell.gameObject.transform);
                item.Key.transform.position = nextCell.gameObject.transform.position;
                //新しい位置の親Cellの状態を変える
                nextCell.ChangeState();
            }
        }
    }
}
