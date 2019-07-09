using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//touch classs
public class SpawnerController : MonoBehaviour
{
    [SerializeField]
    public GameObject[] enemies;
    private Vector2 spawnPosition;
    public float SpawnWait, MaxSpawnWait, MinSpawnWait;
    public int StartWait;

    int RandEnemy;

    // Start is called before the first frame update
    void Start()
    {
        StartWait = 10;
        MaxSpawnWait = 20;
        MinSpawnWait = 8;
        spawnPosition.x = 10;
        spawnPosition.y = 10;
        spawnPosition.x = this.transform.position.x + 10;
        spawnPosition.y = this.transform.position.y + 10;
        StartCoroutine(Spawner());
    }

    // Update is called once per frame
    void Update()
    {
        SpawnWait = Random.Range(MinSpawnWait, MaxSpawnWait);
    }

    IEnumerator Spawner()
    {
        yield return new WaitForSeconds(StartWait);
        while (true)
        {
            RandEnemy = Random.Range(0, 2);

            Vector2 spawnPosition = new Vector2(Random.Range(-3, 3), Random.Range(4, 7));


            Instantiate(enemies[RandEnemy], spawnPosition, this.transform.rotation);

            yield return new WaitForSeconds(SpawnWait);
        }
    }
}
