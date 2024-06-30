using System.Collections;
using DefaultNamespace.InputHandlers;
using UnityEngine;
using Zenject;

namespace Objects.Entities
{
    [RequireComponent(typeof(CharacterController))]
    public class Player : Entity
    {
        [Header("Base Values")] 

        private InputHandler _input;
        public InputHandler InputHandler => _input;

        public Vector3 moveDirection = Vector3.zero;

        private CharacterController controller;
        public CharacterController Controller => controller;

        [Inject]
        void Construct(InputHandler inputHander) //PlayerInfo info, InputHandler _inputHander
        {
            _input = inputHander;
        }
        

        void Start()
        {
            controller = GetComponent<CharacterController>();
            //if (playerModel) playerModel = transform.Find("Graphics").gameObject;
        }

        IEnumerator JumpAnim()
        {
            //JumpPattern.Evaluate();
            return null;
        }
        
    }
}