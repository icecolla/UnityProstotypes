﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using Unity.Jobs;

public class MoveSystem : JobComponentSystem
{
    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        var jobHandle = Entities.WithName("MoveSystem").
                        ForEach((ref Translation position, ref Rotation rotation) =>
                        {
                            //position.Value += 0.1f * math.forward(rotation.Value);
                            position.Value.y += 0.1f;

                            if (position.Value.y > 100)
                                position.Value.y = 0;
                        })
                        .Schedule(inputDeps);
        return jobHandle;
    }
}
