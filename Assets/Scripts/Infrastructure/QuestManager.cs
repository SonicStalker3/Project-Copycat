using UnityEngine;
using Zenject;

namespace Infrastructure
{
    public class QuestManager: MonoBehaviour
    {
        private Quest[] _completedQuests;
        private Quest[] _unCompletedQuests;
        private Quest _trackedQuest;

        [Inject]
        public void Construct()
        {
            //Debug.Log("Подключено");
        }
    }

    [System.Serializable]
    public class Quest : ScriptableObject
    {
    }
}