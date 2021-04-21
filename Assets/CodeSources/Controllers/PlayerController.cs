// GENERATED AUTOMATICALLY FROM 'Assets/CodeSources/Controllers/PlayerController.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace CodeSources.Controllers
{
    public class @PlayerController : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @PlayerController()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerController"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""f5480fd5-eb18-4e93-ae37-47a0e998b0ba"",
            ""actions"": [
                {
                    ""name"": ""Moving"",
                    ""type"": ""Value"",
                    ""id"": ""f391f950-dccf-4a4c-b810-09b302e95599"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MouseMoving"",
                    ""type"": ""Value"",
                    ""id"": ""6d8fb1fe-011a-4eb6-9e58-64bf0cdf5f13"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""79224be9-6cde-4aa9-a27d-59abb1401730"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Moving"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Up"",
                    ""id"": ""faea66c9-8ac1-445d-b6af-18218d7095d1"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Moving"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Down"",
                    ""id"": ""485bb68f-e2b5-4837-92de-51ab593f21e0"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Moving"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Left"",
                    ""id"": ""d0ce0726-1d21-4196-833a-ddb9ef33fabe"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Moving"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Right"",
                    ""id"": ""b4a3fd3c-1477-4d8f-8857-5996b74ed5bf"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Moving"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""b28c6e0f-24c5-4201-a717-3e61836d90a7"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseMoving"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // Player
            m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
            m_Player_Moving = m_Player.FindAction("Moving", throwIfNotFound: true);
            m_Player_MouseMoving = m_Player.FindAction("MouseMoving", throwIfNotFound: true);
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

        // Player
        private readonly InputActionMap m_Player;
        private IPlayerActions m_PlayerActionsCallbackInterface;
        private readonly InputAction m_Player_Moving;
        private readonly InputAction m_Player_MouseMoving;
        public struct PlayerActions
        {
            private @PlayerController m_Wrapper;
            public PlayerActions(@PlayerController wrapper) { m_Wrapper = wrapper; }
            public InputAction @Moving => m_Wrapper.m_Player_Moving;
            public InputAction @MouseMoving => m_Wrapper.m_Player_MouseMoving;
            public InputActionMap Get() { return m_Wrapper.m_Player; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
            public void SetCallbacks(IPlayerActions instance)
            {
                if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
                {
                    @Moving.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoving;
                    @Moving.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoving;
                    @Moving.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoving;
                    @MouseMoving.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMouseMoving;
                    @MouseMoving.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMouseMoving;
                    @MouseMoving.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMouseMoving;
                }
                m_Wrapper.m_PlayerActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Moving.started += instance.OnMoving;
                    @Moving.performed += instance.OnMoving;
                    @Moving.canceled += instance.OnMoving;
                    @MouseMoving.started += instance.OnMouseMoving;
                    @MouseMoving.performed += instance.OnMouseMoving;
                    @MouseMoving.canceled += instance.OnMouseMoving;
                }
            }
        }
        public PlayerActions @Player => new PlayerActions(this);
        public interface IPlayerActions
        {
            void OnMoving(InputAction.CallbackContext context);
            void OnMouseMoving(InputAction.CallbackContext context);
        }
    }
}
