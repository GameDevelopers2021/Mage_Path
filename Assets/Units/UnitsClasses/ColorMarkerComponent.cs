using System;
using UnityEngine;

namespace Units.UnitsClasses
{
    public class ColorMarkerComponent : MonoBehaviour
    {
        private SpriteRenderer sprite;
        private Color standardColor;
        private float colorChangingSpeed = 5f;
        private bool isRecovering;

        public void Mark()
        {
            sprite.color = new Color(40, 0, 0, 1);
            isRecovering = true;
        }
        
        private void Awake()
        {
            sprite = GetComponent<SpriteRenderer>();
            standardColor = sprite.color;
        }

        private void Update()
        {
            if (isRecovering)
            {
                var currentColor = sprite.color;
                currentColor.r += (standardColor.r - currentColor.r) * Time.deltaTime * colorChangingSpeed;
                if (Math.Abs(currentColor.r - standardColor.r) < 20)
                {
                    currentColor = standardColor;
                    isRecovering = false;
                }
                sprite.color = currentColor;
            }
        }
    }
}
