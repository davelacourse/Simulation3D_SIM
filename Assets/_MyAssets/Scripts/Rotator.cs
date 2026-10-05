using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Rotator : MonoBehaviour
{
    [Tooltip("Vitesse de rotation autour de Y, en degrés par seconde")]
    [SerializeField] private float _degreesPerSeconds = 90f;

    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float angle = _degreesPerSeconds * Time.fixedDeltaTime;
        Quaternion step = Quaternion.Euler(0, angle, 0);
        _rb.MoveRotation(_rb.rotation * step);
    }


}
