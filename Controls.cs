//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.6.1
//     from Assets/Scripts/Controls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @Controls: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""AttackI"",
            ""id"": ""6b1efed2-2344-4503-9b2b-e95ddb260775"",
            ""actions"": [
                {
                    ""name"": ""AttackI"",
                    ""type"": ""PassThrough"",
                    ""id"": ""85e59d3b-3ebd-485a-9f27-559434af0953"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""9b3016a9-99d7-4766-9b51-b751af1356ba"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""keyboard and mouse"",
                    ""action"": ""AttackI"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""keyboard and mouse"",
            ""bindingGroup"": ""keyboard and mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // AttackI
        m_AttackI = asset.FindActionMap("AttackI", throwIfNotFound: true);
        m_AttackI_AttackI = m_AttackI.FindAction("AttackI", throwIfNotFound: true);
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

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // AttackI
    private readonly InputActionMap m_AttackI;
    private List<IAttackIActions> m_AttackIActionsCallbackInterfaces = new List<IAttackIActions>();
    private readonly InputAction m_AttackI_AttackI;
    public struct AttackIActions
    {
        private @Controls m_Wrapper;
        public AttackIActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @AttackI => m_Wrapper.m_AttackI_AttackI;
        public InputActionMap Get() { return m_Wrapper.m_AttackI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(AttackIActions set) { return set.Get(); }
        public void AddCallbacks(IAttackIActions instance)
        {
            if (instance == null || m_Wrapper.m_AttackIActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_AttackIActionsCallbackInterfaces.Add(instance);
            @AttackI.started += instance.OnAttackI;
            @AttackI.performed += instance.OnAttackI;
            @AttackI.canceled += instance.OnAttackI;
        }

        private void UnregisterCallbacks(IAttackIActions instance)
        {
            @AttackI.started -= instance.OnAttackI;
            @AttackI.performed -= instance.OnAttackI;
            @AttackI.canceled -= instance.OnAttackI;
        }

        public void RemoveCallbacks(IAttackIActions instance)
        {
            if (m_Wrapper.m_AttackIActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IAttackIActions instance)
        {
            foreach (var item in m_Wrapper.m_AttackIActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_AttackIActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public AttackIActions @AttackI => new AttackIActions(this);
    private int m_keyboardandmouseSchemeIndex = -1;
    public InputControlScheme keyboardandmouseScheme
    {
        get
        {
            if (m_keyboardandmouseSchemeIndex == -1) m_keyboardandmouseSchemeIndex = asset.FindControlSchemeIndex("keyboard and mouse");
            return asset.controlSchemes[m_keyboardandmouseSchemeIndex];
        }
    }
    public interface IAttackIActions
    {
        void OnAttackI(InputAction.CallbackContext context);
    }
}
