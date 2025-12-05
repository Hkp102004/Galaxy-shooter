using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float speed = 4f;
    [SerializeField]
    private int deathzone = -6;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + Vector3.down * speed * Time.deltaTime; //for the behaviour of coming down
        //I don't know why I always forget the transform.translate function

        if(transform.position.y < deathzone)
        {
            float Randomx = Random.Range(-9.5f, 9.5f); //for choosing a random range between min and max
            transform.position = new Vector3(Randomx, 9.4f, 0); //to assign new position 
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    Debug.Log("Hit: " + other.transform.name);

    //    //the task is to destroy the player of the collision is with the player
    //    if (other.transform.name == "Laser(Clone)")
    //    {
    //        Destroy(other.gameObject);
    //        Destroy(gameObject);
    //    }

    //    if (other.transform.name == "player")
    //    {
    //        Destroy(other.gameObject);
    //        Destroy(gameObject);
    //    }
    //}

    //let's try the whole thing using tags

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Laser")
        {
            //I just wanted to access the laser script, this works so in case I had some function in laser script, I could use that shiii
            //laser laser = other.transform.GetComponent<laser>();
            //if(laser != null)
            //{
            //    Destroy(laser.gameObject);
            //}

            Player player = other.transform.GetComponent<Player>();

            Destroy(other.gameObject);
            Destroy(gameObject);
            //player.addscore();
        }

        if(other.gameObject.tag == "Player") //this will make sure the the collision was with player
        {
            Player player = other.transform.GetComponent<Player>();
            if (player != null)
            {
                player.Damage();
            }

            Destroy(this.gameObject);
        }
    }
}
