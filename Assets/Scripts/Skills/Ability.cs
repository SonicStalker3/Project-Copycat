using DefaultNamespace.InputHandlers;
using Objects.Entities;
using TickCacheManager;
using UnityEngine;
using Zenject;

namespace Skills
{
    public class Ability: MonoCache
    {
        protected InputHandler Input;
        [SerializeField]
        protected Entity Target;

        private bool isPlayer;

        private void Start()
        { 
            Target = GetComponent<Entity>();
        }

        [Inject]
        void Construct(InputHandler inputHander) //PlayerInfo info, InputHandler _inputHander
        {
            Input = inputHander;
        }

        protected virtual void Register(Player player)
        {
            player.AbilitiesList.Add(GetType().Name, this);
        }

        public new void OnEnable()
        {
            base.OnEnable();
            if (Target == null)
            {
                Start();
            }

            isPlayer = (Target as Player) != null;
            //Register();
        }
        
        protected sealed override void OnTick()
        {
            if (isPlayer)
            {
                OnActivePlayer(Target as Player);
            }
            else
            {
                OnActiveEntity(Target);
            }
        }

        protected virtual void OnActivePlayer(Player player)
        {
            throw new System.NotImplementedException();
        }

        protected virtual void OnActiveEntity(Entity entity)
        {
            //throw new System.NotImplementedException();
        }
        
        protected virtual void OnPassive(Entity entity)
        {
            //throw new System.NotImplementedException();
        }
    }
}