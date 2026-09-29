using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [Tooltip("Vitesse de déplacement en unités par secondes")]
    [SerializeField] private float _moveSpeed = 7f;
    [Tooltip("Vitesse de rotation en degrées par secondes")]
    [SerializeField] private float _rotationSpeed = 720f;

    [SerializeField] private GameInput _gameInput;

    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        
        Vector2 inputVector = _gameInput.GetMovementVectorNormalized();

        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);

        // Déplacement par (téléportation) position
        // transform.position += moveDir * Time.deltaTime * _moveSpeed;

        // Déplace par le corps physique de mon joueur par la vitesse
        // _rb.linearVelocity = moveDir * Time.deltaTime * _moveSpeed;

        // Déplace par le corps physique en poussant avec une force
        _rb.AddForce(moveDir * Time.fixedDeltaTime * _moveSpeed);

        // Rotation du joueur

        if (moveDir != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDir);

            transform.rotation = Quaternion.RotateTowards
                (transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
        }
        
    }
}
