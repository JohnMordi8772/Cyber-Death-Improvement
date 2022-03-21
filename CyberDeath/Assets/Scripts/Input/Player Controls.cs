// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Input/Player Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Player Controls"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""714eb0bd-099c-4597-b1cb-6522ddca2831"",
            ""actions"": [
                {
                    ""name"": ""MouseMove"",
                    ""type"": ""Value"",
                    ""id"": ""5d7188c3-f747-426c-a61f-0b2db6d19f13"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Movement"",
                    ""type"": ""Button"",
                    ""id"": ""8894d885-11ca-4cde-a8cc-503404cd3e9c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""204f2596-eaa1-4dbd-820f-7ea043980e6a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Rotate"",
                    ""type"": ""Button"",
                    ""id"": ""90c74a0f-d203-4f1a-8f38-764c90299999"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a46ab78f-2bda-42ae-aa14-c688b8c1fac0"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""e1757253-2592-415e-9d70-42df7ee0798a"",
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
                    ""id"": ""2a9d1e2f-80a7-4cc8-93b6-7ba8f68b2fba"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""6d8bfa55-6f12-4eb9-991d-d8fb47696ea4"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""837e9e66-d643-426f-94fa-72d1cde536fd"",
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
                    ""id"": ""995e37d9-5d98-492e-b283-31772d085ac1"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Controller"",
                    ""id"": ""086a8b68-c8bd-4abd-aae9-982e6238758c"",
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
                    ""id"": ""b5f67840-d2b5-4a6a-b842-85cf9e0c4512"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""674ced7a-3375-445c-a5db-93918afeddf5"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""960dfbb4-3db7-48f7-8799-86e3f442584f"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""d452c707-a87b-46be-8a22-0b73f5f89308"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""50d3c07d-d00a-430b-8b18-8c99adb34709"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Right Joystick"",
                    ""id"": ""a7942c49-a421-48d7-bbe4-2061a1c7b85a"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""bd8b8380-fdf7-411f-a7ff-4995b3c861fa"",
                    ""path"": ""<Gamepad>/rightStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""0d13d911-2680-4bd1-9632-59c6e816e657"",
                    ""path"": ""<Gamepad>/rightStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""923872a3-7229-4c48-93c8-40f79c50b841"",
                    ""path"": ""<Gamepad>/rightStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""fe9cc754-c80c-4d50-bd82-7382986df2bf"",
                    ""path"": ""<Gamepad>/rightStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrow Keys"",
                    ""id"": ""90aa2f05-428b-4240-9864-d2faa0bb85d4"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""60385b77-af43-4b65-bec8-83b3fb768ecf"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""0779d49a-095f-4feb-9583-ec4146f17cd2"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""f067271e-7bc7-4698-a185-22951b5f41b7"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""2ae70d31-bda1-4a60-9775-255055b3f323"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""WeaponsHandling"",
            ""id"": ""53f2871f-6d5d-4f7c-b6a5-8fa339ab4700"",
            ""actions"": [
                {
                    ""name"": ""Fire"",
                    ""type"": ""Button"",
                    ""id"": ""f5253cc8-e9cb-4a1a-98ca-4eb6a7ea87b3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Reload"",
                    ""type"": ""Button"",
                    ""id"": ""f7dd7ec6-b60c-4286-a135-6ea30849f57c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Aim"",
                    ""type"": ""Button"",
                    ""id"": ""59280cb6-7627-4799-94de-499525c3a85b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SwapWeapon"",
                    ""type"": ""Button"",
                    ""id"": ""f33551b4-13b9-4932-8925-b110eb3ec3ca"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Charge"",
                    ""type"": ""Button"",
                    ""id"": ""66c29381-d903-4773-b979-f48fefcccbc0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e9945b98-efc7-4f12-875a-bfec183d95b2"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""188f9780-21d3-4c22-84fa-352147574c7a"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""994c3367-686c-4d2c-bcb4-ea9b9641e467"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d5e732c8-ac2c-46bb-a346-4a4eef558718"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Reload"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""896869a0-19b4-4688-86f9-ffb2b8c47580"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e90bdd6c-4361-4225-9c0a-20a8f8dd99e8"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwapWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2edd1221-f22d-4887-85d5-8d9e2464fb93"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwapWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ababa58f-d194-4686-9f69-876a2f2551a5"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Charge"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c585e8d1-6f92-4271-a18f-646f8c1e0d5a"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Charge"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Interaction"",
            ""id"": ""7594f908-eb4f-4c36-a8c5-80efcf6db6cc"",
            ""actions"": [
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""9d9eca18-8dbf-4dca-a1da-b0a2dcae9714"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""18cce786-24f9-46d0-837b-7f6510ece529"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1784d1d4-1ff8-48e8-9487-e7e84e2a8d9e"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Settings"",
            ""id"": ""09405efd-813b-40a9-aaf4-0a863712a36b"",
            ""actions"": [
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""ad3cc891-d96f-4a5d-bb35-d3fbc06ec8a8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Restart"",
                    ""type"": ""Button"",
                    ""id"": ""4c2e763b-d783-4801-bd0c-6ea2e0a4d1a0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""89f138ca-5ac0-4fc6-ac05-90464ffa7616"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c950a3fd-37b8-4f8b-bc9f-5364438c5c00"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0ee80d92-4672-4b18-9cdc-176485c2734c"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Restart"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Abilities"",
            ""id"": ""90757196-94c9-474c-b28d-bf4f72a7ce12"",
            ""actions"": [
                {
                    ""name"": ""ActivateAbility"",
                    ""type"": ""Button"",
                    ""id"": ""48961bec-147f-4d2f-a593-293c46a29706"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SwapAbility"",
                    ""type"": ""Button"",
                    ""id"": ""7299aa3d-9bfa-40a7-b157-bc5bc28dded7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""4ca27241-230c-4976-8c42-9c54d691336e"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ActivateAbility"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""069571ae-339b-45d1-adf0-b264b86b3216"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ActivateAbility"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a5cd7fcd-8640-4ad1-9172-afa08721d008"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwapAbility"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7611153a-c13c-48db-a97b-e56b9c4d5b1e"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwapAbility"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""f4fb2a7d-9e57-44c3-bab6-92b4bee4818a"",
            ""actions"": [
                {
                    ""name"": ""Progress"",
                    ""type"": ""Button"",
                    ""id"": ""07336fec-c804-4919-b486-e53765f9cd02"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Left"",
                    ""type"": ""Button"",
                    ""id"": ""61c480ce-93d6-472b-a2cd-69f4dfd6e93d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Right"",
                    ""type"": ""Button"",
                    ""id"": ""046e2cae-5ac6-4620-808d-d4f6605611e7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Escape"",
                    ""type"": ""Button"",
                    ""id"": ""60372f04-18fa-4a90-8442-e1006bff5146"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Promote"",
                    ""type"": ""Button"",
                    ""id"": ""7f8adebf-7317-485e-a0fa-51f5c673d6b6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PrintInfo"",
                    ""type"": ""Button"",
                    ""id"": ""6f03802e-7d48-44cb-a725-c34e83c0855c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Up"",
                    ""type"": ""Button"",
                    ""id"": ""75bebc44-0f02-43f9-bf6c-0151d831f3b5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Down"",
                    ""type"": ""Button"",
                    ""id"": ""d8b48d28-c31f-4159-8db7-50be53a52df7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""7bc17137-050f-4665-ab23-2ffb8d738d83"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Progress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""791dbd02-c7ee-448c-b1ad-7548285c5ea1"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Progress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0cf152cc-b602-4135-ae1d-6dd6a444d497"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Progress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0230a803-277f-46d5-945c-5feebe78bf3b"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2280eb1e-be5a-43ba-a375-ddb877fee387"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b4b0ef27-30d6-4fad-8a67-8a84463f3c82"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""974b1199-a2c0-4e06-87f3-d0bc04e78737"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f4488acd-52dd-4bab-bd53-f53a1cf580dd"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5f6781a1-617a-47b5-9a5b-4d75ad7798c0"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1d0a9011-8351-44df-90a5-b4e2ece71cfa"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""787337f8-5bc9-47a4-8352-a4acde7c1c38"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a56d3c9b-3873-4f88-a174-97586af5aa65"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Escape"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ef04576f-0f26-410d-a589-455872610e17"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Escape"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b2a3f4e7-5f63-4e26-9abd-4292075d5323"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Promote"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a1546ab2-2962-43bf-918a-d0624a5c908b"",
                    ""path"": ""<Keyboard>/g"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PrintInfo"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e331ac04-40ef-4021-b6d2-ded26b0b80ab"",
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
                    ""id"": ""5f6b9206-1a29-499b-8993-47e5131adf9e"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d6b3e963-2e9e-4826-bedc-9da4f7ce1947"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""13e670ac-d887-47f2-a7cc-874cf9e91e46"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a134faab-061e-4cbe-9f76-172a4dbcbf72"",
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
                    ""id"": ""777df9d1-9f35-4a7a-8870-dee10eac92ee"",
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
                    ""id"": ""bb554b88-c490-43cf-9236-055d58b0a604"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e38c5dbf-8701-42e9-bf00-aeec2ea90bba"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Debug"",
            ""id"": ""28f00fcd-c67f-46f4-bd78-3cf8f0df30f2"",
            ""actions"": [
                {
                    ""name"": ""RewardScrap"",
                    ""type"": ""Button"",
                    ""id"": ""1a0e953a-3bfd-4f4e-9c0e-70c1c0709942"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": []
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_MouseMove = m_Player.FindAction("MouseMove", throwIfNotFound: true);
        m_Player_Movement = m_Player.FindAction("Movement", throwIfNotFound: true);
        m_Player_Jump = m_Player.FindAction("Jump", throwIfNotFound: true);
        m_Player_Rotate = m_Player.FindAction("Rotate", throwIfNotFound: true);
        // WeaponsHandling
        m_WeaponsHandling = asset.FindActionMap("WeaponsHandling", throwIfNotFound: true);
        m_WeaponsHandling_Fire = m_WeaponsHandling.FindAction("Fire", throwIfNotFound: true);
        m_WeaponsHandling_Reload = m_WeaponsHandling.FindAction("Reload", throwIfNotFound: true);
        m_WeaponsHandling_Aim = m_WeaponsHandling.FindAction("Aim", throwIfNotFound: true);
        m_WeaponsHandling_SwapWeapon = m_WeaponsHandling.FindAction("SwapWeapon", throwIfNotFound: true);
        m_WeaponsHandling_Charge = m_WeaponsHandling.FindAction("Charge", throwIfNotFound: true);
        // Interaction
        m_Interaction = asset.FindActionMap("Interaction", throwIfNotFound: true);
        m_Interaction_Interact = m_Interaction.FindAction("Interact", throwIfNotFound: true);
        // Settings
        m_Settings = asset.FindActionMap("Settings", throwIfNotFound: true);
        m_Settings_Pause = m_Settings.FindAction("Pause", throwIfNotFound: true);
        m_Settings_Restart = m_Settings.FindAction("Restart", throwIfNotFound: true);
        // Abilities
        m_Abilities = asset.FindActionMap("Abilities", throwIfNotFound: true);
        m_Abilities_ActivateAbility = m_Abilities.FindAction("ActivateAbility", throwIfNotFound: true);
        m_Abilities_SwapAbility = m_Abilities.FindAction("SwapAbility", throwIfNotFound: true);
        // UI
        m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
        m_UI_Progress = m_UI.FindAction("Progress", throwIfNotFound: true);
        m_UI_Left = m_UI.FindAction("Left", throwIfNotFound: true);
        m_UI_Right = m_UI.FindAction("Right", throwIfNotFound: true);
        m_UI_Escape = m_UI.FindAction("Escape", throwIfNotFound: true);
        m_UI_Promote = m_UI.FindAction("Promote", throwIfNotFound: true);
        m_UI_PrintInfo = m_UI.FindAction("PrintInfo", throwIfNotFound: true);
        m_UI_Up = m_UI.FindAction("Up", throwIfNotFound: true);
        m_UI_Down = m_UI.FindAction("Down", throwIfNotFound: true);
        // Debug
        m_Debug = asset.FindActionMap("Debug", throwIfNotFound: true);
        m_Debug_RewardScrap = m_Debug.FindAction("RewardScrap", throwIfNotFound: true);
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
    private readonly InputAction m_Player_MouseMove;
    private readonly InputAction m_Player_Movement;
    private readonly InputAction m_Player_Jump;
    private readonly InputAction m_Player_Rotate;
    public struct PlayerActions
    {
        private @PlayerControls m_Wrapper;
        public PlayerActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @MouseMove => m_Wrapper.m_Player_MouseMove;
        public InputAction @Movement => m_Wrapper.m_Player_Movement;
        public InputAction @Jump => m_Wrapper.m_Player_Jump;
        public InputAction @Rotate => m_Wrapper.m_Player_Rotate;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @MouseMove.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMouseMove;
                @MouseMove.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMouseMove;
                @MouseMove.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMouseMove;
                @Movement.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Jump.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Rotate.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRotate;
                @Rotate.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRotate;
                @Rotate.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRotate;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MouseMove.started += instance.OnMouseMove;
                @MouseMove.performed += instance.OnMouseMove;
                @MouseMove.canceled += instance.OnMouseMove;
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Rotate.started += instance.OnRotate;
                @Rotate.performed += instance.OnRotate;
                @Rotate.canceled += instance.OnRotate;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // WeaponsHandling
    private readonly InputActionMap m_WeaponsHandling;
    private IWeaponsHandlingActions m_WeaponsHandlingActionsCallbackInterface;
    private readonly InputAction m_WeaponsHandling_Fire;
    private readonly InputAction m_WeaponsHandling_Reload;
    private readonly InputAction m_WeaponsHandling_Aim;
    private readonly InputAction m_WeaponsHandling_SwapWeapon;
    private readonly InputAction m_WeaponsHandling_Charge;
    public struct WeaponsHandlingActions
    {
        private @PlayerControls m_Wrapper;
        public WeaponsHandlingActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Fire => m_Wrapper.m_WeaponsHandling_Fire;
        public InputAction @Reload => m_Wrapper.m_WeaponsHandling_Reload;
        public InputAction @Aim => m_Wrapper.m_WeaponsHandling_Aim;
        public InputAction @SwapWeapon => m_Wrapper.m_WeaponsHandling_SwapWeapon;
        public InputAction @Charge => m_Wrapper.m_WeaponsHandling_Charge;
        public InputActionMap Get() { return m_Wrapper.m_WeaponsHandling; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(WeaponsHandlingActions set) { return set.Get(); }
        public void SetCallbacks(IWeaponsHandlingActions instance)
        {
            if (m_Wrapper.m_WeaponsHandlingActionsCallbackInterface != null)
            {
                @Fire.started -= m_Wrapper.m_WeaponsHandlingActionsCallbackInterface.OnFire;
                @Fire.performed -= m_Wrapper.m_WeaponsHandlingActionsCallbackInterface.OnFire;
                @Fire.canceled -= m_Wrapper.m_WeaponsHandlingActionsCallbackInterface.OnFire;
                @Reload.started -= m_Wrapper.m_WeaponsHandlingActionsCallbackInterface.OnReload;
                @Reload.performed -= m_Wrapper.m_WeaponsHandlingActionsCallbackInterface.OnReload;
                @Reload.canceled -= m_Wrapper.m_WeaponsHandlingActionsCallbackInterface.OnReload;
                @Aim.started -= m_Wrapper.m_WeaponsHandlingActionsCallbackInterface.OnAim;
                @Aim.performed -= m_Wrapper.m_WeaponsHandlingActionsCallbackInterface.OnAim;
                @Aim.canceled -= m_Wrapper.m_WeaponsHandlingActionsCallbackInterface.OnAim;
                @SwapWeapon.started -= m_Wrapper.m_WeaponsHandlingActionsCallbackInterface.OnSwapWeapon;
                @SwapWeapon.performed -= m_Wrapper.m_WeaponsHandlingActionsCallbackInterface.OnSwapWeapon;
                @SwapWeapon.canceled -= m_Wrapper.m_WeaponsHandlingActionsCallbackInterface.OnSwapWeapon;
                @Charge.started -= m_Wrapper.m_WeaponsHandlingActionsCallbackInterface.OnCharge;
                @Charge.performed -= m_Wrapper.m_WeaponsHandlingActionsCallbackInterface.OnCharge;
                @Charge.canceled -= m_Wrapper.m_WeaponsHandlingActionsCallbackInterface.OnCharge;
            }
            m_Wrapper.m_WeaponsHandlingActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Fire.started += instance.OnFire;
                @Fire.performed += instance.OnFire;
                @Fire.canceled += instance.OnFire;
                @Reload.started += instance.OnReload;
                @Reload.performed += instance.OnReload;
                @Reload.canceled += instance.OnReload;
                @Aim.started += instance.OnAim;
                @Aim.performed += instance.OnAim;
                @Aim.canceled += instance.OnAim;
                @SwapWeapon.started += instance.OnSwapWeapon;
                @SwapWeapon.performed += instance.OnSwapWeapon;
                @SwapWeapon.canceled += instance.OnSwapWeapon;
                @Charge.started += instance.OnCharge;
                @Charge.performed += instance.OnCharge;
                @Charge.canceled += instance.OnCharge;
            }
        }
    }
    public WeaponsHandlingActions @WeaponsHandling => new WeaponsHandlingActions(this);

    // Interaction
    private readonly InputActionMap m_Interaction;
    private IInteractionActions m_InteractionActionsCallbackInterface;
    private readonly InputAction m_Interaction_Interact;
    public struct InteractionActions
    {
        private @PlayerControls m_Wrapper;
        public InteractionActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Interact => m_Wrapper.m_Interaction_Interact;
        public InputActionMap Get() { return m_Wrapper.m_Interaction; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InteractionActions set) { return set.Get(); }
        public void SetCallbacks(IInteractionActions instance)
        {
            if (m_Wrapper.m_InteractionActionsCallbackInterface != null)
            {
                @Interact.started -= m_Wrapper.m_InteractionActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_InteractionActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_InteractionActionsCallbackInterface.OnInteract;
            }
            m_Wrapper.m_InteractionActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
            }
        }
    }
    public InteractionActions @Interaction => new InteractionActions(this);

    // Settings
    private readonly InputActionMap m_Settings;
    private ISettingsActions m_SettingsActionsCallbackInterface;
    private readonly InputAction m_Settings_Pause;
    private readonly InputAction m_Settings_Restart;
    public struct SettingsActions
    {
        private @PlayerControls m_Wrapper;
        public SettingsActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Pause => m_Wrapper.m_Settings_Pause;
        public InputAction @Restart => m_Wrapper.m_Settings_Restart;
        public InputActionMap Get() { return m_Wrapper.m_Settings; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(SettingsActions set) { return set.Get(); }
        public void SetCallbacks(ISettingsActions instance)
        {
            if (m_Wrapper.m_SettingsActionsCallbackInterface != null)
            {
                @Pause.started -= m_Wrapper.m_SettingsActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_SettingsActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_SettingsActionsCallbackInterface.OnPause;
                @Restart.started -= m_Wrapper.m_SettingsActionsCallbackInterface.OnRestart;
                @Restart.performed -= m_Wrapper.m_SettingsActionsCallbackInterface.OnRestart;
                @Restart.canceled -= m_Wrapper.m_SettingsActionsCallbackInterface.OnRestart;
            }
            m_Wrapper.m_SettingsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
                @Restart.started += instance.OnRestart;
                @Restart.performed += instance.OnRestart;
                @Restart.canceled += instance.OnRestart;
            }
        }
    }
    public SettingsActions @Settings => new SettingsActions(this);

    // Abilities
    private readonly InputActionMap m_Abilities;
    private IAbilitiesActions m_AbilitiesActionsCallbackInterface;
    private readonly InputAction m_Abilities_ActivateAbility;
    private readonly InputAction m_Abilities_SwapAbility;
    public struct AbilitiesActions
    {
        private @PlayerControls m_Wrapper;
        public AbilitiesActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @ActivateAbility => m_Wrapper.m_Abilities_ActivateAbility;
        public InputAction @SwapAbility => m_Wrapper.m_Abilities_SwapAbility;
        public InputActionMap Get() { return m_Wrapper.m_Abilities; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(AbilitiesActions set) { return set.Get(); }
        public void SetCallbacks(IAbilitiesActions instance)
        {
            if (m_Wrapper.m_AbilitiesActionsCallbackInterface != null)
            {
                @ActivateAbility.started -= m_Wrapper.m_AbilitiesActionsCallbackInterface.OnActivateAbility;
                @ActivateAbility.performed -= m_Wrapper.m_AbilitiesActionsCallbackInterface.OnActivateAbility;
                @ActivateAbility.canceled -= m_Wrapper.m_AbilitiesActionsCallbackInterface.OnActivateAbility;
                @SwapAbility.started -= m_Wrapper.m_AbilitiesActionsCallbackInterface.OnSwapAbility;
                @SwapAbility.performed -= m_Wrapper.m_AbilitiesActionsCallbackInterface.OnSwapAbility;
                @SwapAbility.canceled -= m_Wrapper.m_AbilitiesActionsCallbackInterface.OnSwapAbility;
            }
            m_Wrapper.m_AbilitiesActionsCallbackInterface = instance;
            if (instance != null)
            {
                @ActivateAbility.started += instance.OnActivateAbility;
                @ActivateAbility.performed += instance.OnActivateAbility;
                @ActivateAbility.canceled += instance.OnActivateAbility;
                @SwapAbility.started += instance.OnSwapAbility;
                @SwapAbility.performed += instance.OnSwapAbility;
                @SwapAbility.canceled += instance.OnSwapAbility;
            }
        }
    }
    public AbilitiesActions @Abilities => new AbilitiesActions(this);

    // UI
    private readonly InputActionMap m_UI;
    private IUIActions m_UIActionsCallbackInterface;
    private readonly InputAction m_UI_Progress;
    private readonly InputAction m_UI_Left;
    private readonly InputAction m_UI_Right;
    private readonly InputAction m_UI_Escape;
    private readonly InputAction m_UI_Promote;
    private readonly InputAction m_UI_PrintInfo;
    private readonly InputAction m_UI_Up;
    private readonly InputAction m_UI_Down;
    public struct UIActions
    {
        private @PlayerControls m_Wrapper;
        public UIActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Progress => m_Wrapper.m_UI_Progress;
        public InputAction @Left => m_Wrapper.m_UI_Left;
        public InputAction @Right => m_Wrapper.m_UI_Right;
        public InputAction @Escape => m_Wrapper.m_UI_Escape;
        public InputAction @Promote => m_Wrapper.m_UI_Promote;
        public InputAction @PrintInfo => m_Wrapper.m_UI_PrintInfo;
        public InputAction @Up => m_Wrapper.m_UI_Up;
        public InputAction @Down => m_Wrapper.m_UI_Down;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void SetCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterface != null)
            {
                @Progress.started -= m_Wrapper.m_UIActionsCallbackInterface.OnProgress;
                @Progress.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnProgress;
                @Progress.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnProgress;
                @Left.started -= m_Wrapper.m_UIActionsCallbackInterface.OnLeft;
                @Left.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnLeft;
                @Left.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnLeft;
                @Right.started -= m_Wrapper.m_UIActionsCallbackInterface.OnRight;
                @Right.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnRight;
                @Right.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnRight;
                @Escape.started -= m_Wrapper.m_UIActionsCallbackInterface.OnEscape;
                @Escape.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnEscape;
                @Escape.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnEscape;
                @Promote.started -= m_Wrapper.m_UIActionsCallbackInterface.OnPromote;
                @Promote.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnPromote;
                @Promote.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnPromote;
                @PrintInfo.started -= m_Wrapper.m_UIActionsCallbackInterface.OnPrintInfo;
                @PrintInfo.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnPrintInfo;
                @PrintInfo.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnPrintInfo;
                @Up.started -= m_Wrapper.m_UIActionsCallbackInterface.OnUp;
                @Up.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnUp;
                @Up.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnUp;
                @Down.started -= m_Wrapper.m_UIActionsCallbackInterface.OnDown;
                @Down.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnDown;
                @Down.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnDown;
            }
            m_Wrapper.m_UIActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Progress.started += instance.OnProgress;
                @Progress.performed += instance.OnProgress;
                @Progress.canceled += instance.OnProgress;
                @Left.started += instance.OnLeft;
                @Left.performed += instance.OnLeft;
                @Left.canceled += instance.OnLeft;
                @Right.started += instance.OnRight;
                @Right.performed += instance.OnRight;
                @Right.canceled += instance.OnRight;
                @Escape.started += instance.OnEscape;
                @Escape.performed += instance.OnEscape;
                @Escape.canceled += instance.OnEscape;
                @Promote.started += instance.OnPromote;
                @Promote.performed += instance.OnPromote;
                @Promote.canceled += instance.OnPromote;
                @PrintInfo.started += instance.OnPrintInfo;
                @PrintInfo.performed += instance.OnPrintInfo;
                @PrintInfo.canceled += instance.OnPrintInfo;
                @Up.started += instance.OnUp;
                @Up.performed += instance.OnUp;
                @Up.canceled += instance.OnUp;
                @Down.started += instance.OnDown;
                @Down.performed += instance.OnDown;
                @Down.canceled += instance.OnDown;
            }
        }
    }
    public UIActions @UI => new UIActions(this);

    // Debug
    private readonly InputActionMap m_Debug;
    private IDebugActions m_DebugActionsCallbackInterface;
    private readonly InputAction m_Debug_RewardScrap;
    public struct DebugActions
    {
        private @PlayerControls m_Wrapper;
        public DebugActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @RewardScrap => m_Wrapper.m_Debug_RewardScrap;
        public InputActionMap Get() { return m_Wrapper.m_Debug; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DebugActions set) { return set.Get(); }
        public void SetCallbacks(IDebugActions instance)
        {
            if (m_Wrapper.m_DebugActionsCallbackInterface != null)
            {
                @RewardScrap.started -= m_Wrapper.m_DebugActionsCallbackInterface.OnRewardScrap;
                @RewardScrap.performed -= m_Wrapper.m_DebugActionsCallbackInterface.OnRewardScrap;
                @RewardScrap.canceled -= m_Wrapper.m_DebugActionsCallbackInterface.OnRewardScrap;
            }
            m_Wrapper.m_DebugActionsCallbackInterface = instance;
            if (instance != null)
            {
                @RewardScrap.started += instance.OnRewardScrap;
                @RewardScrap.performed += instance.OnRewardScrap;
                @RewardScrap.canceled += instance.OnRewardScrap;
            }
        }
    }
    public DebugActions @Debug => new DebugActions(this);
    public interface IPlayerActions
    {
        void OnMouseMove(InputAction.CallbackContext context);
        void OnMovement(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnRotate(InputAction.CallbackContext context);
    }
    public interface IWeaponsHandlingActions
    {
        void OnFire(InputAction.CallbackContext context);
        void OnReload(InputAction.CallbackContext context);
        void OnAim(InputAction.CallbackContext context);
        void OnSwapWeapon(InputAction.CallbackContext context);
        void OnCharge(InputAction.CallbackContext context);
    }
    public interface IInteractionActions
    {
        void OnInteract(InputAction.CallbackContext context);
    }
    public interface ISettingsActions
    {
        void OnPause(InputAction.CallbackContext context);
        void OnRestart(InputAction.CallbackContext context);
    }
    public interface IAbilitiesActions
    {
        void OnActivateAbility(InputAction.CallbackContext context);
        void OnSwapAbility(InputAction.CallbackContext context);
    }
    public interface IUIActions
    {
        void OnProgress(InputAction.CallbackContext context);
        void OnLeft(InputAction.CallbackContext context);
        void OnRight(InputAction.CallbackContext context);
        void OnEscape(InputAction.CallbackContext context);
        void OnPromote(InputAction.CallbackContext context);
        void OnPrintInfo(InputAction.CallbackContext context);
        void OnUp(InputAction.CallbackContext context);
        void OnDown(InputAction.CallbackContext context);
    }
    public interface IDebugActions
    {
        void OnRewardScrap(InputAction.CallbackContext context);
    }
}
