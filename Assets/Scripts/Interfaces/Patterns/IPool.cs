using UnityEngine;

namespace Interfaces.Patterns
{
    public interface IPool
    {
        public void AddObject(GameObject g);
        
        public void Activate(int id);
        public void ActivateAll();
        
        public void DeactivateAll();
        public void Deactivate(int id);
    }
}