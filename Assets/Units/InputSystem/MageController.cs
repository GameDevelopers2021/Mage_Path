// GENERATED AUTOMATICALLY FROM 'Assets/InputSystem/MageController.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace InputSystem
{
    public class @MageController : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @MageController()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""MageController"",
    ""maps"": [
        {
            ""name"": ""MageActions"",
            ""id"": ""bc27bbcf-734c-4d21-abcd-3d8c41c147f8"",
            ""actions"": [
                {
                    ""name"": ""CastSpell"",
                    ""type"": ""Button"",
                    ""id"": ""0a99f2b0-ba32-43f7-9a95-f3a83ab88360"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""eb6dd21e-31d5-46e6-8a90-3c4df8865789"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CastSpell"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // MageActions
            m_MageActions = asset.FindActionMap("MageActions", throwIfNotFound: true);
            m_MageActions_CastSpell = m_MageActions.FindAction("CastSpell", throwIfNotFound: true);
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

        // MageActions
        private readonly InputActionMap m_MageActions;
        private IMageActionsActions m_MageActionsActionsCallbackInterface;
        private readonly InputAction m_MageActions_CastSpell;
        public struct MageActionsActions
        {
            private @MageController m_Wrapper;
            public MageActionsActions(@MageController wrapper) { m_Wrapper = wrapper; }
            public InputAction @CastSpell => m_Wrapper.m_MageActions_CastSpell;
            public InputActionMap Get() { return m_Wrapper.m_MageActions; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(MageActionsActions set) { return set.Get(); }
            public void SetCallbacks(IMageActionsActions instance)
            {
                if (m_Wrapper.m_MageActionsActionsCallbackInterface != null)
                {
                    @CastSpell.started -= m_Wrapper.m_MageActionsActionsCallbackInterface.OnCastSpell;
                    @CastSpell.performed -= m_Wrapper.m_MageActionsActionsCallbackInterface.OnCastSpell;
                    @CastSpell.canceled -= m_Wrapper.m_MageActionsActionsCallbackInterface.OnCastSpell;
                }
                m_Wrapper.m_MageActionsActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @CastSpell.started += instance.OnCastSpell;
                    @CastSpell.performed += instance.OnCastSpell;
                    @CastSpell.canceled += instance.OnCastSpell;
                }
            }
        }
        public MageActionsActions @MageActions => new MageActionsActions(this);
        public interface IMageActionsActions
        {
            void OnCastSpell(InputAction.CallbackContext context);
        }
    }
}
