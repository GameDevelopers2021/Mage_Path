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

        [SerializeField] private GameObject bookMenu;
        [SerializeField] private GameObject inventoryMenu;
        [SerializeField] private GameObject finishMenu;
        [SerializeField] private GameObject pauseMenu;

        public GameObject BookMenu { get; set; }
        public GameObject InventoryMenu { get; set; }
        public GameObject FinishMenu { get; set; }
        public GameObject PauseMenu { get; set; }

        // public void HandleToNextLevel()
        // {
        //     //Application.Quit();
        //     EditorApplication.ExitPlaymode();
        // }
        //
        // public void HandleExit()
        // {
        //     //Application.Quit();
        //     EditorApplication.ExitPlaymode();
        // }

        public void PressSignal()
        {
            Debug.Log("Pressed");
        }

        private void OpenMenu(GameObject menu)
        {
            CloseActiveMenu();
            menu.SetActive(true);
            activeMenu = menu;
            playerMageAttack.enabled = false;
        }
    
        private void CloseActiveMenu()
        {
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