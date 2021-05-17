using System;
using Unity.Mathematics;
using UnityEngine;

namespace Runes.Movings
{
    public class Forward : RuneMoving
    {
        public new Action<GameObject, Rigidbody2D, float> Did(float speed)
        {
            return (go, rig, time) =>
            {
                var angle = rig.rotation / 180 * math.PI;
                rig.velocity = new Vector2(speed * math.cos(angle), speed * math.sin(angle)) * Time.fixedDeltaTime;
            };
        }
    }
}