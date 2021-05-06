// GENERATED AUTOMATICALLY FROM 'Assets/Controls/Player_Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Player_Controls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Player_Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Player_Controls"",
    ""maps"": [
        {
            ""name"": ""Movement"",
            ""id"": ""8eecb865-2a3d-42ab-a7eb-fae086dcc7e0"",
            ""actions"": [
                {
                    ""name"": ""MoveLeft"",
                    ""type"": ""Value"",
                    ""id"": ""92a77553-c810-4ca4-9765-240ac34c0933"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoveRight"",
                    ""type"": ""Button"",
                    ""id"": ""413c6710-6b97-492a-9a02-9f5c1b0a2d56"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""57d9c8c3-dae3-4e28-86dd-53574837e0b1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Down"",
                    ""type"": ""Button"",
                    ""id"": ""9cac62c6-e20e-460d-86b6-86e315b36c43"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Up"",
                    ""type"": ""Button"",
                    ""id"": ""708feeff-e93c-4a5c-a996-0f2661512503"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""97143bdd-7079-4302-861f-8a81017a8a86"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""469b1e00-50b8-4b00-992f-9f6d920bfc9b"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""54b5fdcd-ba0f-4999-b260-4952372c4846"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6985b01d-a556-434c-955d-39affe3f6ed1"",
                    ""path"": ""<SwitchProControllerHID>/leftStick/left"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c6201d8a-8d5d-4ec2-a58d-b28d7ad36edc"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fa755ec1-dd46-4b41-bd31-f98816ade477"",
                    ""path"": ""<SwitchProControllerHID>/leftStick/right"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0eb8464f-2977-494a-8db0-0561bb9295bb"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""859ce602-f41e-421c-8bda-5ec4075645e0"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": ""Press,Hold"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e8c2c0fd-79c7-498f-9a11-f4a4c74939df"",
                    ""path"": ""<SwitchProControllerHID>/buttonNorth"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b9eda921-ec1c-4380-bc54-c00b90689f8f"",
                    ""path"": ""<SwitchProControllerHID>/leftStick/down"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2c0daa7a-446b-4d58-94a1-c36b629ed5cd"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""334f3e61-4201-4a00-8d7e-145693c33d67"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2764be56-7ce6-4407-a321-fb14a8aeb5a7"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""97782fb4-b0c9-4964-8946-6ced30102f1c"",
                    ""path"": ""<SwitchProControllerHID>/buttonEast"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c19f3fd0-7559-45e5-b7ce-f7cdba4bb426"",
                    ""path"": ""<SwitchProControllerHID>/leftStick/up"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0f550b95-5da8-4820-9c6e-e2d3f62e4121"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""613898ca-f396-4685-9a29-c75a0b374bb5"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Attacking"",
            ""id"": ""4e93167f-61ec-4d9c-b9d2-6cd3efb7769c"",
            ""actions"": [
                {
                    ""name"": ""LightAttack"",
                    ""type"": ""Button"",
                    ""id"": ""85dd7e52-6a7d-40dc-ac0c-483c80a7ebf7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""1042a7b6-7e32-4bb7-baa8-b14aa5e49c85"",
                    ""path"": ""<SwitchProControllerHID>/buttonWest"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LightAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ade99bc8-e72d-4af8-bb65-76d3c8305866"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LightAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Movement
        m_Movement = asset.FindActionMap("Movement", throwIfNotFound: true);
        m_Movement_MoveLeft = m_Movement.FindAction("MoveLeft", throwIfNotFound: true);
        m_Movement_MoveRight = m_Movement.FindAction("MoveRight", throwIfNotFound: true);
        m_Movement_Jump = m_Movement.FindAction("Jump", throwIfNotFound: true);
        m_Movement_Down = m_Movement.FindAction("Down", throwIfNotFound: true);
        m_Movement_Up = m_Movement.FindAction("Up", throwIfNotFound: true);
        m_Movement_Dash = m_Movement.FindAction("Dash", throwIfNotFound: true);
        // Attacking
        m_Attacking = asset.FindActionMap("Attacking", throwIfNotFound: true);
        m_Attacking_LightAttack = m_Attacking.FindAction("LightAttack", throwIfNotFound: true);
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

    // Movement
    private readonly InputActionMap m_Movement;
    private IMovementActions m_MovementActionsCallbackInterface;
    private readonly InputAction m_Movement_MoveLeft;
    private readonly InputAction m_Movement_MoveRight;
    private readonly InputAction m_Movement_Jump;
    private readonly InputAction m_Movement_Down;
    private readonly InputAction m_Movement_Up;
    private readonly InputAction m_Movement_Dash;
    public struct MovementActions
    {
        private @Player_Controls m_Wrapper;
        public MovementActions(@Player_Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @MoveLeft => m_Wrapper.m_Movement_MoveLeft;
        public InputAction @MoveRight => m_Wrapper.m_Movement_MoveRight;
        public InputAction @Jump => m_Wrapper.m_Movement_Jump;
        public InputAction @Down => m_Wrapper.m_Movement_Down;
        public InputAction @Up => m_Wrapper.m_Movement_Up;
        public InputAction @Dash => m_Wrapper.m_Movement_Dash;
        public InputActionMap Get() { return m_Wrapper.m_Movement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MovementActions set) { return set.Get(); }
        public void SetCallbacks(IMovementActions instance)
        {
            if (m_Wrapper.m_MovementActionsCallbackInterface != null)
            {
                @MoveLeft.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnMoveLeft;
                @MoveLeft.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnMoveLeft;
                @MoveLeft.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnMoveLeft;
                @MoveRight.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnMoveRight;
                @MoveRight.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnMoveRight;
                @MoveRight.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnMoveRight;
                @Jump.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnJump;
                @Down.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnDown;
                @Down.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnDown;
                @Down.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnDown;
                @Up.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnUp;
                @Up.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnUp;
                @Up.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnUp;
                @Dash.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnDash;
                @Dash.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnDash;
                @Dash.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnDash;
            }
            m_Wrapper.m_MovementActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MoveLeft.started += instance.OnMoveLeft;
                @MoveLeft.performed += instance.OnMoveLeft;
                @MoveLeft.canceled += instance.OnMoveLeft;
                @MoveRight.started += instance.OnMoveRight;
                @MoveRight.performed += instance.OnMoveRight;
                @MoveRight.canceled += instance.OnMoveRight;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Down.started += instance.OnDown;
                @Down.performed += instance.OnDown;
                @Down.canceled += instance.OnDown;
                @Up.started += instance.OnUp;
                @Up.performed += instance.OnUp;
                @Up.canceled += instance.OnUp;
                @Dash.started += instance.OnDash;
                @Dash.performed += instance.OnDash;
                @Dash.canceled += instance.OnDash;
            }
        }
    }
    public MovementActions @Movement => new MovementActions(this);

    // Attacking
    private readonly InputActionMap m_Attacking;
    private IAttackingActions m_AttackingActionsCallbackInterface;
    private readonly InputAction m_Attacking_LightAttack;
    public struct AttackingActions
    {
        private @Player_Controls m_Wrapper;
        public AttackingActions(@Player_Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @LightAttack => m_Wrapper.m_Attacking_LightAttack;
        public InputActionMap Get() { return m_Wrapper.m_Attacking; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(AttackingActions set) { return set.Get(); }
        public void SetCallbacks(IAttackingActions instance)
        {
            if (m_Wrapper.m_AttackingActionsCallbackInterface != null)
            {
                @LightAttack.started -= m_Wrapper.m_AttackingActionsCallbackInterface.OnLightAttack;
                @LightAttack.performed -= m_Wrapper.m_AttackingActionsCallbackInterface.OnLightAttack;
                @LightAttack.canceled -= m_Wrapper.m_AttackingActionsCallbackInterface.OnLightAttack;
            }
            m_Wrapper.m_AttackingActionsCallbackInterface = instance;
            if (instance != null)
            {
                @LightAttack.started += instance.OnLightAttack;
                @LightAttack.performed += instance.OnLightAttack;
                @LightAttack.canceled += instance.OnLightAttack;
            }
        }
    }
    public AttackingActions @Attacking => new AttackingActions(this);
    public interface IMovementActions
    {
        void OnMoveLeft(InputAction.CallbackContext context);
        void OnMoveRight(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnDown(InputAction.CallbackContext context);
        void OnUp(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
    }
    public interface IAttackingActions
    {
        void OnLightAttack(InputAction.CallbackContext context);
    }
}
