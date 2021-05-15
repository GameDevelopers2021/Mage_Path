using UnitsClasses;
using UnityEngine;

namespace Ui.Scripts
{
    public class FinishMenuHandler : MonoBehaviour
    {
        [SerializeField] private GameObject finishMenu;
        private Renderer finishMenuRenderer;

        private void Awake()
        {
            finishMenuRenderer = finishMenu.GetComponent<Renderer>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.gameObject.CompareTag("Player"))
                return;
            Time.timeScale = 0;
            finishMenu.SetActive(true);
            GameObject.FindWithTag("Player").GetComponent<MageAttack>().enabled = false;
        }
    }
}
