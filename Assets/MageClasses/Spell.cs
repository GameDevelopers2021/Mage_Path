using System;
using System.Collections.Generic;
using ItemsInterfaces;
using UnitsClasses;
using UnityEngine;
using Unity.Mathematics;

namespace MageClasses
{
    public class Spell : MonoBehaviour, ISpell
    {
        private string _name;
        private Func<Transform, GameObject, List<IMagic>> _cast;
        private float _cooldown;
        private float _manaCost;
        private IEffect[] _effects;
        
        public string Name => _name;
        public IEffect[] Effects => _effects;
        public float Cooldown => _cooldown;
        public float ManaCost => _manaCost;
        
        public List<IMagic> Cast(Transform casterTransform, GameObject caster)
        {
            var mana = caster.GetComponent<ManaSystem>();
            if(mana.UseMana(ManaCost))
                return _cast(casterTransform, caster);
            return null;
        }

        public void SetSpell(string name, Func<Transform, GameObject, List<IMagic>> cast,
            IEffect[] effects, float cooldown, float manacost)
        {
            _name = name;
            _cast = cast;
            _cooldown = cooldown;
            _manaCost = manacost;
            _effects = effects;
        }
    }
}