using UnityEngine;

[CreateAssetMenu(menuName = "MyScriptableObj/ Create ItemData")]
public class ItemData : ScriptableObject
{
    public enum ItemType
    {
        Standard,
        Buns,
    }
    [SerializeField, Tooltip("アイテムの種類")]
    private ItemType _type = ItemType.Standard;
    public ItemType Type => _type;


    [Header("数値")]
    [SerializeField, Tooltip("アイテムを消したときのスコア")]
    float _score = 0f;
    public float Score => _score;

    [Header("ビジュアル")]
    [SerializeField, Tooltip("アイテムの画像")]
    Sprite _itemSprite;
    public Sprite ItemSprite => _itemSprite;
}
