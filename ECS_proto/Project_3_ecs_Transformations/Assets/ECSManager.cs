using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

public class ECSManager : MonoBehaviour
{
    EntityManager entityManager;

    public GameObject tankPrefab;
    public int numTanks = 100;

    private void Start()
    {
        entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;

        var settings = GameObjectConversionSettings.FromWorld(World.DefaultGameObjectInjectionWorld, null);
        var prefab = GameObjectConversionUtility.ConvertGameObjectHierarchy(tankPrefab, settings);

        for (int i = 0; i < numTanks; i++)
        {
            var instance = entityManager.Instantiate(prefab);
            float x = UnityEngine.Random.Range(-50, 50);
            float z = UnityEngine.Random.Range(-50, 50);
            var position = transform.TransformPoint(new float3(x, 0, z));
            entityManager.SetComponentData(instance, new Translation { Value = position });

            var q = Quaternion.Euler(new Vector3(0, 45, 0));
            entityManager.SetComponentData(instance, new Rotation { Value = new quaternion(q.x, q.y, q.z, q.w) });
        }
    }
}
