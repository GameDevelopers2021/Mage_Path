using System.Collections;
using System.Threading;
using MageClasses;
using Units.UnitsClasses;
using Unity.Collections;
using UnityEngine;

namespace ItemsInterfaces
{
    public class PeriodDamage : IEffect
    {
        public PeriodDamage(string name, int damage, float period, int ticCount, MagicElement element)
        {
            Name = name;
            Damage = damage;
            Period = period;
            ticCount = ticCount;
            Element = element;
        }

        private int ticCount;

        public string Name { get; }
        public int Damage { get; }
        public float Period { get; }
        public MagicElement Element { get; }
        public int TicCount => ticCount;
        public void ApplyEffect(GameObject unit)
        {
            if(ticCount <= 0)
                return;
            var damage = new SilmpleDamage(Name, Damage, Element);
            var effects = unit.GetComponent<EffectsSystem>();
            effects.Coroutine(ApplyEffect(unit, Period, ticCount, damage));
        }

        private IEnumerator ApplyEffect(GameObject unit, float time, int count, SilmpleDamage damage)
        {
            for (int i = 0; i < count; i++)
            {
                yield return new WaitForSeconds(time);
                damage.ApplyEffect(unit);
            }
        }
    }
}