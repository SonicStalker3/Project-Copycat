using System;
using Abilities;
using Objects.Entities;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = "Create Save", fileName = "Save", order = 0)]
    [System.Serializable]
    public class Save : ScriptableObject
    {
        //public PlayerInfo playerInstance;
        public Vector3 PlayerPosition;
        //public Skill[] PlayerSkills;
        
        //public WorldInfo world;

        public void OnEnable()
        {
            //if (!playerInstance) UnityEngine.Resources.Load<PlayerInfo>("Save/DefaultPlayerInfo");
            //if (!world) UnityEngine.Resources.Load<WorldInfo>("Save/DefaultWorldInfo");
        }

        public PlayerInfo GetPlayerInfo()
        {
            PlayerInfo p = ScriptableObject.CreateInstance<PlayerInfo>();
            p.position = PlayerPosition;
            //p.Skills = PlayerSkills;
            return p;
        }

        public void d()
        {
            Debug.Log(GetPlayerInfo().position);
            Debug.Log(GetPlayerInfo());
            //Debug.Log(world);
        }
    }
}