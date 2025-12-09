using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Asteroid_behaviour : MonoBehaviour
{
    [SerializeField]
    private float speed = 15f; // speed variable to help in rotation
    [SerializeField]
    private GameObject explosion;

    void Start()
    {
        
    }

    void Update()
    {
        //rotate();
        better_rotate();
    }

    public void rotate()
    {
        Vector3 rotation_direction = new Vector3(transform.position.x, transform.position.y, -speed); //to show which direction the game obj will rotate

        transform.Rotate(rotation_direction * Time.deltaTime); //rotation logic
    }

    public void better_rotate()
    {
        transform.Rotate(Vector3.forward * -speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Laser")
        {
            Destroy(other.gameObject);
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(explosion.gameObject, 2f);
            Destroy(gameObject);
        }
        if(other.gameObject.tag == "Player")
        {

        }
    }
}
