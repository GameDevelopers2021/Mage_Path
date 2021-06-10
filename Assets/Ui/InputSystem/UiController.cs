// GENERATED AUTOMATICALLY FROM 'Assets/Ui/InputSystem/UiController.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace InputSystem
{
    public class @UiController : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @UiController()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""UiController"",
    ""maps"": [
        {
            ""name"": ""BookMenu"",
            ""id"": ""9f0a4e54-f93a-45da-b0ac-a6c5936c2682"",
            ""actions"": [
                {
                    ""name"": ""PreviousSpell"",
                    ""type"": ""Value"",
                    ""id"": ""8baee57d-67a2-49db-a2dd-d8fa1245a338"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""NextSpell"",
                    ""type"": ""Value"",
                    ""id"": ""5881e1a2-5aee-436b-b36a-4a1c7038dc39"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""3909475e-9837-4428-befd-da94e65891b4"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PreviousSpell"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""509a18e9-d4d5-4959-9cec-6c88bb751622"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NextSpell"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Menu"",
            ""id"": ""fc0c1c27-ad3f-46a8-b4b2-aa21c2959f3b"",
            ""actions"": [
                {
                    ""name"": ""Click"",
                    ""type"": ""PassThrough"",
                    ""id"": ""b8d90b90-f0c3-4342-972e-dc6c2c4e5c86"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Point"",
                    ""type"": ""PassThrough"",
                    ""id"": ""6cea72aa-5e0e-408d-bc9c-4aafc37fb712"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Exit"",
                    ""type"": ""PassThrough"",
                    ""id"": ""0a55a0a2-ce0a-4ea7-9089-9ed87695c989"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Open"",
                    ""type"": ""PassThrough"",
                    ""id"": ""47944862-8851-435f-8f28-18cf8c52aae9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""2fbab76c-813d-4979-bec3-f8e18496b1dc"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Exit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f34620f3-dd03-4c5c-95aa-6abf9659ae21"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f614025a-844c-42b2-89ec-010659cdb10c"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Point"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d5d9463a-a14c-4676-a3fc-bf8f0cb51c33"",
                    ""path"": ""<Pen>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Point"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""34608f5e-bc01-4ce9-ad30-2b2327083725"",
                    ""path"": ""<Touchscreen>/touch*/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Touch"",
                    ""action"": ""Point"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""df40fc6b-e57c-4e0f-a6cc-15a01bf38402"",
                    ""path"": ""<Keyboard>/anyKey"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Open"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // BookMenu
            m_BookMenu = asset.FindActionMap("BookMenu", throwIfNotFound: true);
            m_BookMenu_PreviousSpell = m_BookMenu.FindAction("PreviousSpell", throwIfNotFound: true);
            m_BookMenu_NextSpell = m_BookMenu.FindAction("NextSpell", throwIfNotFound: true);
            // Menu
            m_Menu = asset.FindActionMap("Menu", throwIfNotFound: true);
            m_Menu_Click = m_Menu.FindAction("Click", throwIfNotFound: true);
            m_Menu_Point = m_Menu.FindAction("Point", throwIfNotFound: true);
            m_Menu_Exit = m_Menu.FindAction("Exit", throwIfNotFound: true);
            m_Menu_Open = m_Menu.FindAction("Open", throwIfNotFound: true);
        }

        public void Dispose()
        {
            UnityEngine.Object.Destroy(asset);
        }

        public InputBinding? bindingMask
        {
            get => asset.bindingMask;
            set => asset.bindingMask = value;
        }

        public ReadOnlyArray<InputDevice>? devices
        {
            get => asset.devices;
            set => asset.devices = value;
        }

        public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

        public bool Contains(InputAction action)
        {
            return asset.Contains(action);
        }

        public IEnumerator<InputAction> GetEnumerator()
        {
            return asset.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Enable()
        {
            asset.Enable();
        }

        public void Disable()
        {
            asset.Disable();
        }

        // BookMenu
        private readonly InputActionMap m_BookMenu;
        private IBookMenuActions m_BookMenuActionsCallbackInterface;
        private readonly InputAction m_BookMenu_PreviousSpell;
        private readonly InputAction m_BookMenu_NextSpell;
        public struct BookMenuActions
        {
            private @UiController m_Wrapper;
            public BookMenuActions(@UiController wrapper) { m_Wrapper = wrapper; }
            public InputAction @PreviousSpell => m_Wrapper.m_BookMenu_PreviousSpell;
            public InputAction @NextSpell => m_Wrapper.m_BookMenu_NextSpell;
            public InputActionMap Get() { return m_Wrapper.m_BookMenu; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(BookMenuActions set) { return set.Get(); }
            public void SetCallbacks(IBookMenuActions instance)
            {
                if (m_Wrapper.m_BookMenuActionsCallbackInterface != null)
                {
                    @PreviousSpell.started -= m_Wrapper.m_BookMenuActionsCallbackInterface.OnPreviousSpell;
                    @PreviousSpell.performed -= m_Wrapper.m_BookMenuActionsCallbackInterface.OnPreviousSpell;
                    @PreviousSpell.canceled -= m_Wrapper.m_BookMenuActionsCallbackInterface.OnPreviousSpell;
                    @NextSpell.started -= m_Wrapper.m_BookMenuActionsCallbackInterface.OnNextSpell;
                    @NextSpell.performed -= m_Wrapper.m_BookMenuActionsCallbackInterface.OnNextSpell;
                    @NextSpell.canceled -= m_Wrapper.m_BookMenuActionsCallbackInterface.OnNextSpell;
                }
                m_Wrapper.m_BookMenuActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @PreviousSpell.started += instance.OnPreviousSpell;
                    @PreviousSpell.performed += instance.OnPreviousSpell;
                    @PreviousSpell.canceled += instance.OnPreviousSpell;
                    @NextSpell.started += instance.OnNextSpell;
                    @NextSpell.performed += instance.OnNextSpell;
                    @NextSpell.canceled += instance.OnNextSpell;
                }
            }
        }
        public BookMenuActions @BookMenu => new BookMenuActions(this);

        // Menu
        private readonly InputActionMap m_Menu;
        private IMenuActions m_MenuActionsCallbackInterface;
        private readonly InputAction m_Menu_Click;
        private readonly InputAction m_Menu_Point;
        private readonly InputAction m_Menu_Exit;
        private readonly InputAction m_Menu_Open;
        public struct MenuActions
        {
            private @UiController m_Wrapper;
            public MenuActions(@UiController wrapper) { m_Wrapper = wrapper; }
            public InputAction @Click => m_Wrapper.m_Menu_Click;
            public InputAction @Point => m_Wrapper.m_Menu_Point;
            public InputAction @Exit => m_Wrapper.m_Menu_Exit;
            public InputAction @Open => m_Wrapper.m_Menu_Open;
            public InputActionMap Get() { return m_Wrapper.m_Menu; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(MenuActions set) { return set.Get(); }
            public void SetCallbacks(IMenuActions instance)
            {
                if (m_Wrapper.m_MenuActionsCallbackInterface != null)
                {
                    @Click.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnClick;
                    @Click.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnClick;
                    @Click.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnClick;
                    @Point.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnPoint;
                    @Point.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnPoint;
                    @Point.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnPoint;
                    @Exit.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnExit;
                    @Exit.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnExit;
                    @Exit.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnExit;
                    @Open.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnOpen;
                    @Open.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnOpen;
                    @Open.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnOpen;
                }
                m_Wrapper.m_MenuActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Click.started += instance.OnClick;
                    @Click.performed += instance.OnClick;
                    @Click.canceled += instance.OnClick;
                    @Point.started += instance.OnPoint;
                    @Point.performed += instance.OnPoint;
                    @Point.canceled += instance.OnPoint;
                    @Exit.started += instance.OnExit;
                    @Exit.performed += instance.OnExit;
                    @Exit.canceled += instance.OnExit;
                    @Open.started += instance.OnOpen;
                    @Open.performed += instance.OnOpen;
                    @Open.canceled += instance.OnOpen;
                }
            }
        }
        public MenuActions @Menu => new MenuActions(this);
        public interface IBookMenuActions
        {
            void OnPreviousSpell(InputAction.CallbackContext context);
            void OnNextSpell(InputAction.CallbackContext context);
        }
        public interface IMenuActions
        {
            void OnClick(InputAction.CallbackContext context);
            void OnPoint(InputAction.CallbackContext context);
            void OnExit(InputAction.CallbackContext context);
            void OnOpen(InputAction.CallbackContext context);
        }
    }
}
