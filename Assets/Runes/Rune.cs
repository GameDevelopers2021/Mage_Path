using CommonInterfaces;
using SpellBuilderWithRune;
using Spells;
using UnityEngine;

namespace Runes
{
    public abstract class Rune : MonoBehaviour
    {
        [SerializeField] public string Name;
        public abstract void Use(SpellDetail spell);
    }
}