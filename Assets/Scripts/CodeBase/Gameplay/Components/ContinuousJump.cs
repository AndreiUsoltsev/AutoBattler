using UnityEngine;

namespace CodeBase.Gameplay.Components.Movements
{
    [RequireComponent(typeof(Rigidbody))]
    public class ContinuousJump : MonoBehaviour
    {
        public float MinJumpInterval = 3f;
        public float MaxJumpInterval = 7f;
        public float JumpForce = 5f;

        private float _nextJumpTime;
        private Rigidbody _rigidbody;

        private void Start()
            => _rigidbody = GetComponent<Rigidbody>();

        private void OnEnable() 
            => _nextJumpTime = Time.time + Random.Range(MinJumpInterval, MaxJumpInterval);

        private void Update()
        {
            if (Time.time >= _nextJumpTime) 
            {
                _rigidbody.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
                _nextJumpTime = Time.time + Random.Range(MinJumpInterval, MaxJumpInterval);
                Debug.Log("Jump");
            }
        }
    }
}