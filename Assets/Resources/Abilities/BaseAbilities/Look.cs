using Objects.Entities;
using Skills;
using UnityEngine;

namespace Resources.Abilities.BaseAbilities
{
    public class Look: Ability
    {
        [SerializeField]
        private float rotateSpeed;
        [SerializeField] private Transform playerCamera;
        [SerializeField] private bool isThirdPerson;
        [SerializeField] private GameObject playerModel;
        [SerializeField] private float distance;

        void Start()
        {
            playerCamera = GetComponentInChildren<Camera>().transform.parent;
            playerModel ??= transform.Find("Graphics").gameObject;
        }
        protected override void OnActivePlayer(Player player)
        {
            Cursor.lockState = CursorLockMode.Locked;
            if (isThirdPerson)
            {
                playerCamera.transform.GetChild(0).transform.position = Vector3.back * distance;
            }
            
            Vector2 lookDelta = player.InputHandler.LookInput * rotateSpeed;
            //Debug.Log(player.InputHandler.LookInput);

            transform.Rotate(0, lookDelta.x, 0);
            playerCamera.Rotate(-lookDelta.y, 0, 0);

            if (playerCamera.localRotation.eulerAngles.y != 0)
            {
                playerCamera.Rotate(lookDelta.y, 0, 0);
            }
            Debug.Log("Player Looked");
        }
        protected override void OnActiveEntity(Entity entity)
        { 
            Debug.Log("Entity Looked");
//            Debug.Log(entity.E_name);
        }
    }
}