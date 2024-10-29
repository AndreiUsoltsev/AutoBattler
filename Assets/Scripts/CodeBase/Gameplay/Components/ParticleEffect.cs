using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class ParticleEffect : MonoBehaviour
{
    public ParticleSystem ParticleSystem;

    private void OnEnable()
    {
        if(ParticleSystem == null)
            ParticleSystem = this.GetComponent<ParticleSystem>();
    }
}
