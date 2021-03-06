using System;
using System.Collections.Generic;
using ItemsInterfaces;
using UnityEngine;
using Unity.Mathematics;

namespace MageClasses
{
    public class BasicSpell: MonoBehaviour, ISpell
    {
        public float speed = 0.1f; 
        public float cooldownInSeconds = 1.5f;
        [SerializeField] private int simpleDamagePower = 10;
        [SerializeField] private float manaCost = 10f;
        [SerializeField] GameObject MagicPartical;
        public string Name { get; }

        public IEffect[] Effects { get; }
        public float Cooldown => cooldownInSeconds;
        public float ManaCost => manaCost;
        public IInventoryItem InventoryItem { get; }
        public Sprite inventoryImage;
        public string inventoryName;

        public List<IMagic> Cast(Transform playersTransform, GameObject unit)
        {
            var newMagic = Instantiate(MagicPartical);
            newMagic.transform.rotation = playersTransform.rotation;
            newMagic.transform.position = playersTransform.position;
            var magicScript = new Magic(
                new[] {(Action<GameObject, Rigidbody2D, float>) MoveForward},
                new[] {5f},
                new []
                {
                    new SilmpleDamage("damage", simpleDamagePower, MagicElement.Force)
                },
                newMagic
                );
            var magicControler = newMagic.GetComponent<MagicUnity>();
            magicControler.StartTime = Time.time;
            magicControler.Magic = magicScript;
            return new List<IMagic> {magicScript};
        }

        public void MoveForward(GameObject obj, Rigidbody2D rig, float time)
        {
            var angle = rig.rotation / 180 * math.PI;
            rig.velocity = new Vector2(speed * math.cos(angle), speed * math.sin(angle)) * Time.fixedDeltaTime;
        }
        
        public BasicSpell(IEffect[] effects, string name)
        {
            Effects = effects;
            Name = name;
            cooldownInSeconds = 1.5f;
        }
    }
}