using System;
using System.Collections.Generic;
using System.Linq;
using CommonInterfaces;
using Items;
using ItemsInterfaces;
using MageClasses;
using Runes;
using UnityEngine;

namespace SpellBuilderWithRune
{
    public class SpellBuilder : MonoBehaviour
    {
        private GameObject obj;
        [SerializeField] private BasicSpell spellObject;

        public ISpell CreateSpell(List<IInventoryItem> items)
        {
            if (items == null)
                throw new ArgumentNullException();
            
            // if (items.Count == 0)
            //     return new Spell(
            //         "", (transform1, o) => null, 
            //         new IEffect[]{}, 
            //         0.1f, 
            //         10f, 
            //         InventoryItem.DefaultItem);

            var types = GetItemsTypes(items);
            if (types.Contains(ObjectType.Rune) && types.Contains(ObjectType.RuneOfBigSize))
            {
                return new Spell(
                    spellObject.Name,
                    spellObject.Cast,
                    spellObject.Effects,
                    spellObject.cooldownInSeconds,
                    spellObject.ManaCost,
                    new InventoryItem(
                        spellObject.inventoryImage,
                        spellObject.inventoryName,
                        ObjectType.Null));
            }
            
            return new Spell("", (transform1, o) => null, new IEffect[]{}, 0.1f, 10f, 
                new InventoryItem(null, "Crafted Spell"));
        }
        
        public ISpell CreateSpell(List<Rune> runes)
        {
            return new Spell("", (transform1, o) => null, new IEffect[]{}, 0.1f, 10f, null);
        }

        private List<ObjectType> GetItemsTypes(List<IInventoryItem> items)
        {
            return items.Select(item => item.Identifier).ToList();
        }
    }
}