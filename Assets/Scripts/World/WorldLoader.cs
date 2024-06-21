using System.Collections;
using System.Collections.Generic;
using Objects.Entities;
using ScriptableObjects;
using UnityEngine;
using Zenject;

public class WorldLoader : MonoBehaviour
{
    [Inject]
    void Construct(Save save)
    {
        Debug.Log("Hi, i am World Loader it's OK");
        //Debug.Log($"PlayerTransform: {}");
        save.d();
    }
}
