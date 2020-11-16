using System.Collections;
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
        float deltaTime = Time.DeltaTime;
        float3 targetLocation = new float3(0, 0, 0);
        float speed = .5f;
        float rotationSpeed = .5f;

        var jobHandle = Entities
            .WithName("MoveSystem")
            .ForEach((ref Translation position, ref Rotation rotation, ref TankData tankData) =>
            {
                //position.Value += 0.05f * math.forward(rotation.Value);

                float3 heading = targetLocation - position.Value;
                heading.y = 0;

                quaternion targetRotation = quaternion.LookRotation(heading, math.up());
                rotation.Value = math.slerp(rotation.Value, targetRotation, deltaTime * rotationSpeed);
                //rotation.Value = quaternion.LookRotation(heading, math.up());
                position.Value += deltaTime * speed * math.forward(rotation.Value);

            })
            .Schedule(inputDeps);

        return jobHandle;
    }
}
