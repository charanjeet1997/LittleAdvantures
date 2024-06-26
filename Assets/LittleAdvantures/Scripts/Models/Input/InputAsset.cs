//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/LittleAdvantures/Input/InputAsset.inputactions
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

namespace LittleAdvantures
{
    public partial class @InputAsset: IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }
        public @InputAsset()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputAsset"",
    ""maps"": [
        {
            ""name"": ""Movement"",
            ""id"": ""5e9d2063-536a-4376-b691-a8e8732c6b1f"",
            ""actions"": [
                {
                    ""name"": ""Locomotion"",
                    ""type"": ""Value"",
                    ""id"": ""e7750ceb-3995-44b5-af71-4e3e15103670"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Locomotion"",
                    ""id"": ""6bd8ef4a-3fd4-4edf-bee2-45a55beec0be"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Locomotion"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""8821d379-1cde-486c-bd55-e111472303ef"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Locomotion"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""aa9d38f6-5325-4de8-8e4a-873dfd573012"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Locomotion"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""94db9d13-70da-4126-9d60-df6ba0d3d953"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Locomotion"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""eae65bee-e7ce-4390-9f98-c092a2f9fd39"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Locomotion"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // Movement
            m_Movement = asset.FindActionMap("Movement", throwIfNotFound: true);
            m_Movement_Locomotion = m_Movement.FindAction("Locomotion", throwIfNotFound: true);
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

        // Movement
        private readonly InputActionMap m_Movement;
        private List<IMovementActions> m_MovementActionsCallbackInterfaces = new List<IMovementActions>();
        private readonly InputAction m_Movement_Locomotion;
        public struct MovementActions
        {
            private @InputAsset m_Wrapper;
            public MovementActions(@InputAsset wrapper) { m_Wrapper = wrapper; }
            public InputAction @Locomotion => m_Wrapper.m_Movement_Locomotion;
            public InputActionMap Get() { return m_Wrapper.m_Movement; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(MovementActions set) { return set.Get(); }
            public void AddCallbacks(IMovementActions instance)
            {
                if (instance == null || m_Wrapper.m_MovementActionsCallbackInterfaces.Contains(instance)) return;
                m_Wrapper.m_MovementActionsCallbackInterfaces.Add(instance);
                @Locomotion.started += instance.OnLocomotion;
                @Locomotion.performed += instance.OnLocomotion;
                @Locomotion.canceled += instance.OnLocomotion;
            }

            private void UnregisterCallbacks(IMovementActions instance)
            {
                @Locomotion.started -= instance.OnLocomotion;
                @Locomotion.performed -= instance.OnLocomotion;
                @Locomotion.canceled -= instance.OnLocomotion;
            }

            public void RemoveCallbacks(IMovementActions instance)
            {
                if (m_Wrapper.m_MovementActionsCallbackInterfaces.Remove(instance))
                    UnregisterCallbacks(instance);
            }

            public void SetCallbacks(IMovementActions instance)
            {
                foreach (var item in m_Wrapper.m_MovementActionsCallbackInterfaces)
                    UnregisterCallbacks(item);
                m_Wrapper.m_MovementActionsCallbackInterfaces.Clear();
                AddCallbacks(instance);
            }
        }
        public MovementActions @Movement => new MovementActions(this);
        public interface IMovementActions
        {
            void OnLocomotion(InputAction.CallbackContext context);
        }
    }
}
