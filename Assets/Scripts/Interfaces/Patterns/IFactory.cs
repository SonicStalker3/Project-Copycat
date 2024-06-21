using UnityEngine;

namespace Interfaces.Patterns
{
    public interface IFactory
    {
        public GameObject Create(IInfo data);
    }
}