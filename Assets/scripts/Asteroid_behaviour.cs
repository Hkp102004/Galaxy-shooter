using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Asteroid_behaviour : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f; // speed variable to help in rotation

    void Start()
    {
        
    }

    void Update()
    {
        rotate();
    }

    public void rotate()
    {
        Vector3 rotation_direction = new Vector3(transform.position.x, transform.position.y, -speed); //to show which direction the game obj will rotate

        transform.Rotate(rotation_direction * Time.deltaTime); //rotation logic
    }
}
