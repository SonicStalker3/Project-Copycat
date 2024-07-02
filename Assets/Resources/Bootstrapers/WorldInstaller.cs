using Infrastructure;
using Objects.Entities;
using ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Resources.Bootstrapers
{
    public class WorldInstaller : MonoInstaller
    {
        public Transform startPoint;
        public GameObject playerPrefab;
        [SerializeField]
        private Save _save; 
        private PlayerInfo _playerInfo;
        private GameObject root;

        public override void InstallBindings()
        {
            LoadingSave();
            LoadingLevel();
        
//            _save.PlayerPosition = new Vector3(100, 100, 5);
            //SaveManager.Save(_save);
            //WorldLoader world = Container.InstantiateComponent<WorldLoader>(gameObject);
        }
        
        void LoadingLevel()
        {
            Player player = Container.InstantiatePrefabForComponent<Player>(playerPrefab, startPoint.position, Quaternion.identity, null);
            Container.Bind<Player>()
                .FromInstance(player)
                .AsSingle();
        }

        void LoadingSave()
        {
            /*_save = SaveManager.Load();
            if (!_save)
            {
                Debug.Log("Load");
                Debug.Log(UnityEngine.Resources.Load<GameObject>("Save/first"));
                _save = UnityEngine.Resources.Load<Save>("Save/DefaultSave");
                //SaveManager.LoadDef(_save);
                SaveManager.Save(_save);
            }

            _playerInfo = _save.GetPlayerInfo();
        
            Container.Bind<Save>()
                .FromInstance(_save)
                .AsSingle();
        
            Container.Bind<PlayerInfo>()
                .FromInstance(_playerInfo)
                .AsSingle();*/
            
            Container.Bind<QuestManager>().
                FromNewComponentOnNewGameObject().
                WithGameObjectName("NPC_Controller").
                UnderTransformGroup("Infrasructure").
                AsSingle().
                NonLazy();
            
            /*Container.Bind<QuestManager>().
                FromNewComponentOnNewGameObject().
                WithGameObjectName("NPC_Controller").
                UnderTransformGroup("Infrasructure").
                AsSingle().
                NonLazy();*/
            
            //TODO: Fix DialogManager
            /*Container.Bind<DialogManager>().
                FromNew().
                AsSingle();*/
        }
    }
}