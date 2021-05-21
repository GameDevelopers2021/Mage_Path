using System;
using System.Collections.Generic;
using SpellBuilderWithRune;
using Spells;
using UnityEngine;

namespace Runes
{
    public class RuneParameter : Rune
    {
        public override void Use(SpellDetail spell)
        {
            foreach (var add in _parameterAdd)
            {
                spell.ParameterAdd[add.Key] += add.Value;
            }

            foreach (var mult in _parameterMulti)
            {
                spell.ParameterMulti[mult.Key] *= mult.Value;
            }

            foreach (var fl in _flags)
            {
                spell.Flags[fl.Key] = fl.Value;
            }
        }

        private Dictionary<FloatMagicParameter, float> _parameterAdd = new Dictionary<FloatMagicParameter, float>();
        private Dictionary<FloatMagicParameter, float> _parameterMulti = new Dictionary<FloatMagicParameter, float>();
        private Dictionary<BoolMagicParameters, bool> _flags = new Dictionary<BoolMagicParameters, bool>();

        [SerializeField] private FloatMagicParameter[] ParametersAdd;
        [SerializeField] private float[] Add;
        [SerializeField] private FloatMagicParameter[] ParametersMulti;
        [SerializeField] private float[] Multi;
        [SerializeField] private BoolMagicParameters[] Flags;

        private void Start()
        {
            for (int i = 0; i < ParametersAdd.Length; i++)
            {
                _parameterAdd[ParametersAdd[i]] = Add[i];
            }
            for (int i = 0; i < ParametersMulti.Length; i++)
            {
                _parameterMulti[ParametersMulti[i]] = Multi[i];
            }
            foreach (var flag in Flags)
            {
                _flags[flag] = true;
            }
        }
    }
}