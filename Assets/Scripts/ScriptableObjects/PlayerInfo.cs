using System;
using Abilities;
using Objects.Entities;
using UnityEngine;
using UnityEngine.Serialization;

namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = "Create PlayerInfo", fileName = "PlayerInfo", order = 0)]
    [System.Serializable]
    public class PlayerInfo: ScriptableObject
    {
        //public Transform transform;
        public Vector3 position;
        public Skill[] Skills;

        public void OnEnable()
        {
            position = Vector3.zero;
            Skills = Array.Empty<Skill>();
        }

        public void Get(Player player)
        {
            //transform = player.transform;
            position = player.transform.position;
            Skills = player.Skills;
        }
        
    }
}