using System;
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

        [SerializeField, Min(1)] private int MaxHealth = 1;
        public int Health { get; private set; } = 10;

        public delegate void DieEvent();
        public DieEvent OnDied;
        
        protected bool isImmortal;
        [Inject]
        void Construct()
        {
            Debug.Log("Hi, all it's OK");
            Health = MaxHealth;
        }

        private void OnEnable()
        {
            OnDied += Dead;
        }

        private void OnDisable()
        {
            
        }

        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }
        
        public virtual void GetDamage(int damage)
        {
            if (damage < 0)
            {
                throw new ArgumentException("Damage must be > 0");
            }
            if (!isImmortal && Health-damage > 0)
            {
                Health -= damage;
            }
            else
            {
                OnDied.Invoke();
            }
            Debug.Log(Health);
        }
        
        public virtual void GetHeal(int health)
        {
            if (health < 0)
            {
                throw new ArgumentException("heal must be > 0");
            }
            
            if (Health+health < 0)
            {
                Health -= health;
            }
        }

        protected virtual void Dead()
        {
            Debug.Log("Dead");
        }
    }
}
