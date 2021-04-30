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
            var health = unit.GetComponent<HealthSystem>();
            health.TakeDamage(Damage, Element);
        }
    }
}