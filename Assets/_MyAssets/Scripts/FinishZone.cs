using UnityEngine;

public class FinishZone : MonoBehaviour
{
    private bool _isReached;

    private void OnTriggerEnter(Collider other)
    {
        if(!other.TryGetComponent<Player>(out _) || _isReached)
        {
            return;
        }

        _isReached = true;

        GameManager.Instance.CompleteLevel();

        gameObject.SetActive(false);
    }
}
