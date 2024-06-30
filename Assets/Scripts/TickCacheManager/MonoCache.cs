using System.Collections.Generic;
using UnityEngine;

namespace TickCacheManager
{
    public class MonoCache : MonoBehaviour
    {
        public static List<MonoCache> allUpdate = new List<MonoCache>(20_000);

        protected void OnEnable()
        {
            allUpdate.Add(this);
        }

        private void OnDisable()
        {
            allUpdate.Remove(this);
        }
        private void OnDestroy()
        {
            allUpdate.Remove(this);
        }

        public void Tick() => OnTick();
        
        protected virtual void OnTick() {}
    }
}