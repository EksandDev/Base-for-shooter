using UnityEngine;

[RequireComponent (typeof(ParticleSystem))]
public class BloodEffect : MonoBehaviour, IInPool
{
    public bool IsActive { get; set; }

    private ParticleSystem _particle;
    private float _timeToDeactivate = 3;

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }

    private void Awake()
    {
        _particle = GetComponent<ParticleSystem>();

        IsActive = false;
    }

    private void OnEnable()
    {
        IsActive = true;
        Invoke(nameof(Deactivate), _timeToDeactivate);
        _particle.Play();
    }

    private void OnDisable()
    {
        IsActive = false;
        CancelInvoke();
        _particle.Stop();
    }
}
