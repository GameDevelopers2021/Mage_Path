using MageClasses;
using Units.UnitsClasses;
using UnityEngine;
using UnityEngine.UI;

namespace UnitsClasses
{
    public class HealthSystem : UnitComponent
    {
        [SerializeField] private int health = 100;
        [SerializeField] private Text ui;
        [SerializeField] private GameObject gameOverMenu;
        [SerializeField] private GameObject itemOnDeath;
        private ColorMarkerComponent marker;

        public int Health
        {
            get => health;
            set
            {
                if (value < health)
                    marker.Mark();
                
                health = value;
                if (ui != null)
                {
                    ui.text = $"Health: {health}";
                }
                if (health <= 0)
                {
                    if (itemOnDeath != null)
                    {
                        var clone = Instantiate(itemOnDeath);
                        clone.transform.position = transform.position;
                    }

                    Destroy(gameObject);
                    
                    if (gameOverMenu != null)
                        gameOverMenu.SetActive(true);
                }
            }
        }

        public void TakeDamage(int Damage, MagicElement element)
        {
            Health -= Damage;
        }

        private void Start()
        {
            marker = GetComponent<ColorMarkerComponent>();
            if (ui != null)
                ui.text = $"Health {health}";
        }
    }
}