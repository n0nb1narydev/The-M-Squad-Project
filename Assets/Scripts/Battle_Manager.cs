using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle_Manager : MonoBehaviour
{
    private Player _player;
    private SpawnManager _spawnManager;

    public bool playerIsAlive = true;
    public float waveTimer = 60f;
    public int numWaves = 5;

    void Start()
    {
        _player = GameObject.Find("Ship").GetComponent<Player>();
        _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }

    void Update()
    {
        waveTimer -= Time.deltaTime;

        if(waveTimer >= 0f)
        {
            print(waveTimer);
            _spawnManager.stillSpawning = true;
        }
        else
        {
            if(numWaves > 0)
            {
                print("Wave Complete");
                numWaves--;
                _spawnManager.stillSpawning = false;
                waveTimer = 30f;
            }

        }
    }


}
