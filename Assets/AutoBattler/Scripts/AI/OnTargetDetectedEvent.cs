using System;
using Unity.Behavior;
using UnityEngine;
using Unity.Properties;

#if UNITY_EDITOR
[CreateAssetMenu(menuName = "Behavior/Event Channels/OnTargetDetectedEvent")]
#endif
[Serializable, GeneratePropertyBag]
[EventChannelDescription(name: "OnTargetDetectedEvent", message: "[Agent] has detected [Target]", category: "Events", id: "76244d5fa96915b858823650c169bc24")]
public partial class OnTargetDetectedEvent : EventChannelBase
{
    public delegate void OnTargetDetectedEventEventHandler(GameObject Agent, GameObject Target);
    public event OnTargetDetectedEventEventHandler Event; 

    public void SendEventMessage(GameObject Agent, GameObject Target)
    {
        Event?.Invoke(Agent, Target);
    }

    public override void SendEventMessage(BlackboardVariable[] messageData)
    {
        BlackboardVariable<GameObject> AgentBlackboardVariable = messageData[0] as BlackboardVariable<GameObject>;
        var Agent = AgentBlackboardVariable != null ? AgentBlackboardVariable.Value : default(GameObject);

        BlackboardVariable<GameObject> TargetBlackboardVariable = messageData[1] as BlackboardVariable<GameObject>;
        var Target = TargetBlackboardVariable != null ? TargetBlackboardVariable.Value : default(GameObject);

        Event?.Invoke(Agent, Target);
    }

    public override Delegate CreateEventHandler(BlackboardVariable[] vars, System.Action callback)
    {
        OnTargetDetectedEventEventHandler del = (Agent, Target) =>
        {
            BlackboardVariable<GameObject> var0 = vars[0] as BlackboardVariable<GameObject>;
            if(var0 != null)
                var0.Value = Agent;

            BlackboardVariable<GameObject> var1 = vars[1] as BlackboardVariable<GameObject>;
            if(var1 != null)
                var1.Value = Target;

            callback();
        };
        return del;
    }

    public override void RegisterListener(Delegate del)
    {
        Event += del as OnTargetDetectedEventEventHandler;
    }

    public override void UnregisterListener(Delegate del)
    {
        Event -= del as OnTargetDetectedEventEventHandler;
    }
}

