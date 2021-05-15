using CommonInterfaces;
using SpellBuilderWithRune;
using UnityEngine;

namespace Runes
{
    public class Rune : MonoBehaviour
    {
        public RuneType Type { get; }
        [SerializeField] public string Name;
    }
}