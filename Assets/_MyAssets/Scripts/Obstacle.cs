using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [Tooltip("Couleur de l'obstacle une fois touché")]
    [SerializeField] private Material _hitMaterial;

    [SerializeField] private int _penaltySeconds = 1;

    private Renderer _renderer;
    private bool _wasHit;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.TryGetComponent<Player>(out _) || _wasHit)
        {
            return;
        }

        _wasHit = true;
        _renderer.material = _hitMaterial;
        // Augmenter le hitcount dans le gameManager
        GameManager.Instance.RegisterHit(_penaltySeconds);

    }
}
