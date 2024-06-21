using Interfaces.Patterns;
using UnityEngine;

namespace DefaultNamespace
{
    public class Spawner : MonoBehaviour
    {
        private IFactory mobs;
        private IPool mobsPool;

        public void Spawn()
        {
            mobsPool.AddObject(mobs.Create(null));
        }

        public void Despawn()
        {
            
        }
    }
}