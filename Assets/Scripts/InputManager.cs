// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/InputManager.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputManager : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputManager()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputManager"",
    ""maps"": [
        {
            ""name"": ""PlayerMovementActionMap"",
            ""id"": ""e4b10b4f-dccd-48af-8315-ad2f7ff21683"",
            ""actions"": [
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""c890e9f9-bc64-460a-9afd-350fbf12f540"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                },
                {
                    ""name"": ""downDrop"",
                    ""type"": ""Button"",
                    ""id"": ""b4a3ec72-bd67-46b0-9e02-5d67f8b2f42c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""20f45aa9-03d3-45dc-aae0-79eb9ad4272a"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""f5aa6c8f-03d7-449a-9ca5-dc0e3039d0f0"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b6c26e43-9d7b-4026-8c45-764f9a89a3a3"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""26082bca-834f-4406-8f86-032c4237c338"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""downDrop"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c74df577-10c2-49fe-bfcc-71d577572948"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""downDrop"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""3e91261b-f64a-4c91-ac1d-20fe04ea3394"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""21fd37d7-f095-4b84-9fbb-fcfdfbba8afb"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""387776f9-b3da-402d-917e-17e242e6abd9"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""6884ee60-1f50-41cf-a1a1-8214512399b5"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""91ba912b-c61c-45e5-aa7b-1f240e07aafd"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""70d8a620-92c5-43fd-a821-81db779cbb11"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""0d76da58-9155-42e1-9188-60b876fe7568"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""7430d736-b1df-4c65-b776-1ce658f6802e"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""1a33896d-4def-4062-9dd7-14315c448407"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""f7875acb-45fe-497b-8e54-dda6e2c4835d"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerMovementActionMap
        m_PlayerMovementActionMap = asset.FindActionMap("PlayerMovementActionMap", throwIfNotFound: true);
        m_PlayerMovementActionMap_Jump = m_PlayerMovementActionMap.FindAction("Jump", throwIfNotFound: true);
        m_PlayerMovementActionMap_downDrop = m_PlayerMovementActionMap.FindAction("downDrop", throwIfNotFound: true);
        m_PlayerMovementActionMap_Movement = m_PlayerMovementActionMap.FindAction("Movement", throwIfNotFound: true);
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

    // PlayerMovementActionMap
    private readonly InputActionMap m_PlayerMovementActionMap;
    private IPlayerMovementActionMapActions m_PlayerMovementActionMapActionsCallbackInterface;
    private readonly InputAction m_PlayerMovementActionMap_Jump;
    private readonly InputAction m_PlayerMovementActionMap_downDrop;
    private readonly InputAction m_PlayerMovementActionMap_Movement;
    public struct PlayerMovementActionMapActions
    {
        private @InputManager m_Wrapper;
        public PlayerMovementActionMapActions(@InputManager wrapper) { m_Wrapper = wrapper; }
        public InputAction @Jump => m_Wrapper.m_PlayerMovementActionMap_Jump;
        public InputAction @downDrop => m_Wrapper.m_PlayerMovementActionMap_downDrop;
        public InputAction @Movement => m_Wrapper.m_PlayerMovementActionMap_Movement;
        public InputActionMap Get() { return m_Wrapper.m_PlayerMovementActionMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerMovementActionMapActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerMovementActionMapActions instance)
        {
            if (m_Wrapper.m_PlayerMovementActionMapActionsCallbackInterface != null)
            {
                @Jump.started -= m_Wrapper.m_PlayerMovementActionMapActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerMovementActionMapActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerMovementActionMapActionsCallbackInterface.OnJump;
                @downDrop.started -= m_Wrapper.m_PlayerMovementActionMapActionsCallbackInterface.OnDownDrop;
                @downDrop.performed -= m_Wrapper.m_PlayerMovementActionMapActionsCallbackInterface.OnDownDrop;
                @downDrop.canceled -= m_Wrapper.m_PlayerMovementActionMapActionsCallbackInterface.OnDownDrop;
                @Movement.started -= m_Wrapper.m_PlayerMovementActionMapActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerMovementActionMapActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerMovementActionMapActionsCallbackInterface.OnMovement;
            }
            m_Wrapper.m_PlayerMovementActionMapActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @downDrop.started += instance.OnDownDrop;
                @downDrop.performed += instance.OnDownDrop;
                @downDrop.canceled += instance.OnDownDrop;
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
            }
        }
    }
    public PlayerMovementActionMapActions @PlayerMovementActionMap => new PlayerMovementActionMapActions(this);
    public interface IPlayerMovementActionMapActions
    {
        void OnJump(InputAction.CallbackContext context);
        void OnDownDrop(InputAction.CallbackContext context);
        void OnMovement(InputAction.CallbackContext context);
    }
}
