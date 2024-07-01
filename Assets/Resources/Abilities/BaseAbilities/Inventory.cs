using System.Collections.Generic;
using Objects.Entities;
using Skills;
using UnityEngine;

namespace Resources.Abilities.BaseAbilities
{
    public class Inventory: Ability
    {
        private Dictionary<string, int> Items;
        [SerializeField] private GameObject InventoryMenu;
        
        void Awake()
        {
            if (isPlayer)
            {
                //InventoryMenu = Resources.Load<GameObject>("");
            }
        }
        protected override void OnActivePlayer(Player player)
        {
            if (player.InputHandler.InventoryBtn)
            {
                Debug.Log("Инвентарь");
            }
        }
        

        public void AddItem(int item)
        {
            
        }

        public void RemoveItems(int item, int count)
        {
            
        }
    }
}