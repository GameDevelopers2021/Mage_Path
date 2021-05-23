using System;
using UnityEngine;

namespace Ui.Scripts
{
    public class HelpTriggerBehaviour : MonoBehaviour
    {
        [SerializeField] private HelpMenuOpeningHandler openingHandler;
        [SerializeField] private GameObject menuToOpen;
        [SerializeField] private bool isOpeningOnce;

        private bool wasOpened;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player"))
            {
                return;
            }

            if (isOpeningOnce && wasOpened)
                return;

            wasOpened = true;
            openingHandler.OpenMenu(menuToOpen);
        }
    }
}
