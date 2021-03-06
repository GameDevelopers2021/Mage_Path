using System;
using System.Collections.Generic;
using System.Linq;
using CommonInterfaces;
using Items;
using ItemsInterfaces;
using MageClasses;
using Runes;
using Spells;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace SpellBuilderWithRune
{
    public class SpellBuilder : MonoBehaviour
    {
        [SerializeField] private GameObject Runes;
        [SerializeField] private BasicSpell spellObject;
        private Dictionary<ObjectType, Rune> ObjectTypeToRune = new Dictionary<ObjectType, Rune>();
        [SerializeField] private ObjectType[] ObjectTypes;
        [SerializeField] private Color[] ElementsColor;
        [SerializeField] private Material[] ElementsMaterial;

        public ISpell CreateSpell(List<IInventoryItem> items)
        {
            if (items == null)
                throw new ArgumentNullException();
            var spell = new SpellDetail("");
            var types = GetItemsTypes(items);
            foreach (var type in types)
            {
                if (ObjectTypeToRune.ContainsKey(type))
                {
                    ObjectTypeToRune[type].Use(spell);
                    spell.Name += ObjectTypeToRune[type].Name;
                }
            }

            return CreateSpell(spell);
        }
        
        public ISpell CreateSpell(List<Rune> runes)
        {
            return new Spell("", (transform1, o) => null, new IEffect[]{}, 0.1f, 10f, null);
        }

        public ISpell CreateSpell(SpellDetail spell)
        {
            if(spell.Forms.Count == 0)
                return new Spell("", (transform1, o) => null, new IEffect[]{}, 0.1f, 10f, 
                    new InventoryItem(null, "Crafted Spell"));
            if (spell.Directions.Count == 0)
            {
                spell.Shifts.Add(new[] {Vector2.zero});
                spell.Directions.Add(new[] {0f});
            }

            if (spell.Moves.Count == 0)
            {
                spell.Moves.Add((a, o, f) => { });
            }
            for (int i = 0; i < spell.Forms.Count; i++)
            {
                //var spriteRender = spell.Forms[i].GetComponent<SpriteRenderer>();
                //spriteRender.color = ElementsColor[(int) spell.Element];
            }
            spell.InventoryItem = new InventoryItem(
                spell.Forms[0].GetComponent<SpriteRenderer>().sprite,
                spell.Name);
            spell.Effects.Add(new SilmpleDamage(
                "Damage",
                (int)spell.GetParameter(FloatMagicParameter.Damage),
                spell.Element));

            spell.ActiveTime = new List<float>();
            for (int i = 0; i < spell.Moves.Count; i++)
            {
                spell.ActiveTime.Add(spell.GetParameter(FloatMagicParameter.Time) / spell.Moves.Count);
            }
            
            spell.Cast = (transf, go) =>
            {
                var n = spell.Directions[0].Length;
                var magicsTransf = new List<Transform>();
                var magics = new List<IMagic>();
                for (int i = 0; i < n; i++)
                {
                    magicsTransf.Add(Instantiate(spell.Forms[0]));
                    magicsTransf.Last().localScale *= spell.GetParameter(FloatMagicParameter.Size);
                    magicsTransf.Last().position = transf.position + (transf.rotation 
                                                                      * spell.Shifts[0][i] 
                                                                      * spell.GetParameter(FloatMagicParameter.Size));
                    magicsTransf.Last().rotation = transf.rotation;
                    magicsTransf.Last().Rotate(0, 0, spell.Directions[0][i]);
                    
                    var spriteRender = magicsTransf.Last().GetComponent<SpriteRenderer>();
                    spriteRender.material = ElementsMaterial[(int) spell.Element];
                    //spriteRender.color = ElementsColor[(int) spell.Element];
                    
                    magics.Add(new Magic(
                        spell.Moves.ToArray(),
                        spell.ActiveTime.ToArray(),
                        spell.Effects.ToArray(),
                        magicsTransf.Last().gameObject,
                        false,
                        spell.Flags[BoolMagicParameters.Tunel],
                        false
                        ));
                    var tmp = magicsTransf.Last().GetComponent<MagicUnity>();
                    tmp.StartTime = Time.time;
                    tmp.Magic = (Magic) magics.Last();
                }
                return magics;
            };
            return new Spell(spell);
        }

        private List<ObjectType> GetItemsTypes(List<IInventoryItem> items)
        {
            return items.Select(item => item.Identifier).ToList();
        }

        private void Awake()
        {
            var copyRunes = Instantiate(Runes);
            var runes = copyRunes.GetComponents<Rune>();
            for (int i = 0; i < ObjectTypes.Length; i++)
            {
                ObjectTypeToRune[ObjectTypes[i]] = runes[i];
            }
        }
    }
}