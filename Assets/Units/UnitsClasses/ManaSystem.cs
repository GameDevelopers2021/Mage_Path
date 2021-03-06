using System;
using UnityEngine;
using UnityEngine.UI;

namespace UnitsClasses
{
    public class ManaSystem : UnitComponent
    {
        [SerializeField] private float maxMana = 200;
        [SerializeField] private float manaRegen = 5f;
        [SerializeField] private Text ui;
        private float _actualMana = 200;

        public float Mana
        {
            get => _actualMana;
            set
            {
                _actualMana = value;
                if (ui != null)
                {
                    ui.text = $"MANA: {(int)_actualMana}";
                }
                if (_actualMana < 0)
                {
                    Debug.Log(gameObject.name + " Non valid mana");
                }
            }
        }

        public bool UseMana(float cost)
        {
            if (_actualMana - cost < 0)
            {
                return false;
            }
            else
            {
                Mana -= cost;
                return true;
            }
        }

        private new void Awake()
        {
            _actualMana = maxMana;
        }

        public void FixedUpdate()
        {
            Mana = Unity.Mathematics.math.min(maxMana, _actualMana + manaRegen * Time.fixedDeltaTime);
        }
    }
}