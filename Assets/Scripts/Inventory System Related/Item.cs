using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScrollPlatformerGame/Item", order = 0)]
public class Item : ScriptableObject
{
    public string id;
    public string displayName;
    public Sprite icon;
    public GameObject prefab;
}
