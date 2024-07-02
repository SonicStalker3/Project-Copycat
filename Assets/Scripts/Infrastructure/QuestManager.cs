using UnityEngine;

namespace Infrastructure
{
    public class QuestManager: MonoBehaviour
    {
        private Quest[] _completedQuests;
        private Quest[] _unCompletedQuests;
        private Quest _trackedQuest;
    }

    [System.Serializable]
    public class Quest : ScriptableObject
    {
    }
}