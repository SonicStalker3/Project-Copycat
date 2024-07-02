using System;
using System.Collections.Generic;
using Objects.Entities;

namespace Infrastructure
{
    /// <summary>
    /// NPC's Quest and Dialogs Manager
    /// </summary>
    public static class NpcManager
    {
        private static readonly Dictionary<string, NPC> NpcDictionary = new Dictionary<string, NPC>();
        private static DialogManager _dm;

        public static void RegisterDialogManager(DialogManager dm)
        {
            if (_dm != null)
            {
                throw new Exception($"DialogManager already exists.");
            }

            _dm = dm;
        }

        public static void RegisterNpc(NPC npc, out DialogManager dm)
        {
            if (NpcDictionary.ContainsKey(npc.npcName))
            {
                throw new Exception($"NPC with NpcName '{npc.npcName}' already exists.");
            }
        
            if (_dm is null)
            {
                throw new Exception($"DialogManager unset.");
            }

            dm = _dm;
            NpcDictionary[npc.E_name] = npc;
            //npc.Destroy += (x) => UnRegisterNpc(npc.E_name);
        }

        public static NPC GetNpc(string name)
        {
            if (NpcDictionary.TryGetValue(name, out var npc))
            {
                return npc;
            }
            else
            {
                throw new Exception($"NPC with NpcName '{name}' not found.");
            }
        }

        public static void UnRegisterNpc(string name)
        {
            if (NpcDictionary.TryGetValue(name, out var npc))
            {
                NpcDictionary.Remove(name);
            }
            else
            {
                throw new Exception($"NPC with NpcName '{name}' was not found to delete.");
            }
        }
    }
}