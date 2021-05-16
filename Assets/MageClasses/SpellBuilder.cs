using System;
using System.Collections.Generic;
using Items;
using ItemsInterfaces;
using MageClasses;
using Runes;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace SpellBuilderWithRune
{
    public class SpellBuilder
    {
        private GameObject obj;

        public ISpell CreateSpell(List<IInventoryItem> items)
        {
            return new Spell("", (transform1, o) => null, new IEffect[]{}, 0.1f, 10f, 
                new InventoryItem(null, "Crafted Spell"));
        }
        
        public ISpell CreateSpell(List<Rune> runes)
        {
            return new Spell("", (transform1, o) => null, new IEffect[]{}, 0.1f, 10f, null);
        }
    }
}