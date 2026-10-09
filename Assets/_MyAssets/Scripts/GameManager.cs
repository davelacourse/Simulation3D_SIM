using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    private readonly List<LevelResult> _resultsList = new List<LevelResult>();
    private int _penaltyTime;

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        Debug.Log("Atteignez le burger le plus rapidement sans touché d'obstacle");
    }
    
    /// <summary>
    /// Méthode qui augmente le nombre de collision
    /// </summary>
    /// <param name="p_penaltySeconds">Pénalité en secondes de l'obstacle</param>
    public void RegisterHit(int p_penaltySeconds)
    {
        _penaltyTime += p_penaltySeconds;
        // Debug.Log($"Accrochages : {_penaltyTime}");
    }

    /// <summary>
    /// Affiche le temps et le résultats du niveau qui vient de se terminer
    /// </summary>
    public void CompleteLevel()
    {
        int levelIndex = SceneManager.GetActiveScene().buildIndex;
        float duration = Time.timeSinceLevelLoad;
        _resultsList.Add(new LevelResult(levelIndex, duration, _penaltyTime));
        _penaltyTime = 0; // remet à 0 pour le prochain niveau


        int nextIndex = levelIndex + 1;
        if (nextIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextIndex);
        }
        else
        {
            ShowSummary();
        }
    }

    private void ShowSummary()
    {
        float total = 0;
        
        // Afficher tous les LevelResult de la liste
        foreach(LevelResult levelResult in _resultsList)
        {
            float score = levelResult.Duration + levelResult.Penalty;
            total += score;

            Debug.Log($"Niveau {levelResult.LevelIndex + 1} : {levelResult.Duration:F2} sec.");
            Debug.Log($"Pénalité : {levelResult.Penalty}");
            Debug.Log($"Résultat : {score:F2} sec.");
            Debug.Log("-------------------------------");
        }


        Debug.Log($"Résultat final {total:F2} sec.");


        Player player = FindAnyObjectByType<Player>();
        Destroy(player.gameObject);
    }
}
