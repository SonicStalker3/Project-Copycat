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

        private CharacterController _controller;
        public CharacterController Controller => _controller;

        [Inject]
        void Construct(InputHandler inputHander) //PlayerInfo info, InputHandler _inputHander
        {
            _input = inputHander;
        }
        

        void Start()
        {
            _controller = GetComponent<CharacterController>();
            //if (playerModel) playerModel = transform.Find("Graphics").gameObject;
        }

        public void Test()
        {
            foreach (string key in AbilitiesList.Keys)
            {
                Debug.Log(key);
            }
        }

        /*private void OnCollisionEnter(Collision other)
        {
            Debug.Log(other.collider.gameObject.name);
        }*/

    }
}