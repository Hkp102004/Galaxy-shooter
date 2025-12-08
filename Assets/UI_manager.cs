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
    [SerializeField]
    private Text restart_txt;
    [SerializeField]
    private Button main_menu;

    private GameManager gm;

    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>(); //making it conected to player script
        score_txt.text = "Score: " + 00;
        gameovr_txt.gameObject.SetActive(false);
        restart_txt.gameObject.SetActive(false);
        main_menu.gameObject.SetActive(false); //set the button to inactive till the player dies

        gm = GameObject.Find("Game Manager").GetComponent<GameManager>();

        if(gm == null)
        {
            Debug.LogError("Game Manager is NULL");
        }
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

        //if(lives == 0)
        //{
        //    gameovr_txt.gameObject.SetActive(true);
        //    StartCoroutine(gameover_flickering());

        //}
        if(lives==0)
        {
            gameover();
        }

    }

    public void gameover()
    {
        StartCoroutine(gameover_flickering()); //couroutine to flicker the game over screen
        restart_txt.gameObject.SetActive(true);
        main_menu.gameObject.SetActive(true);
        gm.Gameover();
    }

    //public void game_over()  to decreate complexity
    //{
    //    gameovr_txt.gameObject.SetActive(true);
    //}

    IEnumerator gameover_flickering()
    {
        while(true)
        {
            gameovr_txt.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            gameovr_txt.gameObject.SetActive(false);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
