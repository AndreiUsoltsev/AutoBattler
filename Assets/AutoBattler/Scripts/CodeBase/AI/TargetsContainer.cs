using System.Collections.Generic;
using UnityEngine;

namespace AutoBattler.Scripts.AI
{
    public class TargetsContainer : MonoBehaviour
    {
        public List<GameObject> Targets;
        
        public GameObject GetTarget()
        {
            if (Targets.Count == 0)
                return null;
            
            GameObject target = Targets[0];
            Targets.RemoveAt(0);
            
            return target;
        }
        
        public void AddTarget(GameObject target) 
            => Targets.Add(target);
    }
}
