
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using Zenject;

namespace Resources.Bootstrapers
{
    public class BootstrapInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            SceneManager.LoadScene(2);
            //Debug.Log("Hi");

        }
    }
}