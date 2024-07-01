using Objects.Entities;
using Resources.Abilities.BaseAbilities;
using Skills;
using UnityEngine;

namespace Resources.Abilities
{
    public class WallRunning: Ability
    {
        //[SerializeField] private float jumpForce = 10;
        [SerializeField] private bool isWall;
        [SerializeField] Move moveAction;
        
        protected override void OnActivePlayer(Player player)
        {
            if (moveAction == null)
            {
                player.AbilitiesList.TryGetValue(nameof(Move), out Ability move);
                moveAction = move as Move;
            }
            
            moveAction.gravityScale = 0;
            if (isWall && !player.Controller.isGrounded)
            {
                player.moveDirection.y = -2.5f;
            }
            else
            {
                moveAction.gravityScale = 1;
                //_jumpAction.enabled = isJumpAction;
            }
        } 
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Wall")) isWall = true;
        }
        
        private void OnCollisionExit(Collision other)
        {
            if (other.gameObject.CompareTag("Wall")) isWall = false;
        }
    }
}