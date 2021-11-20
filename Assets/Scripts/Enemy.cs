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

    void Start()
    {
        _bmanager = GameObject.Find("BattleManager").GetComponent<Battle_Manager>();
        harpChoir = GameObject.Find("Harp Choir").GetComponent<AudioSource > ();
        _player = GameObject.Find("Ship").GetComponent<Player>(); //null check
        if (_player == null)
        {
            Debug.LogError("Component: Player not found.");
        }
    }

    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        if (transform.position.y > 10.7f)
        {
            float randomX = Random.Range(-4.3f, 4.3f);
            transform.position = new Vector3(randomX, -8.8f, 0);
        }

        if (_bmanager.numWaves == 4)
        {
            speed = 4f;
        }
        else if (_bmanager.numWaves == 3)
        {
            speed = 5f;

        }
        else if (_bmanager.numWaves == 2)
        {
            speed = 6f;

        }
        else if (_bmanager.numWaves == 1)
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
                print("Player Hit");
            }
        }

        if (other.tag == "Laser")
        {
            //        ScoreScript.scoreValue += 10;
            harpChoir.Play();
            isAlive = false;
        }
        Destroy(other.gameObject);
        //  _anim.SetTrigger("OnEnemyDeath");
        speed = 0f;
        Destroy(this.gameObject);
    }


}
