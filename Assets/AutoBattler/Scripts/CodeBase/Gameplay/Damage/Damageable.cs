using UnityEngine;
using UnityEngine.Events;

namespace AutoBattler.Scripts.CodeBase.Gameplay.Damage
{
    public class Damageable : MonoBehaviour
    {
        public UnityEvent<DamageInfo> OnDamageTakenEvent;
        
        public void TakeDamage(DamageInfo damage)
        {
            Debug.Log($"Damage taken: {damage.Damage} from {damage.Source.name}", this);
            OnDamageTakenEvent.Invoke(damage);
        }
    }
}
