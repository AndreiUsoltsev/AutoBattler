using Codice.CM.Common;
using UnityEngine;

namespace CodeBase.Gameplay.Components.Movements
{
    [RequireComponent(typeof(Rigidbody))]
    public class FollowTarget : MonoBehaviour
    {
        public Transform Target;
        public float Speed = 750f;
        public float StopDistance = 5f;

        private Rigidbody _rigidbody;

        private void Start()
            => _rigidbody = GetComponent<Rigidbody>();


        private void FixedUpdate()
        {
            if(Target == null) 
                return;

            float distance = Vector3.Distance(Target.position, this.transform.position);

            if (distance <= StopDistance)
                return;

            Vector3 direction = (Target.position - transform.position).normalized;

            _rigidbody.AddForce(direction * Speed, ForceMode.Force); 
        }
    }
}