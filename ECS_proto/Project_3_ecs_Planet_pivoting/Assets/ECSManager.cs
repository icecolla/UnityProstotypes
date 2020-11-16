using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using Unity.Jobs;

public class ECSManager : MonoBehaviour
{
    EntityManager entityManager;

    public GameObject planetObjectPrefab;
    public int numPlanets = 50;

    private void Start()
    {
        entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
        var settings = GameObjectConversionSettings.FromWorld(World.DefaultGameObjectInjectionWorld, null);
        var prefab = GameObjectConversionUtility.ConvertGameObjectHierarchy(planetObjectPrefab, settings);

        for (int i = 0; i < numPlanets; i++)
        {
            var instance = entityManager.Instantiate(prefab);
            float x = Mathf.Sin(i) * UnityEngine.Random.Range(-50, 50);
            float y = UnityEngine.Random.Range(-5, 5);
            float z = Mathf.Cos(i) * UnityEngine.Random.Range(-50, 50);
            var position = transform.TransformPoint(new float3(x, y, z));
            entityManager.SetComponentData(instance, new Translation { Value = position });

            var q = Quaternion.Euler(new Vector3(0, 45, 0));
            entityManager.SetComponentData(instance, new Rotation { Value = new quaternion(q.x, q.y, q.z, q.w) });

            var scale = new float3(UnityEngine.Random.Range(.5f, .15f),
                                   UnityEngine.Random.Range(.5f, .10f),
                                   UnityEngine.Random.Range(.5f, .15f));
            scale *= UnityEngine.Random.Range(1, 2);
            entityManager.AddComponent(instance, ComponentType.ReadWrite<NonUniformScale>());
            entityManager.SetComponentData(instance, new NonUniformScale { Value = scale });
        }
    }
}
