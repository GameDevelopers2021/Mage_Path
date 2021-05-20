using System;
using System.Collections.Generic;
using ItemsInterfaces;
using Runes;
using Spells;
using UnitsClasses;
using UnityEngine;
using Unity.Mathematics;

namespace MageClasses
{
    public class Spell : ISpell
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
        public IInventoryItem InventoryItem { get; }
        public SpellDetail Detail;
        
        public List<IMagic> Cast(Transform casterTransform, GameObject caster)
        {
            var mana = caster.GetComponent<ManaSystem>();
            if(mana.UseMana(ManaCost))
                return _cast(casterTransform, caster);
            return null;
        }

        public Spell(string name, Func<Transform, GameObject, List<IMagic>> cast,
            IEffect[] effects, float cooldown, float manacost, IInventoryItem inventoryItem)
        {
            _name = name;
            _cast = cast;
            _cooldown = cooldown;
            _manaCost = manacost;
            _effects = effects;
            InventoryItem = inventoryItem;
        }

        public Spell(SpellDetail spellDetail)
        {
            Detail = spellDetail;
            _name = spellDetail.Name;
            _cast = spellDetail.Cast;
            _cooldown = spellDetail.GetParameter(FloatMagicParameter.Cooldown);
            _manaCost = spellDetail.GetParameter(FloatMagicParameter.ManaCost);
            InventoryItem = spellDetail.InventoryItem;
        }
    }
}