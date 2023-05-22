using UnityEngine;

public class Enemy : MonoBehaviour, IDamagaeble
{
    public IHealth Health { get; set; }

    private void Start()
    {
        print("Хп врага" + Health.CurrentValue);
    }
    
    public void TakeDamage(int damage)
    {
        Health.Decrease(damage);
        print(Health.CurrentValue);
    }
}