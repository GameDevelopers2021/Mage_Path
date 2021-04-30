using System;
using ItemsInterfaces;
using UnityEngine;

namespace MageClasses
{
    public class Magic : IMagic
    {
        private int _controlInd;
        private int _usedTime;
        public Action<Rigidbody2D, int>[] Control { get; }
        public int[] ControlTime { get; }
        public IEffect[] Effects { get; }
        public bool IsSelfFire { get; }
        public bool IsTunel { get; }
        public int Time { get; set; }

        public bool MagicUpdate(Rigidbody2D rigidbody)
        {
            while (_controlInd < Control.Length && _usedTime + ControlTime[_controlInd] <= Time)
            {
                _usedTime += ControlTime[_controlInd];
                _controlInd++;
            }
            if (_controlInd < Control.Length)
            {
                Control[_controlInd](rigidbody, Time - _usedTime);
            }
            else
            {
                return false;
            }

            Time++;
            return true;
        }

        public void ApplyEffects(GameObject unit)
        {
            foreach (var effect in Effects)
            {
                effect.ApplyEffect(unit);
            }
        }

        public Magic(
            Action<Rigidbody2D, int>[] control, 
            int[] controlTime,
            bool isSelfFire, bool isTunel,
            IEffect[] effects)
        {
            Control = control;
            ControlTime = controlTime;
            Effects = effects;
            IsSelfFire = isSelfFire;
            IsTunel = isTunel;
            Time = 0;
            _controlInd = 0;
            _usedTime = 0;
        }
    }
}
