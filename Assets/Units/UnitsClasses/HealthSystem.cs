using MageClasses;
using Units.UnitsClasses;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UnitsClasses
{
    public class HealthSystem : UnitComponent
    {
        [SerializeField] private int health = 100;
        [SerializeField] private Text ui;
        [SerializeField] private string gameOverSceneName;
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
                
                UpdateUi();
                
                if (health <= 0)
                {
                    if (itemOnDeath != null)
                    {
                        var clone = Instantiate(itemOnDeath);
                        clone.transform.position = transform.position;
                    }

                    Destroy(gameObject);

                    if (gameOverSceneName != "")
                        SceneManager.LoadScene(gameOverSceneName);
                }
            }
        }

        public void TakeDamage(int Damage, MagicElement element)
        {
            Health -= Damage;
        }

        private void UpdateUi()
        {
            if (ui != null)
                ui.text = $"HEALTH: {health}";
        }

        private void Start()
        {
            marker = GetComponent<ColorMarkerComponent>();
            UpdateUi();
        }
    }
}