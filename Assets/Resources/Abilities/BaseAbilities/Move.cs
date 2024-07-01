using Objects.Entities;
using Skills;
using UnityEngine;

namespace Resources.Abilities.BaseAbilities
{
    public class Move: Ability
    {
        public float speed = 6.0f;
        [SerializeField, Range(5f, 50f)]private float gravity = 20f;
        public int gravityScale = 1;
        
        protected override void OnActivePlayer(Player player)
        {
            //Debug.Log("IsMoving");
            player.moveDirection = new Vector3(player.InputHandler.MoveInput.x * speed, player.moveDirection.y, player.InputHandler.MoveInput.y * speed); //(Vector3.right * _input.MoveInput.x + Vector3.forward * _input.MoveInput.y) * speed ;
            player.moveDirection = transform.TransformDirection(player.moveDirection);
            player.moveDirection.y -= gravity * gravityScale * Time.deltaTime;
            player.Controller.Move(player.moveDirection * Time.deltaTime);
        }
        
        protected override void OnActiveEntity(Entity entity)
        { 
            Debug.Log("Entity Looked");
//            Debug.Log(entity.E_name);
        }
    }
}