using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace DefaultNamespace.InputHandlers
{
    public class InputHandler
    {
        private string IconsPath { get; } = "Graphics/Buttons";

        private InputAction _navigateUI;

        //private static ActionMaps _actionMapEnum;
        private InputActionMap _currentActionMap;
        private string _type = "Keyboard&Mouse";

        public PlayerInput _inputHandler;


        private InputActionMap GameplayActionMap;
        private InputActionMap DialogActionMap;
        private InputActionMap UIActionMap;

        public float CursorSensitivity = 2;

        [Inject]
        InputHandler(PlayerInput inputHandler)
        {
            _inputHandler = inputHandler;
        }

        public void Test()
        {
            if (_inputHandler.actions["Move"].ReadValue<Vector2>() != Vector2.zero |
                _inputHandler.actions["Look"].ReadValue<Vector2>() * CursorSensitivity != Vector2.zero)
            {
                Debug.Log($"Move: {MoveInput}");
                Debug.Log($"Look: {LookInput}");
            
                Debug.Log($"Move: {_inputHandler.actions["Move"].ReadValue<Vector2>()}");
                Debug.Log($"Look: {_inputHandler.actions["Look"].ReadValue<Vector2>() * CursorSensitivity}");
            }
        }

        
        public Vector2 MoveInput => _inputHandler.actions["Move"].ReadValue<Vector2>();
        public Vector2 LookInput => _inputHandler.actions["Look"].ReadValue<Vector2>() * CursorSensitivity;
        public bool JumpInput => _inputHandler.actions["Jump"].triggered;
        public bool AttackBtn => _inputHandler.actions["Attack"].triggered;
        public bool InteractBtn => _inputHandler.actions["Interact"].triggered;
        public bool MenuBtn => _inputHandler.actions["Menu"].triggered;
        
        public bool NextBtn => _inputHandler.actions["Next"].triggered;
        public bool HistoryBtn => _inputHandler.actions["History"].triggered;
        
        //public static ActionMaps CurrentActionMap => _actionMapEnum;
        public InputAction NavigateUI => _navigateUI;
    }
}