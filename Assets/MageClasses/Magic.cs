using System;
using ItemsInterfaces;
using UnityEngine;

namespace MageClasses
{
    public class Magic : IMagic
    {
        private int _controlInd;
        private float _usedTime;
        private GameObject _controled;
        public Action<GameObject, float>[] Control { get; }
        public float[] ControlTime { get; }
        public IEffect[] Effects { get; }
        public bool IsSelfFire { get; }
        public bool IsTunel { get; }
        public bool IsBounce { get; }

        public bool MagicUpdate(float deltaTime)
        {
            while (_controlInd < Control.Length && _usedTime + ControlTime[_controlInd] <= deltaTime)
            {
                _usedTime += ControlTime[_controlInd];
                _controlInd++;
            }
            if (_controlInd < Control.Length)
            {
                Control[_controlInd](_controled, deltaTime - _usedTime);
            }
            else
            {
                return false;
            }
            
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
            Action<GameObject, float>[] control, 
            float[] controlTime,
            IEffect[] effects,
            GameObject controled,
            bool isSelfFire = false, bool isTunel = true, bool isBounce = false)
        {
            Control = control;
            ControlTime = controlTime;
            Effects = effects;
            IsSelfFire = isSelfFire;
            IsTunel = isTunel;
            IsBounce = isBounce;
            _controlInd = 0;
            _usedTime = 0;
            _controled = controled;
        }
    }
}
