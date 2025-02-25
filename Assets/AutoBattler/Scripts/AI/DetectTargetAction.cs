using System;
using Unity.Behavior;
using Unity.Properties;
using UnityEngine;
using Action = Unity.Behavior.Action;

namespace AutoBattler.Scripts.AI
{
    [Serializable, GeneratePropertyBag]
    [NodeDescription(name: "DetectTarget", story: "[Agent] detects [Target] with [Tag] by [Sensor]", category: "Action", id: "588e1137595e8c143485cd04feaa9c4b")]
    public partial class DetectTargetAction : Action
    {
    [SerializeReference] public BlackboardVariable<GameObject> Agent;
    [SerializeReference] public BlackboardVariable<GameObject> Target;
    [SerializeReference] public BlackboardVariable<string> Tag;
    [SerializeReference] public BlackboardVariable<Sensor> Sensor;
    
        protected override Status OnStart()
        {
            return Status.Running;
        }

        protected override Status OnUpdate()
        {
            Transform target = Sensor.Value.GetClosestTarget(Tag);
            Debug.Log(target, target);
            if (target == null)
                return Status.Running;
            
            Target.Value = target.gameObject;
            return Status.Success;
        }

        protected override void OnEnd()
        {
        }
    }
}

