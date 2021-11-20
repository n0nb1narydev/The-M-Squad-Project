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

    public bool isAlive = true;
    private UIManager uiManager;

    private Animator anim;

    void Start()
    {
        _bmanager = GameObject.Find("BattleManager").GetComponent<Battle_Manager>();
        harpChoir = GameObject.Find("Harp Choir").GetComponent<AudioSource > ();
        _player = GameObject.Find("Ship").GetComponent<Player>();
        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        anim = GetComponent<Animator>();
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
            harpChoir.Play();
            isAlive = false;
            Destroy(other.gameObject);
            anim.enabled = true;
            Destroy(this.gameObject, .5f);
            speed = 0f;
            
        }
    }


}
