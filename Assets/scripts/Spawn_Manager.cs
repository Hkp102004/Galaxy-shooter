using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Manager : MonoBehaviour
{
    [SerializeField]
    private GameObject Enemy;
    [SerializeField]
    private GameObject enemy_container;
    [SerializeField]
    public bool stopSpawning = false;
    [SerializeField]
    private GameObject[] powerups; //array of powerups
    //private GameObject triple_shot; //0 = tripple shot, 1= speed 2 = shield
    // Start is called before the first frame update
    void Start()
    {
        //start_spawn()  startting the spawning from Astroid_behaviour script when it is destroyed
    }

    public void start_spawn()
    {
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnTrippleshotRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     public IEnumerator SpawnEnemyRoutine()
    {
        yield return new WaitForSeconds(2f); //will wait for 2s before spawning everything after the asteroid is destroyed
        while (stopSpawning==false) 
        {
            Vector3 position = new Vector3(Random.Range(-9.3f, 9.3f), 7, 0);
            GameObject new_enemy= Instantiate(Enemy, position, Quaternion.identity);
            new_enemy.transform.parent = enemy_container.transform;  //this is like making a parent so now all the enemy will be shown below this and hierarchy will be cleaner
            yield return new WaitForSeconds(1.2f); //the time difference in while the enemy will spawn
        }
    }

    public IEnumerator SpawnTrippleshotRoutine()
    {
        yield return new WaitForSeconds(3f); //will wait 3 sec before spwning powerups
        while(stopSpawning==false)
        {
            Vector3 position = new Vector3(Random.Range(-9.3f, 9.3f), 7.69f, 0);
            int random = Random.Range(0, 3); //will choose a rabdom no from 0 to 2 since it keeps it as [0,3)
            //GameObject tripple_shot = Instantiate(gameObject, position, Quaternion.identity);  old one to only spawn tripple shot

            Instantiate(powerups[random], position, Quaternion.identity); // new one with array to spawn one of the  powerups
            yield return new WaitForSeconds(10.0f);
        }
    }

     public void OnPlayerDeath() //public so other scripts can access it easily
    {
        stopSpawning = true;
    }
}
