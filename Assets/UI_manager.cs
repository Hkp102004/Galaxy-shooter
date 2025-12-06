using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_manager : MonoBehaviour
{
    [SerializeField]
    private Text score_txt; //to keep the track of score to display
    //private Player player;

    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>(); //making it conected to player script
        score_txt.text = "Score: " + 00;
    }

    // Update is called once per frame
    void Update()
    {
        //score_txt.text = "Score: " + player.score;
    }


    private void  Score_Update(int score)
    {
        score_txt.text = "Score: " + score;
    }
}
