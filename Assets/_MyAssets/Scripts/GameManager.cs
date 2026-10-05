using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int _hitCount;

    private void Start()
    {
        _hitCount = 0;
        Debug.Log("Atteignez le burger le plus rapidement sans touché d'obstacle");
    }
    
    /// <summary>
    /// Méthode qui augmente le nombre de collision
    /// </summary>
    public void RegisterHit()
    {
        _hitCount++;
        Debug.Log($"Accrochages : {_hitCount}");
    }
}
