using Interfaces;
using UnityEngine.Serialization;

namespace Objects.Entities
{
    public class NPC: Entity, ISpeakable
    {
        public string npcName;
    
        public void StartDialog()
        {
            throw new System.NotImplementedException();
        }

        public void DialogSound()
        {
            throw new System.NotImplementedException();
        }
    }
}