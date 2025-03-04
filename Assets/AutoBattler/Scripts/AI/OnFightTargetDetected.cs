using System;
using Unity.Behavior;
using UnityEngine;
using Unity.Properties;

#if UNITY_EDITOR
[CreateAssetMenu(menuName = "Behavior/Event Channels/OnFightTargetDetected")]
#endif
[Serializable, GeneratePropertyBag]
[EventChannelDescription(name: "OnFightTargetDetected", message: "[FightTarget] has been detected", category: "Events", id: "7ecc6ae849755975b804751daed6f963")]
public partial class OnFightTargetDetected : EventChannelBase
{
    public delegate void OnFightTargetDetectedEventHandler(GameObject FightTarget);
    public event OnFightTargetDetectedEventHandler Event; 

    public void SendEventMessage(GameObject FightTarget)
    {
        Event?.Invoke(FightTarget);
    }

    public override void SendEventMessage(BlackboardVariable[] messageData)
    {
        BlackboardVariable<GameObject> FightTargetBlackboardVariable = messageData[0] as BlackboardVariable<GameObject>;
        var FightTarget = FightTargetBlackboardVariable != null ? FightTargetBlackboardVariable.Value : default(GameObject);

        Event?.Invoke(FightTarget);
    }

    public override Delegate CreateEventHandler(BlackboardVariable[] vars, System.Action callback)
    {
        OnFightTargetDetectedEventHandler del = (FightTarget) =>
        {
            BlackboardVariable<GameObject> var0 = vars[0] as BlackboardVariable<GameObject>;
            if(var0 != null)
                var0.Value = FightTarget;

            callback();
        };
        return del;
    }

    public override void RegisterListener(Delegate del)
    {
        Event += del as OnFightTargetDetectedEventHandler;
    }

    public override void UnregisterListener(Delegate del)
    {
        Event -= del as OnFightTargetDetectedEventHandler;
    }
}

