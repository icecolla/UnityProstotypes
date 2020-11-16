using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using Unity.Jobs;

public class SphereMoveSystem : JobComponentSystem
{
    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        var jobHandle = Entities.WithName("SphereMoveSystem")
                        .ForEach((ref Translation position, ref Rotation rotation, ref SphereData sphereData) =>
                        {
                            position.Value -= .01f * math.up();
                        })
                        .Schedule(inputDeps);

        return jobHandle;
    }
}
