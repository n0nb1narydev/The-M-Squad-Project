﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float _laserSpeed = 8.0f;
    void Start()
    {
        transform.rotation = Quaternion.Euler(180, 0, 0);
    }

    void Update()
    {

        Vector3 laserDirection = new Vector3(0, 1, 0);
        transform.Translate(laserDirection * _laserSpeed * Time.deltaTime);

        if (transform.position.y < -10f)
        {
            if (transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }
            Destroy(this.gameObject);
        }

    }
}
