using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using Unity.Rendering;
using Unity.Jobs;

public class CreateCapsuleSystem : JobComponentSystem
{
    protected override void OnCreate()
    {
        base.OnCreate();

        for (int i = 0; i < 100; i++)
        {

            var instance = EntityManager.CreateEntity(
                           ComponentType.ReadOnly<LocalToWorld>(),
                           ComponentType.ReadWrite<Translation>(),
                           ComponentType.ReadWrite<Rotation>(),
                           ComponentType.ReadWrite<NonUniformScale>(),
                           ComponentType.ReadOnly<RenderBounds>(),
                           ComponentType.ReadOnly<RenderMesh>()
                           );

            float3 position = new float3(UnityEngine.Random.Range(-100, 100), 0, UnityEngine.Random.Range(-100, 100));
            float scale = UnityEngine.Random.Range(1, 10);
            EntityManager.SetComponentData(instance, new LocalToWorld
            {
                //Value = new float4x4(rotation: quaternion.identity, translation: new float3(0, 0, 0))
                Value = new float4x4(rotation: quaternion.identity, translation: position)

            });
            EntityManager.SetComponentData(instance, new Translation { Value = position});
            EntityManager.SetComponentData(instance, new Rotation { Value = new quaternion(0, 0, 0, 0) });

            //EntityManager.SetComponentData(instance, new NonUniformScale { Value = new float3(10, 10, 10) });
            EntityManager.SetComponentData(instance, new NonUniformScale { Value = new float3(scale, scale, scale) });


            var rHolder = Resources.Load<GameObject>("ResourceHolder").GetComponent<ResourcesHolder>();

            EntityManager.SetSharedComponentData(instance,
                new RenderMesh
                {
                    mesh = rHolder.theMesh,
                    material = rHolder.theMaterial
                });
        }
    }

    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        return inputDeps;
    }
}
