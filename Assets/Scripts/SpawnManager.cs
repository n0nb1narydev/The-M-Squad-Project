using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Player player;
    public GameObject enemyPrefab;
    public GameObject enemyContainer;
    public bool stillSpawning;

    private Battle_Manager _bmanager;


    void Start()
    {
        _bmanager = GameObject.Find("BattleManager").GetComponent<Battle_Manager>();

        StartSpawning();
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
        while (stillSpawning)
        {
            Vector3 posToSpawn = new Vector3(Random.Range(-4.2f, 4.2f), -8.8f, 0);
            GameObject newEnemy = Instantiate(enemyPrefab, posToSpawn, Quaternion.identity);
            newEnemy.transform.parent = enemyContainer.transform; //puts enemy clones in the container
            
            if(_bmanager.numWaves == 5)
            {
                yield return new WaitForSeconds(5.0f);
            }
            else if(_bmanager.numWaves == 4)
            {
                yield return new WaitForSeconds(4.0f);

            }
            else if (_bmanager.numWaves == 3)
            {
                yield return new WaitForSeconds(3.0f);

            }
            else if (_bmanager.numWaves == 2)
            {
                yield return new WaitForSeconds(2.0f);

            }
            else if (_bmanager.numWaves == 1)
            {
                yield return new WaitForSeconds(1.0f);

            }
            else
            {
                print("Waves Complete");
                stillSpawning = false;
            }
        }
    }

   
    public void OnPlayerDeath()
    {
        stillSpawning = false;
    }

}
