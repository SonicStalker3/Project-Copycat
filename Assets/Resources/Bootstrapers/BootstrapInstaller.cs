
using DefaultNamespace.InputHandlers;
using TickCacheManager;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using Zenject;

namespace Resources.Bootstrapers
{
    public class BootstrapInstaller : MonoInstaller
    {
        public GameObject inputPrefab;
        public override void InstallBindings()
        {
            LoadingControlSystem();
            LoadingCachedTick();
            
            SceneManager.LoadScene(2);
            //Debug.Log("Hi");

        }
        
        void LoadingControlSystem()
        {
            var input = Container.InstantiatePrefabForComponent<PlayerInput>(inputPrefab, Vector3.zero, Quaternion.identity, transform);
            Container.Bind<PlayerInput>().FromInstance(input).AsSingle().NonLazy();
            Container.Bind<InputHandler>().FromNew().AsSingle().NonLazy();
        }

        void LoadingCachedTick()
        {
            var Tick = Container.InstantiateComponentOnNewGameObject<GlobalUpdate>("MonoCacheManager");
            Container.Bind<GlobalUpdate>().FromInstance(Tick).AsSingle().NonLazy();
        }
    }
}