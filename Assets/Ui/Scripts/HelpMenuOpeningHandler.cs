using System;
using UnitsClasses;
using UnityEngine;

namespace Ui.Scripts
{
    public class HelpMenuOpeningHandler : MonoBehaviour
    {
        [SerializeField] private MageAttack playerMageAttack;
        [SerializeField] private GameObject uiMenuOpeningHandlerObject;
        
        private UiMenuOpeningHandler uiMenuOpeningHandler;
        private GameObject activeMenu;

        public void OpenMenu(GameObject menu)
        {
            if (activeMenu != null)
                CloseActiveMenu();
            
            uiMenuOpeningHandler.CloseActiveMenu();
            uiMenuOpeningHandlerObject.SetActive(false);

            playerMageAttack.enabled = false;
            Time.timeScale = 0;
            activeMenu = menu;
            activeMenu.SetActive(true);
        }

        public void CloseActiveMenu()
        {
            if (activeMenu == null)
                throw new Exception("No active menu");
            
            activeMenu.SetActive(false);
            activeMenu = null;
            playerMageAttack.enabled = true;
            Time.timeScale = 1;
            uiMenuOpeningHandlerObject.SetActive(true);
        }

        private void Awake()
        {
            uiMenuOpeningHandler = uiMenuOpeningHandlerObject.GetComponent<UiMenuOpeningHandler>();
        }
    }
}
