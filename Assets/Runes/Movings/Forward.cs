using System;
using Spells;
using Unity.Mathematics;
using UnityEngine;

namespace Runes.Movings
{
    public class Forward : RuneMoving
    {
        protected override Action<GameObject, Rigidbody2D, float> Did(SpellDetail spell)
        {
            return (go, rig, time) =>
            {
                var speed = spell.GetParameter(FloatMagicParameter.Speed);
                var angle = rig.rotation / 180 * math.PI;
                rig.velocity = new Vector2(speed * math.cos(angle), speed * math.sin(angle)) * Time.fixedDeltaTime;
            };
        }
    }
}