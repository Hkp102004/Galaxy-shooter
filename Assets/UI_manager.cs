using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_manager : MonoBehaviour
{
    [SerializeField]
    private Text score_txt; //to keep the track of score to display
    [SerializeField]
    private Sprite[] lives_img; //array of lives sprite
    [SerializeField]
    private Image sprite_image; //variable that will store the image to display
    [SerializeField]
    private Text gameovr_txt;

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


    public void  Score_Update(int score)
    {
        score_txt.text = "Score: " + score;
    }

    public void update_life(int lives) //function to display correct life 
    {
        sprite_image.sprite = lives_img[lives];
    }
}
