
    using UnityEngine;

    namespace Gameplay
    {
        public interface IDamageable
        {
            Transform Transform { get; }
            void TakeDamage(int damage);
        }
    }
