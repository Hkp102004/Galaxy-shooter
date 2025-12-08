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

    private Player player;
    [SerializeField]
    Animator blast;  //animation of enemy distruction
    void Start()
    {
        player = GameObject.Find("player").GetComponent<Player>();  //connecting to player at start so don't have to implement again and again

        blast = gameObject.GetComponent<Animator>(); //finding the animator as the game starts

        if (blast == null)
        {
            Debug.LogError("Animation is not here buddy, find it");
        }

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

            Destroy(other.gameObject);
            player.addscore(10);
            blast.SetTrigger("explosion trigger"); //maybe activating the trigger 
            speed = 0;
            Destroy(gameObject,2.4f);
        }

        if(other.gameObject.tag == "Player") //this will make sure the the collision was with player
        {
            //Player player = other.transform.GetComponent<Player>();
            if (player != null)
            {
                player.subscore(10);
                player.Damage();
            }
            blast.SetTrigger("explosion trigger");
            speed = 0;
            Destroy(this.gameObject,2.4f);
        }
    }
}
