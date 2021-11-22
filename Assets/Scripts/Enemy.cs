using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3f;
    private GameObject _enemyPrefab;
    
    private Player _player;
    private Battle_Manager _bmanager;

    private AudioSource harpChoir;
    private AudioSource evilLaugh;

    private UIManager uiManager;

    private Animator anim;

    private GameObject _destroyParticle;

    private GameObject _playerHitParticle;
    private SpriteRenderer sprite;
    private bool isAlive = true;
    private ScoreManager sManager;


    void Start()
    {
        _bmanager = GameObject.Find("BattleManager").GetComponent<Battle_Manager>();
        harpChoir = GameObject.Find("Harp Choir").GetComponent<AudioSource > ();
        evilLaugh = GameObject.Find("Evil Laugh").GetComponent<AudioSource>();
        _player = GameObject.Find("Ship").GetComponent<Player>();
        sManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        _destroyParticle = transform.GetChild(0).gameObject;
        sprite = GetComponent<SpriteRenderer>();
        _playerHitParticle = _player.transform.GetChild(0).gameObject;
    }

    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        _playerHitParticle.SetActive(false);
        if (transform.position.y > 10.7f)
        {
            float randomX = Random.Range(-4.3f, 4.3f);
            transform.position = new Vector3(randomX, -8.8f, 0);
        }

        if (_bmanager.numWaves == 2)
        {
            if(isAlive)
            {
                speed = 4f;
            }
            
        }
        else if (_bmanager.numWaves == 3)
        {
            if (isAlive)
            {
                speed = 5f;
            }
        }
        else if (_bmanager.numWaves == 4)
        {
            if (isAlive)
            {
                speed = 6f;
            }
        }
        else if (_bmanager.numWaves == 5)
        {
            if (isAlive)
            {
                speed = 7f;
            }
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

            if (_player != null) // Null Checking
            {
                if(!_bmanager.isGameOver)
                {
                    _playerHitParticle.SetActive(true);
                    _player.lives--;
                    _player.isAlive = false;
                    evilLaugh.Play();
                    uiManager.UpdateLivesText(_player.lives);
                    Destroy(this.gameObject);
                }
                    
            }
        }

        if (other.tag == "Laser")
        {
            isAlive = false;
            speed = 0f;
            sManager.score += 10;
            uiManager.UpdateScoreText(sManager.score);
            harpChoir.Play();
            Destroy(other.gameObject);
            sprite.enabled = false;
            _destroyParticle.SetActive(true);
            Destroy(this.gameObject, .5f); 
        }
    }
}
