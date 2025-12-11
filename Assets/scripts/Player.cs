using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Player : MonoBehaviour
{
    //public or private
    //data type (int,float,bool,string)
    //name
    //optional value assigned

    [SerializeField]
    private float speed = 3.5f;
    [SerializeField]
    private float multiplier = 2; //this to be multiplied to speed
    [SerializeField]
    private GameObject laserprefab;
    [SerializeField]
    private float firerate = 0.1f; //for having a time limit on firing laser
    private float canfire = -1f;
    [SerializeField]
    private int lives = 3;
    [SerializeField]
    private Spawn_Manager spawnManager; //Spawn_Manager is the class name , check the script you'll  understand or use notes
    [SerializeField]
    private bool trippleactive = false; //bool to deal with tripple shot activation
    [SerializeField]
    private bool speedactive = false; //bool to activate speed boost
    [SerializeField]
    private GameObject tripplelaser_prefab; //the prefab to tripple show that should instatiate instead of laser
    [SerializeField]
    private GameObject shield_prefab;  // the prefab of shield 
    [SerializeField]
    private GameObject left_engine;  //engine gameobjects
    [SerializeField]
    private GameObject right_engine;

    [SerializeField]
    private bool shieldactive = false; //bool to turn on the shield

    [SerializeField]
    public int score;  //score variable to keep a track of score

    [SerializeField]
    private Animator turning; //animation to handle player turning 


    //to make an input file that is already mapped to the unity engine ans using that
    //public float horizontalInput;

    private UI_manager UI;

    void Start()
    {
        transform.position = new Vector3(0, -3, 0);
        spawnManager = GameObject.Find("Spawn_Manager").GetComponent<Spawn_Manager>(); //linking spawn manager so I'll use the class name from Spawn_Manager script
        shield_prefab.SetActive(false); // so the payer doesn't have a shield when he starts

        UI = GameObject.Find("Canvas").GetComponent<UI_manager>(); //connecting the ui manager script 

        if(UI == null)
        {
            Debug.LogError("Ui manager is not connected");
        }

        shieldactive = false; //setting this so the player doesn't get shield at start

        left_engine.gameObject.SetActive(false); //setting the engine damages off at the start
        right_engine.gameObject.SetActive(false);

        turning = GetComponent<Animator>();

        if(turning == null)
        {
            Debug.LogError("Animator not found in Player");
        }
    }

    // Update is called once per frame
    void Update()
    {
        movement();

        if(Input.GetKeyDown(KeyCode.Space) && Time.time >canfire)
        {
            firelaser();
        }
    }

    void movement()
    {
        //make a local variable of horizontal input
        float horiInput = Input.GetAxis("Horizontal");

        // for the vertical movement
        float vertiInput = Input.GetAxis("Vertical");

        // putting the new horizontl input into the transfrom.translate formula
        //transform.Translate(Vector3.right * horiInput * speed * Time.deltaTime);

        // to make the game object move horizontally
        //transform.Translate(Vector3.up * vertiInput * speed * Time.deltaTime);

        // to do this more optimistically, we follow this way

        Vector3 direction = new Vector3(horiInput, vertiInput, 0);
        transform.Translate(direction * speed * Time.deltaTime); //movement of the body

        //if the position of y >= 0
        //position of y should be 0 and x and z should be as it is
        //else if the position of y <= -4.13f
        //position should stay that and the position of x shuold be as it is

        //if (transform.position.y >= 0)
        //{
        //    transform.position = new Vector3(transform.position.x, 0, 0);
        //}
        //else if (transform.position.y <= -4.13f)
        //{
        //    transform.position = new Vector3(transform.position.x, -4.13f, 0);
        //}

        //the math function for the y position thingy 

        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -4.13f, 0), 0); //to limit the movement of player in y direction

        //is the player position > 11.34f
        //player position = -11.34f
        //else if player position < -11.34f
        //player position = 11.34f

        if (transform.position.x > 11.34f) //this to make a loop so the player always stays on the screen
        {
            transform.position = new Vector3(-11.34f, transform.position.y, 0);
        }
        else if (transform.position.x < -11.34f)
        {
            transform.position = new Vector3(11.34f, transform.position.y, 0);
        }

        if (horiInput > 0.1f)   //animation player based on the direction player moves
        {
            turning.ResetTrigger("reset");
            turning.ResetTrigger("turning_left");
            turning.SetTrigger("turning_right");
        }
        else if (horiInput < -0.1f)
        {
            turning.ResetTrigger("reset");
            turning.ResetTrigger("turning_right");
            turning.SetTrigger("turning_left");
        }
        else
        {
            turning.ResetTrigger("turning_left");
            turning.ResetTrigger("turning_right");
            turning.SetTrigger("reset");
        }

    }

    void firelaser()
    {
        //use this method of input to take custom inputs and use them customly also using this only one key will be assigned to that
        canfire = Time.time + firerate;
        Debug.Log("congractulations you just pressed space key");
        //now I want the position to be a 
        //Instantiate(laserprefab, new Vector3(transform.position.x,(transform.position.y+0.9f) ,0), Quaternion.identity);
       
        if(trippleactive==true)
        {
            Instantiate(tripplelaser_prefab, transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(laserprefab, transform.position + new Vector3(0, 0.9f, 0), Quaternion.identity);
        }
    }

    public void Damage()
    {
        if(shieldactive==true)
        {
            shieldactive = false;
            shield_prefab.SetActive(false);
            return;
        }
        if(shieldactive == false)
        {
            lives -= 1;
            engine_fail();
            UI.update_life(lives);
        }

        if(lives < 1)
        {
            //UI.game_over();  removing this so the whole call complefity decreases
            Destroy(this.gameObject);
            spawnManager.OnPlayerDeath();
        }
    }

    public void ActivateTrippleshot() 
    {
        trippleactive = true;
        StartCoroutine(Tripleshotcooldown());
    }

    IEnumerator Tripleshotcooldown()
    {
        yield return new WaitForSeconds(5.0f); 
        trippleactive = false;
    }

    public void ActivateSpeed() //function to make the speed boost true
    {
        speedactive = true;
        speed *= multiplier; //changing the speed
        StartCoroutine(SpeedCooldown()); //cooldown
    }

    IEnumerator SpeedCooldown() //cooldown for speed
    {
        yield return new WaitForSeconds(5.0f); //will wait for 5 sec
        speedactive = false;
        speed /= multiplier;
    }

    public void ActivateShield()
    {
        shieldactive = true;
        StartCoroutine(ShieldCooldown());
        shield_prefab.SetActive(true);
    }

    IEnumerator ShieldCooldown()
    {
        yield return new WaitForSeconds(8.0f);
        shieldactive = false;
        shield_prefab.SetActive(false);
    }

    public void addscore(int n)
    {
        score += n;
        UI.Score_Update(score);
    }

    public void subscore(int n)
    {
        if(score > 0)
        {
            score -= n;
            UI.Score_Update(score);
        }
        else
        {
            Debug.Log("buddy the score is already 0, tf you doing?");
        }
    }

    private void engine_fail()
    {
        if(lives==2)
        {
            right_engine.gameObject.SetActive(true);
        }
        else if(lives==1)
        {
            left_engine.gameObject.SetActive(true);
        }
        else if(lives==3)
        {
            left_engine.gameObject.SetActive(false);
            right_engine.gameObject.SetActive(false);
        }
    }
}
