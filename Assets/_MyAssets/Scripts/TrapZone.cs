using UnityEngine;
using System.Collections.Generic;

public class TrapZone : MonoBehaviour
{
    [SerializeField] private List<Rigidbody> _trapObjectRb;
    [SerializeField] private float _dropImpulse = 10f;

    private bool _isTriggered;

    private void OnTriggerEnter(Collider other)
    {
        if(!other.TryGetComponent<Player>(out _) || _isTriggered)
        {
            return;
        }

        _isTriggered = true;
        
        foreach(Rigidbody trap in _trapObjectRb)
        {
            trap.isKinematic = false;
            trap.AddForce(Vector3.down * _dropImpulse, ForceMode.Impulse);
        }


    }
}
