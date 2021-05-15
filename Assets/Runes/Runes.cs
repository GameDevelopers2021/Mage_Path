using System;
using UnityEngine;

namespace Runes
{
    public class Runes : MonoBehaviour
    {
        public Transform Circle;
    //    public RuneForm CircleForm = new RuneForm("Circle", Circle.transform);

        private void Awake()
        {
            var tmp = Instantiate(Circle);  
            tmp.transform.position = Vector3.forward;
        }
    }
}