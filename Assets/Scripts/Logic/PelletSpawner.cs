using UnityEngine;
using Random = UnityEngine.Random;

public class PelletSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _pelletPrefab;

    [Range(1, 50)]
    [field: SerializeField] public int NumberToSpawn;

    [Header("3D Spawn Alaný Boyutu")]
    [SerializeField] private Vector3 arenaSize = new Vector3(10, 1, 10); // X, Y, Z

    private Vector3 arenaExtents;
    private Vector3[] pelletPositions;
    private float _detectionRadius = 1f;

    private void Start()
    {
        arenaExtents = arenaSize * 0.5f;
        SpawnPellets();
    }

    public void SpawnPellets()
    {
        pelletPositions = new Vector3[NumberToSpawn];

        for (int i = 0; i < NumberToSpawn; i++)
        {
            int safety = 0;
            while (pelletPositions[i] == Vector3.zero && safety < 100)
            {
                float x = Random.Range(-arenaExtents.x, arenaExtents.x);
                float y = Random.Range(-arenaExtents.y, arenaExtents.y);
                float z = Random.Range(-arenaExtents.z, arenaExtents.z);

                Vector3 spawnPos = new Vector3(x, y, z);

                if (NearAnotherPellet(spawnPos, i))
                {
                    safety++;
                    continue;
                }

                pelletPositions[i] = spawnPos;
                Instantiate(_pelletPrefab, spawnPos, Quaternion.identity);
            }
        }
    }

    private bool NearAnotherPellet(Vector3 pos, int currentIndex)
    {
        for (int i = 0; i < currentIndex; i++)
        {
            if ((pelletPositions[i] - pos).magnitude < _detectionRadius)
                return true;
        }
        return false;
    }
}
