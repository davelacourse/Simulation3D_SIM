using UnityEngine;

public class Player : MonoBehaviour
{
    [Tooltip("Vitesse de déplacement en unités par secondes")]
    [SerializeField] private float _moveSpeed = 7f;
    [Tooltip("Vitesse de rotation en degrées par secondes")]
    [SerializeField] private float _rotationSpeed = 720f;
    [Tooltip("Multiplie la gravité appliqué sur le joueur")]
    [SerializeField] private float _gravityScale = 2.5f;

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

        Vector3 velocity = moveDir * _moveSpeed;
        velocity.y = _rb.linearVelocity.y;
        _rb.linearVelocity = velocity;

        //Applique la gravité supplémentaire
        Vector3 extraGravity = Physics.gravity * (_gravityScale - 1f);
        _rb.AddForce(extraGravity, ForceMode.Acceleration);

        // Rotation du joueur

        if (moveDir != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDir);

            _rb.MoveRotation(Quaternion.RotateTowards(_rb.rotation, 
                targetRotation, _rotationSpeed * Time.fixedDeltaTime));
        }
        
    }
}
