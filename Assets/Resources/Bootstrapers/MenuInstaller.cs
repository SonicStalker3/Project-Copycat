using UnityEngine;
using Zenject;

namespace Resources.Bootstrapers
{
    public class MenuInstaller: MonoInstaller
    {
        public override void InstallBindings()
        {
            Debug.Log("It's Menu");

        }
    }
}