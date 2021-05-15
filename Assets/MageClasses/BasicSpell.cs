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
        [SerializeField] GameObject MagicPartical;
        public string Name { get; }

        public IEffect[] Effects { get; }
        public float Cooldown => cooldownInSeconds;
        public float ManaCost => 10f;

        public List<IMagic> Cast(Transform playersTransform, GameObject unit)
        {
            var newMagic = Instantiate(MagicPartical);
            newMagic.transform.rotation = playersTransform.rotation;
            newMagic.transform.position = playersTransform.position;
            var magicScript = new Magic(
                new[] {(Action<GameObject, float>) MoveForward},
                new[] {5f},
                new []
                {
                    new SilmpleDamage("damage",50, MagicElement.Force)
                },
                newMagic
                );
            var magicControler = newMagic.GetComponent<MagicUnity>();
            magicControler.StartTime = Time.time;
            magicControler.Magic = magicScript;
            return new List<IMagic> {magicScript};
        }

        public void MoveForward(GameObject obj, float time)
        {
            var rig = obj.GetComponent<Rigidbody2D>();
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