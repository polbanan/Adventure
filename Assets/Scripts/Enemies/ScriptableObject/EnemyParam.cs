using UnityEngine;

[CreateAssetMenu(fileName = "EnemyParam", menuName = "Scriptable Objects/EnemyParam")]
public class EnemyParam : ScriptableObject
{
    public int _maxHealth = 100;
    public int currentHealth = 100;
    public int Damage = 15;
}
