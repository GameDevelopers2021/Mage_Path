using System.Collections.Generic;
using SpellBuilderWithRune;
using UnityEngine;

namespace Runes
{
    public class RuneParameter : Rune
    {
        public RuneParameter(string name, Dictionary<FloatMagicParameter, float> parameterAdd, Dictionary<FloatMagicParameter, float> parameterMulti, Dictionary<BoolMagicParameters, bool> flags)
        {
            Name = name;
            ParameterAdd = parameterAdd;
            ParameterMulti = parameterMulti;
            Flags = flags;
        }

        public RuneType Type => RuneType.Parameter;
        [SerializeField] public string Name { get; }
        
        [SerializeField] public Dictionary<FloatMagicParameter, float> ParameterAdd { get; }
        [SerializeField] public Dictionary<FloatMagicParameter, float> ParameterMulti { get; }
        [SerializeField] public Dictionary<BoolMagicParameters, bool> Flags { get; }
    }
}