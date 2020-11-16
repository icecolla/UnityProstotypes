using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using Unity.Jobs;

public class MoveSystem : JobComponentSystem
{
    //protected override JobHandle OnUpdate(JobHandle inputDeps)
    //{
    //    var jobHandle = Entities.WithName("MoveSystem")
    //                    .ForEach((ref Translation position, ref Rotation rotation) =>
    //                    {
    //                        position.Value += .01f * math.up();
    //                    })
    //                    .Schedule(inputDeps);

    //    return jobHandle;
    //}

    //protected override JobHandle OnUpdate(JobHandle inputDeps)
    //{
    //    var jobHandle = Entities.WithName("MoveSystem")
    //                    .ForEach((ref Translation position, ref Rotation rotation, ref NonUniformScale scale) =>
    //                    {
    //                        position.Value += .01f * math.up();
    //                    })
    //                    .Schedule(inputDeps);

    //    return jobHandle;
    //}

    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        var jobHandle = Entities.WithName("MoveSystem")
                        .ForEach((ref Translation position, ref Rotation rotation, ref CubeData cubeData) =>
                        {
                            position.Value += .01f * math.up();
                        })
                        .Schedule(inputDeps);

        return jobHandle;
    }
}
