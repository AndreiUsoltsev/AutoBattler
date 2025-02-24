using UnityEngine;

namespace CodeBase.Gameplay.Components.Movements
{
    [RequireComponent(typeof(Rigidbody))]
    public class RotateTowardsTarget : MonoBehaviour
    {
        public Transform Target;
        public float RotationSpeed = 5f; 

        private Rigidbody _rigidbody;

        private void Start() 
            => _rigidbody = GetComponent<Rigidbody>();

        private void FixedUpdate()
        {
            if (Target != null)
            {
                Vector3 direction = Target.position - transform.position;

                Quaternion lookRotation = Quaternion.LookRotation(direction, Vector3.up);
                Quaternion targetRotation = Quaternion.FromToRotation(this.transform.up, Vector3.up);

                _rigidbody.MoveRotation(Quaternion.Slerp(transform.rotation, targetRotation * lookRotation, RotationSpeed * Time.fixedDeltaTime));
            }
        }
    }
}