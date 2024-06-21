using Abilities;
using ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Objects.Entities
{
    public class Player: Entity
    {
        private Skill[] _skills;

        public Skill[] Skills
        {
            get => _skills;
            // set
            // {
            //     
            // }
            
        }
        
        [Inject]
        void Construct(PlayerInfo info)
        {
            Transform transform = gameObject.transform;
            
            transform.position = info.position;
            //transform.rotation = info.transform.rotation;

            _skills = info.Skills;

        }
        
    }
}