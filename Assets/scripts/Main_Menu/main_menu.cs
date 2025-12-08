using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class main_menu : MonoBehaviour
{
    // Start is called before the first frame update

    public void new_game()
    {
        SceneManager.LoadScene(1); //game scene  
    }

}
