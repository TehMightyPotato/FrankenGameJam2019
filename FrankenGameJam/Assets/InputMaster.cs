// GENERATED AUTOMATICALLY FROM 'Assets/InputMaster.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class InputMaster : IInputActionCollection
{
    private InputActionAsset asset;
    public InputMaster()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputMaster"",
    ""maps"": [
        {
            ""name"": ""Default"",
            ""id"": ""4a6fec88-f26e-4a9a-9d01-a181c915717b"",
            ""actions"": [
                {
                    ""name"": ""Player1Movement"",
                    ""id"": ""30536cd6-d64e-4a5d-98b3-8b3829d2a0a2"",
                    ""expectedControlLayout"": """",
                    ""continuous"": false,
                    ""passThrough"": false,
                    ""initialStateCheck"": false,
                    ""processors"": """",
                    ""interactions"": """",
                    ""bindings"": []
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""42af2241-5ad3-4c1b-b268-e3295653cf2c"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Player1Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false,
                    ""modifiers"": """"
                },
                {
                    ""name"": ""up"",
                    ""id"": ""addd8022-e548-495e-a55f-ce7eb1bc517a"",
                    ""path"": ""<NPad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Player1Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true,
                    ""modifiers"": """"
                },
                {
                    ""name"": ""down"",
                    ""id"": ""de8e248e-aafe-4b4d-93c9-2ec0fad70d68"",
                    ""path"": ""<NPad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Player1Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true,
                    ""modifiers"": """"
                },
                {
                    ""name"": ""left"",
                    ""id"": ""fc8a859e-45e3-4fa9-bbbe-5a9757578059"",
                    ""path"": ""<NPad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Player1Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true,
                    ""modifiers"": """"
                },
                {
                    ""name"": ""right"",
                    ""id"": ""484375a6-fb6d-4dc3-bb09-5ebbe2926850"",
                    ""path"": ""<NPad>/rightStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Player1Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true,
                    ""modifiers"": """"
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Default
        m_Default = asset.GetActionMap("Default");
        m_Default_Player1Movement = m_Default.GetAction("Player1Movement");
    }

    ~InputMaster()
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

    public ReadOnlyArray<InputControlScheme> controlSchemes
    {
        get => asset.controlSchemes;
    }

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

    // Default
    private InputActionMap m_Default;
    private IDefaultActions m_DefaultActionsCallbackInterface;
    private InputAction m_Default_Player1Movement;
    public struct DefaultActions
    {
        private InputMaster m_Wrapper;
        public DefaultActions(InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @Player1Movement { get { return m_Wrapper.m_Default_Player1Movement; } }
        public InputActionMap Get() { return m_Wrapper.m_Default; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled { get { return Get().enabled; } }
        public InputActionMap Clone() { return Get().Clone(); }
        public static implicit operator InputActionMap(DefaultActions set) { return set.Get(); }
        public void SetCallbacks(IDefaultActions instance)
        {
            if (m_Wrapper.m_DefaultActionsCallbackInterface != null)
            {
                Player1Movement.started -= m_Wrapper.m_DefaultActionsCallbackInterface.OnPlayer1Movement;
                Player1Movement.performed -= m_Wrapper.m_DefaultActionsCallbackInterface.OnPlayer1Movement;
                Player1Movement.canceled -= m_Wrapper.m_DefaultActionsCallbackInterface.OnPlayer1Movement;
            }
            m_Wrapper.m_DefaultActionsCallbackInterface = instance;
            if (instance != null)
            {
                Player1Movement.started += instance.OnPlayer1Movement;
                Player1Movement.performed += instance.OnPlayer1Movement;
                Player1Movement.canceled += instance.OnPlayer1Movement;
            }
        }
    }
    public DefaultActions @Default
    {
        get
        {
            return new DefaultActions(this);
        }
    }
    public interface IDefaultActions
    {
        void OnPlayer1Movement(InputAction.CallbackContext context);
    }
}
