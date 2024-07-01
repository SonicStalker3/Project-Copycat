using Objects.Entities;
using Resources.Abilities.BaseAbilities;
using Skills;
using UnityEngine;

namespace Resources.Abilities
{
    public class UseLadder: Ability
    {
        [SerializeField] private bool isLadder;
        [SerializeField] private Ladder _ladder;
        
        [Range(1,20)]
        public float climbSpeed = 8.0f;
        public float ladderDetectionRadius = 0.5f;

        private bool isClimbing = false;
        private Vector3 ladderNormal;
        private Transform ladderTransform;

        private Move _move;
        private Rigidbody _rigidbody;

        private void Start()
        {
            _move = GetComponent<Move>();
            _rigidbody = GetComponent<Rigidbody>();
        }

        protected override void OnActivePlayer(Player player)
        {
            if (isLadder)
            {
                StartClimbing();
                _ladder.SetParent(player.transform);
                Debug.Log("Лестница найдена");
            }
            else if (isClimbing)
            {
                _ladder.ResetParent(player.transform);
                StopClimbing();
            }

            if (isClimbing)
            {
                Climb(player);
            }
            
        }
        
        protected override void OnActiveEntity(Entity entity)
        {
            /*if (isLadder)
            {
                Debug.Log("Лестница найдена");
            }*/
        }
        
        void StartClimbing()
        {
            _move.enabled = false;
            isClimbing = true;
            _rigidbody.isKinematic = true;
        }

        void StopClimbing()
        {
            _ladder = null;
            isClimbing = false;
            _rigidbody.isKinematic = false;
            _move.enabled = true;
        }

        private void OnCollisionEnter(Collision other)
        {
            _ladder = other.collider.gameObject.GetComponent<Ladder>();
            //isLadder = _ladder != null;
            ladderNormal = other.contacts[0].normal;
        }

        private void OnCollisionExit(Collision other)
        {
            _ladder = other.collider.gameObject.GetComponent<Ladder>();
            //isLadder = _ladder == null;
        }

        void Climb(Player player)
        {
            if (!_ladder)
            {
                //StopClimbing();
                return;
            }
            player.moveDirection = transform.position-ladderNormal;
            player.moveDirection.x *= player.InputHandler.MoveInput.x * climbSpeed;
            player.moveDirection.y *= player.InputHandler.MoveInput.y * climbSpeed;
            player.moveDirection.z *= (player.InputHandler.MoveInput.y*player.InputHandler.MoveInput.x)/2 * climbSpeed;
            player.moveDirection = transform.TransformDirection(player.moveDirection * Time.deltaTime);
            player.transform.Translate(player.moveDirection);
            //new Vector3( , player.moveDirection.y, player.InputHandler.MoveInput.y * climbSpeed);
        }
    }
}

/*public static class ColliderExtensions
{
    public static Vector3 normal(this Collider collider)
    {
        Vector3 pointOnLadder = collider.transform.position; // or any other point on the ladder
        Vector3 closestPoint = collider.ClosestPoint(pointOnLadder);
        Vector3 normal = (pointOnLadder - closestPoint).normalized;
        return normal;
    }
}*/