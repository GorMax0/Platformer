using UnityEngine;

[CreateAssetMenu(fileName = "Key", menuName = "item/Key", order = 51)]
public class Key : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private int _cost;
    [SerializeField] private Sprite _icon;

    public string Name => _name;
    public int Cost => _cost;
    public Sprite Icon => _icon;
}
