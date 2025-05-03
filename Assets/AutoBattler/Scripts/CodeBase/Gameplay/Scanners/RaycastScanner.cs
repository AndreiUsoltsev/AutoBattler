using System;
using UnityEngine;

namespace AutoBattler.Scripts.CodeBase.Gameplay.Scanners
{
    public class RaycastScanner : MonoBehaviour
    {
        public event Action<HitInfo> OnHitEvent;
        
        public Transform FirstRaycastPoint, SecondRaycastPoint;
        
        private void Update()
        {
            float distance = Vector3.Distance(FirstRaycastPoint.position, SecondRaycastPoint.position);
            Vector3 direction = (SecondRaycastPoint.position - FirstRaycastPoint.position).normalized;
            
            if (Physics.Raycast(FirstRaycastPoint.position, direction, out RaycastHit hit, distance))
            {
                OnHitEvent?.Invoke(new HitInfo
                {
                    Collider = hit.collider,
                    Point = hit.point,
                    Normal = hit.normal
                });
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(FirstRaycastPoint.position, SecondRaycastPoint.position);
            Gizmos.color = Color.white;
        }
    }
}