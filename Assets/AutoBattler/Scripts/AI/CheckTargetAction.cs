using AutoBattler.Scripts.AI;
using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "CheckTarget", story: "Check if [Container] has target", category: "Action", id: "5856893fcaa82cf213f272b3b485daac")]
public partial class CheckTargetAction : Action
{
    [SerializeReference] public BlackboardVariable<TargetsContainer> Container;

    protected override Status OnStart()
    {
        if (Container.Value.Targets.Count == 0)
        {
            return Status.Failure;
        }
        else
        {
            return Status.Success;
        }
    }
}

