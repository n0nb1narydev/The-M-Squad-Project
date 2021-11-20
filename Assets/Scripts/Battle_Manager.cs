using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle_Manager : MonoBehaviour
{
    private Player _player;
    private SpawnManager _spawnManager;
    public UIManager uiManager;

    public bool playerIsAlive = true;
    public float waveTimer = 30f;
    public int numWaves = 1;

    void Start()
    {
        _player = GameObject.Find("Ship").GetComponent<Player>();
        _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }

    void Update()
    {
        waveTimer -= Time.deltaTime;

        int waveTimerInt = (int)Mathf.Round(waveTimer);
        uiManager.UpdateTimerText(waveTimerInt);
        
        if (waveTimer >= 0f)
        {
            _spawnManager.stillSpawning = true;
        }
        else
        {
            print(numWaves);
            if(numWaves < 5)
            {
                numWaves++;
                uiManager.UpdateWaveText(numWaves);
                waveTimer = 30f;
            }
        }
    }


}
