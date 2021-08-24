using UnityEngine;

[CreateAssetMenu(fileName = "New Apple Config", menuName = "Configurations/Apple Config", order = 1)]
public class AppleConfig : ScriptableObject
{
    [SerializeField, Min(0.1f)]
    private float _cooldown = 5f;

    [SerializeField, Min(1)]
    private int _value = 1;

    public float Cooldown => _cooldown;
    public int Value => _value;
}
