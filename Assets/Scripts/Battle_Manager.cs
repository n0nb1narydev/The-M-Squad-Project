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

    public AudioSource backgroundMusic;

    public GameObject gameOverScreen;
    public GameObject winnerScreen;
    public bool isGameOver = false;

    public Animator waveAnim;

    void Start()
    {

        _player = GameObject.Find("Ship").GetComponent<Player>();
        _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        waveAnim.SetBool("newWave", true);
    }

    void Update()
    {
        waveTimer -= Time.deltaTime;

        int waveTimerInt = (int)Mathf.Round(waveTimer);
        uiManager.UpdateTimerText(waveTimerInt);

        if (waveTimer < 0f)
        {
            if (numWaves < 5)
            {
                numWaves++;
                waveAnim.gameObject.SetActive(false);
                waveAnim.gameObject.SetActive(true); 
                uiManager.UpdateWaveText(numWaves);
                waveTimer = 30f;
                
            }
            else
            {
                Winner();
            }
        }
    }

    public void GameOver()
    {
        isGameOver = true;
        backgroundMusic.volume = 0;
        gameOverScreen.SetActive(true);
        _spawnManager.stillSpawning = false;
    }

    public void Winner()
    {
        isGameOver = true;
        backgroundMusic.volume = 0;
        winnerScreen.SetActive(true);
        _spawnManager.stillSpawning = false;
    }
}
