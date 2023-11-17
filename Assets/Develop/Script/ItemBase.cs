//日本語対応
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBase : MonoBehaviour
{
    [SerializeField, Tooltip("対応するItemData")] ItemData _itemDateSource = null;
    public ItemData ItemDateSource => _itemDateSource;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
