using Infrastructure;
using Objects.Entities;
using Skills;
using Zenject;

namespace Resources.Abilities.BaseAbilities
{
    public class Dialog: Ability
    {
        private DialogManager _dialogManager;
        [Inject]
        void Construct(DialogManager dialogManager)
        {
            _dialogManager = dialogManager;
        }
        
        protected override void OnActivePlayer(Player player)
        {
            
        }
    }
}