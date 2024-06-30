using System.Collections.Generic;
using Interfaces;
using Skills;
using UnityEngine;
using Zenject;

namespace Objects.Entities
{
    public class Entity : Object, IEntity
    {
        public Dictionary<string, Ability> AbilitiesList =  new Dictionary<string, Ability>();
        [Inject]
        void Construct()
        {
            Debug.Log("Hi, all it's OK");
        }
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public virtual void Move()
        {
            throw new System.NotImplementedException();
        }

        public virtual void GetDamage(int damage)
        {
            throw new System.NotImplementedException();
        }
    }
}
