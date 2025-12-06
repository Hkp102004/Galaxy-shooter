using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_manager : MonoBehaviour
{
    [SerializeField]
    private Text score_txt; //to keep the track of score to display

    Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>(); //making it conected to player script

    void Start()
    {
        score_txt.text = "Score: " + 10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
