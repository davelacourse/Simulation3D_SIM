using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int _hitCount;

    private void Start()
    {
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

    /// <summary>
    /// Affiche le temps et le résultats du niveau qui vient de se terminer
    /// </summary>
    public void CompleteLevel()
    {
        float duration = Time.timeSinceLevelLoad;
        float score = duration + _hitCount;
        Debug.Log("***** Résultats *****");
        Debug.Log($"Arrivée en {duration:F2} sec., pénalités : {_hitCount}");
        Debug.Log($"Résultat final : {score:F2} sec.");
    }
}
