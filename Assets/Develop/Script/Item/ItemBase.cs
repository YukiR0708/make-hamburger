using UnityEngine;
using UniRx;
using System;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public abstract class ItemBase : MonoBehaviour
{
    [SerializeField, Tooltip("対応するItemData")] ItemData _itemDataSource = null;
    public ItemData ItemDataSource => _itemDataSource;
    Rigidbody2D _rigidbody2D = default;

    [SerializeField, Tooltip("積み終わったかどうか")]
    ReactiveProperty<bool> _isStacked = new ReactiveProperty<bool>();
    public IReadOnlyReactiveProperty<bool> IsStacked => _isStacked;
    private IDisposable subscription;



    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.bodyType = RigidbodyType2D.Static;
    }
    private protected virtual void Start()
    {
        subscription = _isStacked.Subscribe(isStacked => OnStacked());
    }


    private protected virtual void Update()
    {
        if (!_isStacked.Value) JudgeStacked();
    }

    /// <summary> 積まれたかどうか判定する </summary>
    private void JudgeStacked()
    {
        //判定する
        _isStacked.Value = true;　//切り替える
    }

    public abstract void OnStacked();

    private void OnDestroy()
    {
        subscription?.Dispose();
    }

}
