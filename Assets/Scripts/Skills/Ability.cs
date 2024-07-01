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

        public bool isPlayer { get; private set; }

        private void Start()
        { 
            Target = GetComponent<Entity>();
            if (isPlayer)
            {
                Register(Target as Player);
            }
        }

        [Inject]
        void Construct(InputHandler inputHander) //PlayerInfo info, InputHandler _inputHander
        {
            Input = inputHander;
        }

        private void Register(Player player)
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