using UnityEngine;

namespace TickCacheManager
{
    public class GlobalUpdate : MonoBehaviour
    {
        private void Update()
        {
            Debug.Log(MonoCache.allUpdate.Count);
            for (int i = 0; i < MonoCache.allUpdate.Count; i++) MonoCache.allUpdate[i].Tick();
        }
    }
}