using UnitsClasses;
using UnityEngine;

namespace Ui.Scripts
{
    public class FinishTriggerBehaviour : MonoBehaviour
    {
        [SerializeField] private UiMenuOpeningHandler uiMenuOpeningHandler;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.gameObject.CompareTag("Player"))
                return;
            uiMenuOpeningHandler.OpenMenu(uiMenuOpeningHandler.FinishMenu);
            other.gameObject.GetComponent<MageAttack>().enabled = false;
        }
    }
}
