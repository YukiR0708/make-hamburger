using UnityEngine;

[CreateAssetMenu(menuName = "MyScriptableObj/ Create ItemData")]
public class ItemData : ScriptableObject
{
    public enum ItemType
    {
        None,   //未設定
        TopBuns,   //上のバンズ
        BottomBuns, //下のバンズ
        Tomatos, //トマト
        Cheese, //チーズ
        Patties, //肉
    }
    [SerializeField, Tooltip("アイテムの種類")]
    private ItemType _type = ItemType.None;
    public ItemType Type => _type;

    [SerializeField, Tooltip("加算するスコア")]
    private float _score = 0f;
    public float Score => _score;   

}
