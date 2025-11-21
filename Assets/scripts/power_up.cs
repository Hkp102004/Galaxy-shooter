using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class power_up : MonoBehaviour
{
    [SerializeField]
    private float speed = 3;
    [SerializeField]
    private float deathzone = -6;
    // Start is called before the first frame update
    [SerializeField]
    private int power_up_id;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        move();

        if (transform.position.y < deathzone)
        {
            destroy();
        }
    }

    public void move()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    public void destroy()
    {
        Destroy(gameObject);
        Debug.Log("Powerup destroyed");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player") //when player collides the game obj should destroy
        {
            Player player = other.gameObject.GetComponent<Player>(); //to connect to player script
            destroy();
            if (player != null)
            {
                switch(power_up_id) //using switch so the code is more optimised and don't have more prioblem for developement
                {
                    case 0: //if 0 it'll activate tripple shot
                        player.ActivateTrippleshot();
                        Debug.Log("The object that you just hit was tripple shot");
                        break;
                    case 1: 
                        Debug.Log("The object that you just hit now is speed");
                        break;
                    case 2:
                        Debug.Log("The thing that you just hit is the shield");
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
