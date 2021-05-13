using System;
using UnityEngine;

namespace Runes
{
    public class RuneMoving: IRune
    {
        public RuneMoving(string name, Action<Transform, GameObject> did)
        {
            Name = name;
            Did = did;
        }

        public string Name { get; }
        public RuneType Type => RuneType.Moving;
        public Action<Transform, GameObject> Did { get; }
    }
}