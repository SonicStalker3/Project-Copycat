using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = "Create WorldInfo", fileName = "WorldInfo", order = 0)]
    [System.Serializable]
    public class WorldInfo : ScriptableObject
    {
        public void OnEnable()
        {
        }
    }
}