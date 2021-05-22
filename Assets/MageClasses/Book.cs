using System;
using System.Collections.Generic;
using System.Linq;
using Items;
using ItemsInterfaces;
using UnitsInterfaces;
using UnityEngine;

namespace MageClasses
{
    public class Book: MonoBehaviour, IItem
    {
        public string Name { get; }
        
        [SerializeField] public GameObject unit;
        [SerializeField] public Transform CastTransform;
        private ISpell[] _spells;
        private int _splellInd;
        private float[] _cooldowns;
        private float[] _lastUseSpells;
        private List<IMagic> _lastMagics = null;

        public Book(string name)
        {
            Name = name;
        }

        public void SetSize(int size) //tmp void delite this shit
        {
            _spells = new ISpell[size];
            _cooldowns = new float[size];
            _lastUseSpells = new float[size];
        }

        public ISpell[] Spells => _spells;
        public int SpellIndexer => _splellInd;
        public float[] Cooldowns => _cooldowns;
        public int Length => _spells.Length;
        
        public float RemainingCooldownTime(int spellIndex)
        {
            if (!SpellIndexIsValid(spellIndex))
                throw new IndexOutOfRangeException();
            return _lastUseSpells[spellIndex] + _cooldowns[spellIndex] - Time.time < 0
                ? 0
                : _lastUseSpells[spellIndex] + _cooldowns[spellIndex] - Time.time;
        }

        public void SpellIndexerUp()
        {
            DeactivateCurrentSpellInMenu();
            _splellInd = (_splellInd + 1) % _spells.Length;
        }
        
        public void SpellIndexerDown()
        {
            DeactivateCurrentSpellInMenu();
            _splellInd = (_splellInd + _spells.Length - 1) % _spells.Length;
        }

        public void Cast()
        {
            if (_spells[_splellInd] != null && RemainingCooldownTime(_splellInd) == 0)
            {
                var magics = _spells[_splellInd].Cast(CastTransform, unit);
                if (magics != null)
                {
                    _lastMagics = magics;
                    _lastUseSpells[_splellInd] = Time.time;
                }
            }
        }

        public bool WriteSpell(ISpell spell, int spellIndex)
        {
            if (!SpellIndexIsValid(spellIndex))
            {
                throw new IndexOutOfRangeException();
            }
            /*if (_spells[spellIndex] == null)
            {*/
                _spells[spellIndex] = spell;
                _cooldowns[spellIndex] = spell.Cooldown;
                _lastUseSpells[spellIndex] = -spell.Cooldown;
                return true;
            //}
            return false;
        }

        public void SwapSpells(int spellA, int spellB)
        {
            if (SpellIndexIsValid(spellA) && SpellIndexIsValid(spellB))
            {
                ISpell tmp = _spells[spellA];
                _spells[spellA] = _spells[spellB];
                _spells[spellB] = tmp;
            }
        }

        public bool SpellIndexIsValid(int index)
        {
            return !(index < 0 || index > _spells.Length);
        }
        
        public void Use(IUnit usingUnit) // TODO Add to inventory
        {
            throw new NotImplementedException(); 
        }

        public List<IInventoryItem> GetSpellsAsInventoryItems()
        {
            var k = -1;
            return _spells
                .Select(spell =>
                {
                    k++;
                    var inventoryItem = (IInventoryItem) InventoryItem.DefaultItem.Clone();
                    if (spell != null)
                        inventoryItem = spell.InventoryItem;
                    
                    if (k == SpellIndexer)
                        inventoryItem.Activate();
                    return inventoryItem;
                })
                .ToList();
        }

        private void DeactivateCurrentSpellInMenu()
        {
            var spell = _spells[_splellInd];
            if (spell != null)
                _spells[_splellInd].InventoryItem.Deactivate();
        }
    }
}