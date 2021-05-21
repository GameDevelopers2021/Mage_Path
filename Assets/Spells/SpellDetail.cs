using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using ItemsInterfaces;
using MageClasses;
using Runes;
using UnityEngine;

namespace Spells
{
    public class SpellDetail
    {
        public string Name;
        public Dictionary<FloatMagicParameter, float> ParameterStandart = new Dictionary<FloatMagicParameter, float>();
        public Dictionary<FloatMagicParameter, float> ParameterAdd = new Dictionary<FloatMagicParameter, float>();
        public Dictionary<FloatMagicParameter, float> ParameterMulti = new Dictionary<FloatMagicParameter, float>();
        public Dictionary<BoolMagicParameters, bool> Flags = new Dictionary<BoolMagicParameters, bool>();
        public Func<Transform, GameObject, List<IMagic>> Cast;
        public List<IEffect> Effects = new List<IEffect>();
        public IInventoryItem InventoryItem;
        public MagicElement Element;
        public List<Action<GameObject, Rigidbody2D, float>> Moves = new List<Action<GameObject, Rigidbody2D, float>>();
        public List<Vector2[]> Shifts = new List<Vector2[]>();
        public List<float[]> Directions = new List<float[]>();
        public List<Transform> Forms = new List<Transform>();
        public List<float> ActiveTime = new List<float>();

        public SpellDetail(string name = "Spell")
        {
            ParameterStandart[FloatMagicParameter.Size] = 1f;
            ParameterStandart[FloatMagicParameter.Damage] = 100f;
            ParameterStandart[FloatMagicParameter.Speed] = 700f;
            ParameterStandart[FloatMagicParameter.Time] = 5f;
            ParameterStandart[FloatMagicParameter.ManaCost] = 10f;
            ParameterStandart[FloatMagicParameter.Cooldown] = 0.8f;
            foreach (var param in Enum.GetValues(typeof(FloatMagicParameter)))
            {
                ParameterAdd[(FloatMagicParameter)param] = 0f;
                ParameterMulti[(FloatMagicParameter) param] = 1f;
            }

            foreach (var flag in Enum.GetValues(typeof(BoolMagicParameters)))
            {
                Flags[(BoolMagicParameters) flag] = false;
            }
        }

        public float GetParameter(FloatMagicParameter parameter)
        {
            return (ParameterStandart[parameter] + ParameterAdd[parameter]) * ParameterMulti[parameter];
        }
    }
}