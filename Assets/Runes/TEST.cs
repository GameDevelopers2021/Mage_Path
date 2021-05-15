using System;
using UnityEngine;

namespace Runes
{
    public class TEST : MonoBehaviour
    {
        public Transform circle;
        private void Start()
        {
            var go = Instantiate(circle);
            var goSmall = Instantiate(go);
            goSmall.localScale *= 0.1f;
            
            // var tmp = Instantiate(Runes.CircleForm.GetForm(0));
            // var tmp1 = Instantiate(Runes.CircleForm.GetForm(1));
            // var tmp2 = Instantiate(Runes.CircleForm.GetForm(2));

        }
    }
}