using UnityEngine;

public class EffectDestoroyer : MonoBehaviour
{
    [SerializeField] private float _timeToDestroy = 1;

    private void Start()
    {
        Destroy(gameObject, _timeToDestroy);
    }
}
