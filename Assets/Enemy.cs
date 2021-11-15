using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float _speed = 4f;
    private GameObject _enemyPrefab;
    
    private Player _player;

    public bool isAlive = true;

    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>(); //null check
        if (_player == null)
        {
            Debug.LogError("Component: Player not found.");
        }
    }

    void Update()
    {
        transform.Translate(Vector3.left * _speed * Time.deltaTime);

        if (transform.position.x < -11f)
        {
            float randomY = Random.Range(-4.2f, 6.2f);
            transform.position = new Vector3(11, randomY, 0);
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
                isAlive = false;
        }
        Destroy(other.gameObject);
      //      _anim.SetTrigger("OnEnemyDeath");
        _speed = 0f;
        Destroy(this.gameObject);
    }


}
