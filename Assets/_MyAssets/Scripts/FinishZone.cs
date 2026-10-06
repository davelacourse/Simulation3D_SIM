using UnityEngine;

public class FinishZone : MonoBehaviour
{
    private GameManager _gameManager;

    private bool _isReached;

    private void Start()
    {
        _gameManager = FindAnyObjectByType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!other.TryGetComponent<Player>(out _) || _isReached)
        {
            return;
        }

        _isReached = true;

        _gameManager.CompleteLevel();

        gameObject.SetActive(false);
    }
}
