using Gameplay.Health;
using Services;
using UnityEngine;

namespace Gameplay
{
    public abstract class Character : MonoBehaviour, IDamageable
    { 
        [field: SerializeField] public ObjectTypeId ObjectTypeId { get; protected set; }
        public IHealth Health { get; protected set; }

        public void TakeDamage(int damage)
       {
           Health.Decrease(damage);
       }
    }
}