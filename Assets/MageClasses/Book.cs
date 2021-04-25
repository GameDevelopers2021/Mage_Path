using System;
using ItemsInterfaces;
using UnitsInterfaces;
using UnityEngine;

namespace MageClasses
{
    public class Book: MonoBehaviour, IItem
    {
        public string Name { get; }

        [SerializeField] private GameObject magicPartical; 
        [SerializeField] private GameObject unit; 
        private ISpell[] _spells;
        private int _splellInd;
        private float[] _cooldowns;
        private float[] _lastUseSpells;

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
            _splellInd = (_splellInd + 1) % _spells.Length;
        }
        
        public void SpellIndexerDown()
        {
            _splellInd = (_splellInd + _spells.Length - 1) % _spells.Length;
        }

        public void Cast()
        {
            if (_spells[_splellInd] != null && RemainingCooldownTime(_splellInd) == 0)
            {
                _lastUseSpells[_splellInd] = Time.time;
                _spells[_splellInd].Cast(unit.transform, magicPartical);
            }
        }

        public bool WriteSpell(ISpell spell, int spellIndex)
        {
            if (!SpellIndexIsValid(spellIndex))
            {
                throw new IndexOutOfRangeException();
            }
            if (_spells[spellIndex] == null)
            {
                _spells[spellIndex] = spell;
                _cooldowns[spellIndex] = spell.Cooldown;
                _lastUseSpells[spellIndex] = -spell.Cooldown;
                return true;
            }
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
            throw new System.NotImplementedException(); 
        }
    }
}