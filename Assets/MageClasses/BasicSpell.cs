using System;
using System.Collections.Generic;
using ItemsInterfaces;
using UnityEngine;
using UnityEngine.PlayerLoop;
using MageClasses;
using Unity.Mathematics;
using UnityEngine.Serialization;

namespace MageClasses
{
    public class BasicSpell: MonoBehaviour, ISpell
    {
        public float speed = 0.1f; 
        [FormerlySerializedAs("BasicMagic")] public GameObject basicMagic;

        public string Name { get; }

        public IEffect[] Effects { get; }

        public List<IMagic> Cast(Transform playersTransform)
        {
            var newMagic = Instantiate(basicMagic);
            newMagic.transform.rotation = playersTransform.rotation;
            newMagic.transform.position = playersTransform.position;
            var magicScript = new Magic(
                new[] {(Action<Rigidbody2D, int>) MoveForward}, new[] {700},
                Effects);
            var magicControler = newMagic.GetComponent<MagicUnity>();
            magicControler.magic = magicScript;
            return new List<IMagic> {magicScript};
        }

        public void MoveForward(Rigidbody2D obj, int time)
        {
            var angle = obj.rotation / 180 * math.PI;
            obj.velocity = new Vector2(speed * math.cos(angle), speed * math.sin(angle)) * Time.fixedDeltaTime;
        }
        
        public BasicSpell(IEffect[] effects, string name)
        {
            Effects = effects;
            Name = name;
        }
    }
}