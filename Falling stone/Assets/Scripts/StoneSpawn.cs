using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneSpawn : MonoBehaviour
{
    private float difficult;
    private GameObject bigStone;
    private GameObject smallStone;
    public GameObject bigStonePrefab;
    public GameObject smallStonePrefab;
    public float startSpawnTime;
    void Start()
    {
        Invoke("RestartCoroutine", 3f);
    }
    private IEnumerator SpawnerStone()
    {
        difficult = Random.Range(1f, 2f);
        if (difficult >= 1.6f)
        {
         SpawnBigStone();
        }
        else
        {
         SpawnSmallStone();
        }
        yield return new WaitForSeconds(Random.Range(2f, 6f));
        RestartCoroutine();
    }
    private void RestartCoroutine()
    {
        StartCoroutine("SpawnerStone");
    }
    private void SpawnBigStone()
    {
        bigStone = Instantiate(bigStonePrefab, transform.position, transform.rotation) as GameObject;
    }
    private void SpawnSmallStone()
    {
        smallStone = Instantiate(smallStonePrefab, transform.position+ new Vector3(Random.Range(-2.5f,2.5f),0,0), transform.rotation) as GameObject; 
    }
}

