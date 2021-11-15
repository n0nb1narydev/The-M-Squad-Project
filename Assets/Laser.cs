using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float _laserSpeed = 8.0f;

    void Update()
    {

        Vector3 laserDirection = new Vector3(1, 0, 0);
        transform.Translate(laserDirection * _laserSpeed * Time.deltaTime);

        if (transform.position.x > 16f)
        {
            if (transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }
            Destroy(this.gameObject);
        }

    }
}
