using UnityEngine;
using UniRx;
using System;

public abstract class ItemBase : MonoBehaviour
{
    [SerializeField, Tooltip("対応するItemData")] ItemData _itemDataSource = null;
    public ItemData ItemDataSource => _itemDataSource;
    Board _board = default;
    int[] _myIndex = new int[2];
    public int[] Index { get => _myIndex; set => _myIndex = value; }
    [SerializeField, Tooltip("積み終わったかどうか")]
    ReactiveProperty<bool> _isStacked = new ReactiveProperty<bool>();
    public IReadOnlyReactiveProperty<bool> IsStacked => _isStacked;
    private IDisposable subscription;



    private void Awake()
    {

    }
    private protected virtual void Start()
    {
        subscription = _isStacked.Subscribe(isStacked => OnStacked());
        _board = Board.Instance;
    }


    private protected virtual void Update()
    {

    }

    /// <summary> 降ろせるかどうかの判定 </summary>
    public bool CanDescend()
    {
        if (_isStacked.Value ) return false; //既に積まれてたら降ろせない
        else
        {
            if (_board.Cells[_myIndex[0] + 1, _myIndex[1]].HasItem || _board.Column - 1 == _myIndex[0]) //下のセルにアイテムがあるか一番下の場合
            {
                _isStacked.Value = true; //切り替える
                return false;
            }
            else return true;
        }
    }

    public abstract void OnStacked();

    private void OnDestroy()
    {
        subscription?.Dispose();
    }

}
