using System;
using UnityEngine;

namespace Interactable
{
    public class Damageable : MonoBehaviour, IDamageable
    {
        public event Action<int> TakingDamage;

        public void TakeDamage(int amount)
        {
            TakingDamage?.Invoke(amount);
        }
    }
}
