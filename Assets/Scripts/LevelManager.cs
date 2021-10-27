using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelManager : MonoBehaviour
{
    public bool Generate;
    public GameObject SimplePrefab;
    public GameObject ExplosionPrefab;
    public GameObject UnbreakablePrefab;
    public GameObject SimpleBoxDamaged;
    public GameObject SimpleBoxDamaged1;
    public GameObject SimpleBoxDamaged2;
    
    private int size = 9;
    private Vector2 startSpawnPosition = new Vector2(-2, 3.75f);
    private readonly Vector2 rowOffset = new Vector2(0.5f, 0);
    private readonly Vector2 columnOffset = new Vector2(0, -0.5f);
    private GameObject boxToSpawn;
    
    private void Start()
    {
        if (Generate)
        {
            OnStartSpawnObjects();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            OnStartSpawnObjects();
        }
    }

    private void OnStartSpawnObjects()
    {
        startSpawnPosition = new Vector2(-2, 3.75f);
        
        for (int i = 0; i < size; i++)
        {
            SpawnRaw();
            startSpawnPosition = new Vector2(-2, startSpawnPosition.y) + columnOffset;
        }
    }

    private void SpawnRaw()
    {
        int patterIndex = Random.Range(0, 6);
        int randomBox = Random.Range(0, 10);

        if (randomBox <= 1)
        {
            boxToSpawn = SimplePrefab;
        }
        else if (randomBox < 7)
        {
            SimpleBoxRandom(); 
        }
        else if (randomBox  > 7 && randomBox < 9)
        {
            boxToSpawn = ExplosionPrefab;
        }
        else if (randomBox == 9)
        {
            boxToSpawn = UnbreakablePrefab;
        }
        

        switch (patterIndex)
        {
            case 0:
                for (int i = 0; i < size; i++)
                {
                    if (i % 2 == 0)
                    {
                        SpawnPatternObject(boxToSpawn);
                        continue;
                    }

                    SpawnPatternObject(SimplePrefab);
                }

                break;
            case 1:
                for (int i = 0; i < size; i++)
                {
                    if (i % 2 == 1)
                    {
                        SpawnPatternObject(boxToSpawn);
                        continue;
                    }

                    SpawnPatternObject(SimplePrefab);
                }

                break;
            case 2:
                for (int i = 0; i < size; i++)
                {
                    if (i == 2 || i == 4 || i == 6)
                    {
                        SpawnPatternObject(boxToSpawn);
                        continue;
                    }

                    SpawnPatternObject(SimplePrefab);
                }

                break;
            case 3:
                for (int i = 0; i < size; i++)
                {
                    if (i == 3 || i == 5)
                    {
                        SpawnPatternObject(boxToSpawn);
                        continue;
                    }

                    SpawnPatternObject(SimplePrefab);
                }

                break;
            case 4:
                for (int i = 0; i < size; i++)
                {
                    if (i == 1 || i == 4 || i == 7)
                    {
                        SpawnPatternObject(boxToSpawn);
                        continue;
                    }

                    SpawnPatternObject(SimplePrefab);
                }

                break;
            case 5:
                for (int i = 0; i < size; i++)
                {
                    if (i == 2 || i == 6)
                    {
                        SpawnPatternObject(boxToSpawn);
                        continue;
                    }

                    SpawnPatternObject(SimplePrefab);
                }

                break;
        }
    }

    private void SpawnPatternObject(GameObject prefab)
    {
        Instantiate(prefab, startSpawnPosition, quaternion.identity);
        startSpawnPosition += rowOffset;
    }

    private void SimpleBoxRandom()
    {
        int randomHealth = Random.Range(1, 4);
        switch (randomHealth)
        {
            case 1:
                boxToSpawn = SimpleBoxDamaged;
                break;
            case 2:
                boxToSpawn = SimpleBoxDamaged1;
                break;
            case 3:
                boxToSpawn = SimpleBoxDamaged2;
                break;
        }
    }
}