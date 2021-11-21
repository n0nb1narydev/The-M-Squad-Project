using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour

{

    public float _speed = 5f;
    private GameObject _laserPrefab;
    public float _fireRate = .15f;
    private float _canFire = -2f;

    public int score = 0;
    public int lives = 3;
    public bool isAlive = true;

    private GameObject _exhaustParticle;
    private Battle_Manager _bManager;
    private Animator rocketLaunch;


    void Start()
    {
        _exhaustParticle = GameObject.Find("Particle System");
        _laserPrefab = Resources.Load("Laser") as GameObject;
        _bManager = GameObject.Find("BattleManager").GetComponent<Battle_Manager>();
        rocketLaunch = GetComponent<Animator>();


        rocketLaunch.enabled = false;

        // Sets player start position, size and rotation
        transform.position = new Vector3(0f, 8f, 0);
        transform.localScale = new Vector3(.4f, .4f, .4f);
        transform.rotation = Quaternion.Euler(180, 0, 0);
    }

    void Update() // runs 60 frames per second
    {
        CalculateMovement();
        if (!isAlive)
        {
            if (lives < 0)
            {
                _bManager.GameOver();
            }
            else
            {
                transform.position = new Vector3(0f, 8.8f, 0);
                isAlive = true;
            }
        }
        //_exhaustParticle.SetActive(true);
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
        {
            FireLaser();
        }


    }




    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontalInput, verticalInput * -1, 0); //make a Vector3 variable
        transform.Translate(direction * _speed * Time.deltaTime);

        //Set Player Bounds
        if (transform.position.y <= 4f)
        {
            transform.position = new Vector3(transform.position.x, 4f, 0);
        }
        else if (transform.position.y >= 8.8f)
        {
            transform.position = new Vector3(transform.position.x, 8.8f, 0);
        }
        if (transform.position.x <= -4.2f)
        {
            transform.position = new Vector3(-4.2f, transform.position.y, 0);
        }
        else if (transform.position.x >= 4.2f)
        {
            transform.position = new Vector3(4.2f, transform.position.y, 0);
        }
    }

    void FireLaser()
    {
        _canFire = Time.deltaTime + _fireRate;
      
        Vector3 offset1 = new Vector3(0, -3.5f, 0);
        Instantiate(_laserPrefab, transform.position + offset1, Quaternion.identity); //default rotation 99% of the time what you'll use.
    }
}