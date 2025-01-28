using UnityEngine;

public class ParticleAnimation : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;

    private void OnEnable()
    {
        ActionManager.OnPlayerDeath += StopParticle;
        ActionManager.OnPlayerRevive += StartParicle;
    }

    private void OnDisable()
    {
        ActionManager.OnPlayerDeath -= StopParticle;
        ActionManager.OnPlayerRevive -= StartParicle;

    }

    private void StopParticle()
    {
        if (_particleSystem != null)
        {
            var emission = _particleSystem.emission;
            emission.enabled = false;
        }
    }

    private void StartParicle()
    {
        if (_particleSystem != null)
        {
            var emission = _particleSystem.emission;
            emission.enabled = true;
        }
    }
}
