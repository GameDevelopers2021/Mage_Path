using System;
using UnityEngine;

namespace Ui.Scripts
{
    public class HelpTriggerBehaviour : MonoBehaviour
    {
        [SerializeField] private HelpMenuOpeningHandler openingHandler;
        [SerializeField] private GameObject menuToOpen;
        [SerializeField] private bool isOpeningOnce;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player"))
            {
                return;
            }
            
            openingHandler.OpenMenu(menuToOpen);
            if (isOpeningOnce)
                gameObject.SetActive(false);
        }
    }
}
