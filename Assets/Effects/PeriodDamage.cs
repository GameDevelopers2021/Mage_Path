using System.Collections;
using System.Threading;
using MageClasses;
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
            var enumerator = Wait(Period, ticCount);
            while (enumerator.MoveNext())
            {
                damage.ApplyEffect(unit);
            }
        }

        private IEnumerator Wait(float time, int count)
        {
            for (int i = 0; i < count; i++)
            {
                yield return new WaitForSeconds(time);
            }
        }
    }
}