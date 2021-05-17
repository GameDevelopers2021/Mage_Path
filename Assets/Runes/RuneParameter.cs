using System.Collections.Generic;
using SpellBuilderWithRune;
using UnityEngine;

namespace Runes
{
    public class RuneParameter : Rune
    {
        public RuneType Type => RuneType.Parameter;

        [SerializeField] public Dictionary<FloatMagicParameter, float> ParameterAdd;
        [SerializeField] public Dictionary<FloatMagicParameter, float> ParameterMulti;
        [SerializeField] public Dictionary<BoolMagicParameters, bool> Flags;
    }
}