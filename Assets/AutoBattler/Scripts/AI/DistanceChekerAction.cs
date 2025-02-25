using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "DistanceCheker", story: "Check if distance between [first] and [second] objects less then [value]", category: "Action", id: "af2f83fd9f442a49398454480d9c329e")]
public partial class DistanceChekerAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> First;
    [SerializeReference] public BlackboardVariable<GameObject> Second;
    [SerializeReference] public BlackboardVariable<float> Value;

    protected override Status OnUpdate()
    {
        float distance = Vector3.Distance(First.Value.transform.position, Second.Value.transform.position);
        Debug.Log(distance);
        
        if(distance <= Value.Value)
        {
            return Status.Success;
        }
        else
        {
            return Status.Running;
        }
    }
}

