using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Asteroid_behaviour : MonoBehaviour
{
    [SerializeField]
    private float speed = 30f; // speed variable to help in rotation
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(transform.position.x, transform.position.y, 60) * speed * Time.deltaTime);
    }
}
