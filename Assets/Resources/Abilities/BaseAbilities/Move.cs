using Objects.Entities;
using Skills;
using UnityEngine;

namespace Resources.Abilities.BaseAbilities
{
    public class Move: Ability
    {
        public float speed = 6.0f;
        [Range(5f, 50f), SerializeField] private float gravity = 20.0f;
        protected override void OnActivePlayer(Player player)
        {
            //Debug.Log("IsMoving");
            player.moveDirection = new Vector3(player.InputHandler.MoveInput.x * speed, player.moveDirection.y, player.InputHandler.MoveInput.y * speed); //(Vector3.right * _input.MoveInput.x + Vector3.forward * _input.MoveInput.y) * speed ;
            
            player.moveDirection = transform.TransformDirection(player.moveDirection);
            player.moveDirection.y -= gravity * Time.deltaTime;
            player.Controller.Move(player.moveDirection * Time.deltaTime);
        }
    }
}