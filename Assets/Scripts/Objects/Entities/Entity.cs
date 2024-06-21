using Interfaces;
using UnityEngine;
using Zenject;

namespace Objects.Entities
{
    public class Entity : Object, IEntity
    {
        public string E_name;
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

        public void Move()
        {
            throw new System.NotImplementedException();
        }

        public void GetDamage(int damage)
        {
            throw new System.NotImplementedException();
        }
    }
}
