using System.Collections;
using Objects.Entities;
using Resources.Abilities.BaseAbilities;
using Skills;
using UnityEngine;

namespace Resources.Abilities
{
    public class WallJumping: Ability
    {
        [SerializeField] private float verticalJumpForce = 2;
        [SerializeField] private float horizontalJumpForce = 10;
        [SerializeField] private bool isJump;
        [SerializeField] Jump jumpAction;

        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private Vector3 wallNormal;
        private ContactPoint[] _point;

        //[SerializeField] Move _moveAction;
        private void Start()
        {
            //_rigidbody = GetComponent<Rigidbody>();
            //_jumpAction = GetComponent<Jump>();
            //isJumpAction = _jumpAction.enabled;
        }

        protected override void OnActivePlayer(Player player)
        {
            if (jumpAction == null)
            {
                player.AbilitiesList.TryGetValue(nameof(Jump), out Ability _jump);
                jumpAction = _jump as Jump;
            }
            
            if (isJump && !player.Controller.isGrounded)
            {
                //_jumpAction.enabled = false;
                if (player.InputHandler.JumpInput)
                {
                    // Vector3 reflectionVector = Vector3.Reflect(player.moveDirection, -wallNormal);
                    Vector3 jumpDirection = wallNormal; //* -1; // Jump away from the wall
                    jumpDirection.y = verticalJumpForce;
                    //player.moveDirection = reflectionVector.normalized;
                    //player.moveDirection = transform.TransformDirection(player.moveDirection);
                    StartCoroutine(Jump(player,jumpDirection * horizontalJumpForce));
                    //player.Controller.Move(player,jumpDirection * horizontalJumpForce * Time.deltaTime);
                }
                else player.moveDirection.y = -0.5f;
            }
            else
            {
                //_rigidbody.isKinematic = false;
                //_jumpAction.enabled = isJumpAction;
            }
        } 
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Wall") && other.contacts[0].normal.y < 0.5)
            {
                isJump = true;
                wallNormal = other.contacts[0].normal;
                _point = other.contacts;
            }
            else
            {
                _point = other.contacts;
            }
        }
        
        private void OnCollisionExit(Collision other)
        {
            if (other.contacts.Length == 0 || other.gameObject.CompareTag("Wall")) //&&  other.contacts[0].normal.y < 0.5
            {
                isJump = false;
            }
        }

        IEnumerator Jump(Player player,Vector3 movedir)
        {
            player.Controller.Move(movedir*Time.deltaTime);
            if (player.Controller.isGrounded)
            {
                Debug.Log("Nooo");
                //isJump = false;
                yield break;
            }
            yield return null;
        }
    }
    
}