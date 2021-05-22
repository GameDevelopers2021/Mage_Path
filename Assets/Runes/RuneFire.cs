using System;
using ItemsInterfaces;
using MageClasses;
using UnityEngine;

namespace Runes
{
    public class RuneFire : RuneElement
    {
        [SerializeField] private float period;
        [SerializeField] private int damage;
        [SerializeField] private int tics;

        private void Awake()
        {
            SpecialEffect = new PeriodDamage("Fire", damage, period, tics, MagicElement.Fire);
        }
    }
}