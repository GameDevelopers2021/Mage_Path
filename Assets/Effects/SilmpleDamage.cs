using MageClasses;
using UnitsClasses;
using UnityEngine;

namespace ItemsInterfaces
{
    public class SilmpleDamage: IEffect
    {
        public string Name { get; }
        public int Damage;
        public MagicElement Element;

        public SilmpleDamage(string name, int damage, MagicElement element)
        {
            Name = name;
            Damage = damage;
            Element = element;
        }

        public void ApplyEffect(GameObject unit)
        {
            if(unit == null)
                return;
            var health = unit.GetComponent<HealthSystem>();
            if (health == null)
                return;
            health.TakeDamage(Damage, Element);
        }
    }
}