using UnityEngine;

[CreateAssetMenu(fileName = "PlayerParam", menuName = "Scriptable Objects/PlayerParam")]
public class PlayerParam : ScriptableObject
{
    public int _maxHealth = 100;
    public int currentHealth;
    public int Damage = 10;

    public void ResetHealth()
    {
        currentHealth = _maxHealth;
    }
}
