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

    public bool isAlive = true;
    private UIManager uiManager;

    private Animator anim;

    private GameObject _destroyParticle;
    private SpriteRenderer sprite;

    void Start()
    {
        _bmanager = GameObject.Find("BattleManager").GetComponent<Battle_Manager>();
        harpChoir = GameObject.Find("Harp Choir").GetComponent<AudioSource > ();
        evilLaugh = GameObject.Find("Evil Laugh").GetComponent<AudioSource>();
        _player = GameObject.Find("Ship").GetComponent<Player>();
        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        _destroyParticle = transform.GetChild(0).gameObject;
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        if (transform.position.y > 10.7f)
        {
            float randomX = Random.Range(-4.3f, 4.3f);
            transform.position = new Vector3(randomX, -8.8f, 0);
        }

        if (_bmanager.numWaves == 2)
        {
            speed = 4f;
        }
        else if (_bmanager.numWaves == 3)
        {
            speed = 5f;

        }
        else if (_bmanager.numWaves == 4)
        {
            speed = 6f;

        }
        else if (_bmanager.numWaves == 5)
        {
            speed = 7f;

        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

            if (_player != null) // Null Checking
            {
                if(_player.lives > 0)
                {
                    _player.lives--;
                    _player.isAlive = false;
                    evilLaugh.Play();
                    uiManager.UpdateLivesText(_player.lives);
                    Destroy(this.gameObject);
                }
                else
                {
                    print("game over");
                }
                
            }
        }

        if (other.tag == "Laser")
        {
            _player.score += 10;
            uiManager.UpdateScoreText(_player.score);
            speed = 0f;
            harpChoir.Play();
            isAlive = false;
            Destroy(other.gameObject);
            sprite.enabled = false;
            _destroyParticle.SetActive(true);
            Destroy(this.gameObject, .5f);
            
            
        }
    }


}
