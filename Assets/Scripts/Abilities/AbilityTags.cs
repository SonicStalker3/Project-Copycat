using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Abilities
{
    [CreateAssetMenu(menuName = "Create AbilityTags", fileName = "AbilityTags", order = 0)]
    public class AbilityTags : ScriptableObject
    {
        [SerializeField]
        private bool isPassive;
        [SerializeField]
        private bool isPlayerOnly;
        
        
        public bool IsPassive => isPassive;
        public bool IsPlayerOnly => isPlayerOnly;
    }
}