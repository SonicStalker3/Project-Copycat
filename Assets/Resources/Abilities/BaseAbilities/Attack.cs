using Objects.Entities;
using Skills;
using UnityEngine;

namespace Resources.Abilities.BaseAbilities
{
    public class Attack : Ability
    {
        [SerializeField] private Camera playerCamera;
        [SerializeField] private int damage = 5;
        [Range(1, 20f)] public float maxAttackDistance = 5;

        void Start()
        {
            playerCamera = GetComponentInChildren<Camera>();
        }

        protected override void OnActivePlayer(Player player)
        {
            if (player.InputHandler.AttackBtn)
            {
                Ray ray = playerCamera!.ViewportPointToRay(new Vector3(0.5f, 0.5f));
                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    if (hit.distance <= maxAttackDistance)
                    {
                        hit.collider.TryGetComponent(out Entity entity);
                        if (entity)
                        {
                            if(!entity.CompareTag("NPC")) entity.GetDamage(damage);
                            else Debug.Log("It's Alias. Don't Damage");
                        }
                        Debug.Log(hit.transform.gameObject.name);
                    }
                }
            }
        }
        //protected override void OnActiveEntity(Entity entity) => Debug.Log("Entity Jumped");

        private void OnValidate()
        {
            maxAttackDistance = Mathf.Clamp(maxAttackDistance, 1, 20);
        }
    }
}