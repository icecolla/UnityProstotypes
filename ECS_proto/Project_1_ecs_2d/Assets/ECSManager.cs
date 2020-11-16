using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

public class ECSManager : MonoBehaviour
{
    EntityManager manager;

    public GameObject objectPrefab;
    public int numObject = 1000;

    private void Start()
    {
        manager = World.DefaultGameObjectInjectionWorld.EntityManager;
        var settings = GameObjectConversionSettings.FromWorld(World.DefaultGameObjectInjectionWorld, null);
        var prefab = GameObjectConversionUtility.ConvertGameObjectHierarchy(objectPrefab, settings);

        for (int i = 0; i < numObject; i++)
        {
            var instance = manager.Instantiate(prefab);
            var position = transform.TransformPoint(new float3(UnityEngine.Random.Range(-50, 50), UnityEngine.Random.Range(0, 100), UnityEngine.Random.Range(-50, 50)));
            manager.SetComponentData(instance, new Translation { Value = position });
            manager.SetComponentData(instance, new Rotation { Value = new quaternion(0, 0, 0, 0) });
        }
    }
}
