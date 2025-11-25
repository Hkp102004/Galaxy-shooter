using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class laser : MonoBehaviour
{

    //speed variable
    [SerializeField]
    private float speed = 10f;
    private float deathzone = 7.5f; //the point where the prefab should be deleted
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transrform so the laser always moves up contineously

        //this code will work, it actualy worked but it's not the best solutuion
        //transform.position = transform.position + Vector3.up * speed *Time.deltaTime;
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        //as the laser crosses the deathzzone it should be deleted, that's all
        if(transform.position.y > deathzone)
        {
            if(transform.parent!=null)
            {
                Destroy(transform.parent.gameObject);
                Destroy(gameObject);
                Debug.Log("Laser gone with parent");
            }
            else
            {
                Destroy(gameObject);
                Debug.Log("Laser gone without any parent");
            }
        }
    }
}
