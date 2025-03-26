using System;
using UnityEngine;

namespace AttackSystem
{
    [Serializable]
    public class AttackComboElement
    {
        [SerializeField, Min(0f)] private float _baseDamagePortion;
        [SerializeField, Min(0f)] private float _cooldown;

        public void CalculateDamage(float baseDamage) =>
            Damage = baseDamage * _baseDamagePortion;

        public float Damage { get; private set; }
        public float Cooldown => _cooldown;
    }
}