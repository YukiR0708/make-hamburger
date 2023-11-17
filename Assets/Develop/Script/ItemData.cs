using UnityEngine;

[CreateAssetMenu(menuName = "MyScriptableObj/ Create ItemData")]
public class ItemData : ScriptableObject
{
    [Header("数値")]
    [SerializeField, Tooltip("アイテムを消したときのスコア")]
    float _score = 0f;
    public float Score => _score;

    [Header("ビジュアル")]
    [SerializeField, Tooltip("アイテムの画像")]
    Sprite _itemSprite;
    public Sprite ItemSprite => _itemSprite;
}
