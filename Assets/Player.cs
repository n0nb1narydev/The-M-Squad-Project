using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour //Unity Specific Term

{

    public float _speed = 5f;
    public GameObject _laserPrefab;
    public float _fireRate = .15f;
    private float _canFire = -2f;



    void Start()
    {
        // Sets player start position
        transform.position = new Vector3(0f, 6f, 0);
    }

    void Update() // runs 60 frames per second
    {
        CalculateMovement();

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
        {
            FireLaser();
        }
    }




    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0); //make a Vector3 variable
        transform.Translate(direction * _speed * Time.deltaTime);

        //Set Player Bounds and Ship Wrap
        // transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.postion.y, -3.8f, 0), 0); Gives error CS1061
        if (transform.position.y <= 4f)
        {
            transform.position = new Vector3(transform.position.x, 4f, 0);
        }
        else if (transform.position.y >= 8.8f)
        {
            transform.position = new Vector3(transform.position.x, 8.8f, 0);
        }
        if (transform.position.x <= -5.6f)
        {
            transform.position = new Vector3(5.6f, transform.position.y, 0);
        }
        else if (transform.position.x >= 5.7f)
        {
            transform.position = new Vector3(-5.5f, transform.position.y, 0);
        }
    }

    void FireLaser()
    {
        _canFire = Time.deltaTime + _fireRate;
      
        Vector3 offset1 = new Vector3(0, -.9f, 0);
        Instantiate(_laserPrefab, transform.position + offset1, Quaternion.identity); //default rotation 99% of the time what you'll use.
    }
}