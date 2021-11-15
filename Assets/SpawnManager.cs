using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Player player;
    public GameObject _enemyPrefab;
    public GameObject _enemyContainer;
    public bool _stillSpawning = true;


    void Start()
    {
        StartSpawning(); // starts spawning enemies
    }
    public void StartSpawning()
    {
        StartCoroutine(SpawnRoutine());
    }

    void Update()
    {

    }

    IEnumerator SpawnRoutine()
    {
        yield return new WaitForSeconds(3f);
        while (_stillSpawning)
        {
            Vector3 posToSpawn = new Vector3(11, Random.Range(-4.2f, 6.2f), 0);
            GameObject newEnemy = Instantiate(_enemyPrefab, posToSpawn, Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform; //puts enemy clones in the container
            yield return new WaitForSeconds(5.0f);
        }
    }

   
    public void OnPlayerDeath()
    {
        _stillSpawning = false;
    }

}
