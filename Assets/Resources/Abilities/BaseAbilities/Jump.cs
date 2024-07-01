using Objects.Entities;
using Skills;
using UnityEngine;

namespace Resources.Abilities.BaseAbilities
{
    public class Jump: Ability
    {
        [SerializeField] private float jumpForce = 10;
        /*[SerializeField]
        private AnimationCurve JumpPattern;*/

        protected override void OnActivePlayer(Player player)
        {
            if (player.Controller.isGrounded)
            {
                JumpAction(player);
                /*Debug.Log("Player Jumped");*/
            }
        } 
        protected override void OnActiveEntity(Entity entity) => Debug.Log("Entity Jumped");

        public void JumpAction(Player player)
        {
            if (player.InputHandler.JumpInput) player.moveDirection.y = jumpForce;
            else player.moveDirection.y = 0;
        }

        private void OnValidate()
        {
            jumpForce = Mathf.Clamp(jumpForce,1,100_000);
        }
    }
}