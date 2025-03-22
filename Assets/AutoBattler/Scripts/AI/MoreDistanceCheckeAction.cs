using System;
using Unity.Behavior;
using Unity.Properties;
using UnityEngine;
using Action = Unity.Behavior.Action;

namespace AutoBattler.Scripts.AI
{
    [Serializable, GeneratePropertyBag]
    [NodeDescription(name: "MoreDistanceChecke", story: "Check if distance between [first] and [second] objects more then [value]", category: "Action", id: "0f3e48edfcb7170886978b8352323952")]
    public partial class MoreDistanceCheckeAction : Action
    {
        [SerializeReference] public BlackboardVariable<GameObject> First;
        [SerializeReference] public BlackboardVariable<GameObject> Second;
        [SerializeReference] public BlackboardVariable<float> Value;

        protected override Status OnStart()
        {
            return Status.Running;
        }

        protected override Status OnUpdate()
        {
            return Status.Success;
        }

        protected override void OnEnd()
        {
        }
    }
}

