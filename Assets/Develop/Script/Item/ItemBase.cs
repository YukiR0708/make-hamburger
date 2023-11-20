//日本語対応
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent (typeof(BoxCollider2D))]
public class ItemBase : MonoBehaviour
{
    [SerializeField, Tooltip("対応するItemData")] ItemData _itemDateSource = null;
    public ItemData ItemDateSource => _itemDateSource;
    Rigidbody2D _rigidbody2D = default;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.bodyType = RigidbodyType2D.Static;
    }
}
