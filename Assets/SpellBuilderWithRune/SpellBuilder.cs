using System;
using System.Collections.Generic;
using ItemsInterfaces;
using MageClasses;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace SpellBuilderWithRune
{
    public class SpellBuilder : MonoBehaviour
    {
        [SerializeField] private GameObject emptySpell;
        private void Start()
        {
        }

        public ISpell CreateSpell(List<IRune> runes)
        {
            
            
            return new Spell("", (transform1, o) => null, new IEffect[]{}, 0.1f, 10f);
        }
    }
}