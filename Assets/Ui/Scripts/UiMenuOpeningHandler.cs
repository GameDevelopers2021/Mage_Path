using InputSystem;
using UnitsClasses;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

namespace Ui.Scripts
{
    public class UiMenuOpeningHandler : MonoBehaviour
    {
        private MageAttack playerMageAttack;
        private GameObject activeMenu;
        private UiController uiController;
        private bool isFinish;

        [SerializeField] private GameObject bookMenu;
        [SerializeField] private GameObject inventoryMenu;
        [SerializeField] private GameObject finishMenu;
        [SerializeField] private GameObject pauseMenu;

        public GameObject BookMenu => bookMenu;
        public GameObject InventoryMenu => inventoryMenu;
        public GameObject FinishMenu => finishMenu;
        public GameObject PauseMenu => pauseMenu;

        public void PressSignal()
        {
            Debug.Log("Pressed");
        }

        public void OpenMenu(GameObject menu)
        {
            if (activeMenu == finishMenu)
                return;
            
            CloseActiveMenu();

            if (menu == pauseMenu || menu == finishMenu)
                Time.timeScale = 0;
            
            menu.SetActive(true);
            activeMenu = menu;
            playerMageAttack.enabled = false;
        }
    
        private void CloseActiveMenu()
        {
            Time.timeScale = 1;
            if (activeMenu == null)
                return;
        
            activeMenu.SetActive(false);
            activeMenu = null;
            playerMageAttack.enabled = true;
        }

        private bool TryOpenDoublePress(GameObject menu, KeyControl key)
        {
            if (key.wasPressedThisFrame)
            {
                if (activeMenu == null)
                {
                    OpenMenu(menu);
                }
                else if (activeMenu == menu)
                {
                    CloseActiveMenu();
                }

                return true;
            }
        
            return false;
        }

        private void OnEnable()
        {
            uiController.Enable();
        }

        private void OnDisable()
        {
            uiController.Disable();
        }

        private void Awake()
        {
            playerMageAttack = GameObject.FindWithTag("Player").GetComponent<MageAttack>();
            uiController = new UiController();
            uiController.Menu.Open.performed += context =>
            {
                if (!TryOpenDoublePress(inventoryMenu, Keyboard.current.iKey))
                {
                    TryOpenDoublePress(pauseMenu, Keyboard.current.escapeKey);
                }
            };
        }
    }
}
