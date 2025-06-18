using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class PlayerCollector : MonoBehaviour
{
    private int score = 0;

    [SerializeField] private Text scoreText;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private PelletSpawner pelletSpawner;

    [Header("Restart ile birlikte yeniden spawn olacak prefablar")]
    [SerializeField] private List<GameObject> additionalPrefabs;
    [SerializeField] private List<Transform> additionalSpawnPoints;

    private void Start()
    {
        UpdateScoreUI();
        winPanel.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pellet"))
        {
            Destroy(other.gameObject);
            score++;
            UpdateScoreUI();

            if (score >= 10)
            {
                winPanel.SetActive(true);
            }
        }
    }

    private void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score;
    }

    public void RestartGame()
    {
        
        score = 0;
        UpdateScoreUI();

        
        winPanel.SetActive(false);

        
        GameObject[] pellets = GameObject.FindGameObjectsWithTag("Pellet");
        foreach (GameObject pellet in pellets)
        {
            Destroy(pellet);
        }

        
        pelletSpawner.SpawnPellets();

        
        for (int i = 0; i < additionalPrefabs.Count; i++)
        {
            if (additionalPrefabs[i] != null && additionalSpawnPoints.Count > i)
            {
                Instantiate(additionalPrefabs[i], additionalSpawnPoints[i].position, Quaternion.identity);
            }
        }
    }
}
