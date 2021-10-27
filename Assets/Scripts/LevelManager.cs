using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelManager : MonoBehaviour
{
    public List<CoreBox> Boxes = new List<CoreBox>(); 
    
    public int RawCount;
    public int RawSizeInBlocks;
    public bool Generate;
    public GameObject SimplePrefab;
    public GameObject ExplosionPrefab;
    public GameObject UnbreakablePrefab;
    public GameObject SimpleBoxDamaged;
    public GameObject SimpleBoxDamaged1;
    public GameObject SimpleBoxDamaged2;
    
   
    private readonly Vector2 rowOffset = new Vector2(0.5f, 0);
    private readonly Vector2 columnOffset = new Vector2(0, -0.5f);
    private Vector2 spawnPosition = new Vector2(-2, 3.75f);
    private Vector2 rawSpawnPosition = new Vector2(-2, 3.75f);
    private GameObject boxToSpawn;
    
    private int generatedBoxesCount;

    private void OnEnable()
    {
        CoreBox.OnBoxDestroy += OnOnBoxDestroy;
    }

    private void OnOnBoxDestroy(CoreBox obj)
    {
        Boxes.Remove(obj);

        if (Boxes.Count <= generatedBoxesCount - RawSizeInBlocks)
        {
            foreach (var box in Boxes)
            {
                box.Move();
            }

            spawnPosition = rawSpawnPosition;
            SpawnRaw(true);
        }
    }

    private void Start()
    {
        if (Generate)
        {
            OnStartSpawnObjects();
        }

        generatedBoxesCount = Boxes.Count;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            foreach (var box in Boxes)
            {
                box.Move();
            }
        }
    }

    private void OnStartSpawnObjects()
    {
        spawnPosition = new Vector2(-2, 3.75f);
        
        for (int i = 0; i < RawCount; i++)
        {
            SpawnRaw(true);
        }
    }

    private void SpawnRaw(bool isStart)
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
                for (int i = 0; i < RawSizeInBlocks; i++)
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
                for (int i = 0; i < RawSizeInBlocks; i++)
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
                for (int i = 0; i < RawSizeInBlocks; i++)
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
                for (int i = 0; i < RawSizeInBlocks; i++)
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
                for (int i = 0; i < RawSizeInBlocks; i++)
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
                for (int i = 0; i < RawSizeInBlocks; i++)
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
        
        spawnPosition = new Vector2(-2, spawnPosition.y) + columnOffset;
        generatedBoxesCount = Boxes.Count;
    }

    private void SpawnPatternObject(GameObject prefab)
    {
        GameObject box = Instantiate(prefab, spawnPosition, quaternion.identity);
        spawnPosition += rowOffset;
            
        Boxes.Add(box.GetComponent<CoreBox>());
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