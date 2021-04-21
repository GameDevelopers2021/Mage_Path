using System;
using CodeSources.Interfaces.Items;
using CodeSources.Interfaces.Mage;
using UnityEngine;

namespace CodeSources.Model.Mage
{
    public class Magic : IMagic
    {
        private int _controlInd;
        private int _usedTime;
        public Action<Rigidbody2D, int>[] Control { get; }
        public int[] ControlTime { get; }
        public IEffect[] Effect { get; }
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

        public Magic(
            Action<Rigidbody2D, int>[] control, int[] controlTime, 
            IEffect[] effect)
        {
            Control = control;
            ControlTime = controlTime;
            Effect = effect;
            Time = 0;
            _controlInd = 0;
            _usedTime = 0;
        }
    }
}
