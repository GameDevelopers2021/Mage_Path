using SpellBuilderWithRune;
using UnityEngine;

namespace Runes
{
    public class RuneForm : Rune
    {
        public RuneType Type => RuneType.Form;
        
        [SerializeField] public Transform Form;
    }
}