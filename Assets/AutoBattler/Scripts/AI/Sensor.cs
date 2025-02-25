using System.Collections.Generic;
using UnityEngine;

namespace AutoBattler.Scripts.AI
{
    [RequireComponent(typeof(SphereCollider))]
    public class Sensor : MonoBehaviour
    {
        public float DetectionRadius = 100f;
        public List<string> TargetTags;
        
        private SphereCollider _collider;
        private readonly List<Transform> _detectedTargets = new();

        private void Awake()
        {
            _collider = GetComponent<SphereCollider>();
            _collider.isTrigger = true;
            _collider.radius = DetectionRadius;
            
            Collider[] colliders = Physics.OverlapSphere(transform.position, DetectionRadius);
            foreach (Collider c in colliders)
            {
                if (ProcessTrigger(c))
                    _detectedTargets.Add(c.transform);
            }
        }

        public Transform GetClosestTarget(string otherTag)
        {
            Debug.Log($"GetClosestTarget: {otherTag} {_detectedTargets.Count}");
            if (_detectedTargets.Count == 0)
                return null;

            Transform closestTarget = null;
            float closestDistanceSqr = Mathf.Infinity;
            
            foreach (Transform potentialTransform in _detectedTargets)
            {
                if (potentialTransform.CompareTag(otherTag))
                {
                    float distanceSqr = (potentialTransform.position - transform.position).sqrMagnitude;
                    if (distanceSqr < closestDistanceSqr)
                    {
                        closestTarget = potentialTransform;
                        closestDistanceSqr = distanceSqr;
                    }  
                }
            }

            return closestTarget;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (ProcessTrigger(other))
                _detectedTargets.Add(other.transform);
        }

        private void OnTriggerExit(Collider other)
        {
            if(ProcessTrigger(other))
                _detectedTargets.Remove(other.transform);
        }

        private bool ProcessTrigger(Collider other)
        {
            if (other.CompareTag("Untagged"))
                return false;

            foreach (string t in TargetTags)
            {
                Debug.Log($"{other.transform.name} {other.tag} {t} {other.CompareTag(t)}");
                if (other.CompareTag(t))
                    return true;
            }
            
            return false;
        }
    }
}