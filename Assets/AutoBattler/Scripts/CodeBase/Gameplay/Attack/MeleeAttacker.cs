using AutoBattler.Scripts.CodeBase.Gameplay.Damage;
using AutoBattler.Scripts.CodeBase.Gameplay.Scanners;
using UnityEngine;

namespace AutoBattler.Scripts.CodeBase.Gameplay.Attack
{
    public class MeleeAttacker : MonoBehaviour
    {
        public RaycastScanner HitScanner;
        
        public void OnAttackStarted()
        {
            HitScanner.enabled = true;
            HitScanner.OnHitEvent += OnHit;
        }

        public void OnAttackEnded()
        {
            HitScanner.enabled = false;
            HitScanner.OnHitEvent -= OnHit;
        }


        private void OnHit(HitInfo hitInfo)
        {
            if (hitInfo.Collider.TryGetComponent<Damageable>(out var damageable))
            {
                DamageInfo damageInfo = new DamageInfo
                {
                    Damage = 1,
                    Source = this.gameObject
                };
                
                damageable.TakeDamage(damageInfo);
            }
        }
    }
}