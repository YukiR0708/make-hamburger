//日本語対応
using UnityEngine;

public class Cell : MonoBehaviour
{
    [Tooltip("アイテムがあるかどうか")] bool _hasItem = false;
    public bool HasItem => _hasItem;

    public void ChangeState() => _hasItem = !_hasItem;
}
