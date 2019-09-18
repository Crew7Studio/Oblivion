using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public GameObject plyr;
    public Transform checkPoint;
    public GameObject currentCheckPoint;

    private PlayerController player;
    private PlayerHealthManager healthManager;

    public GameObject playerModeCanvas, one, two;

    public GameObject canon;
    


    public int penaltyOnDeath;
    public float setTimeDelay;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        healthManager = FindObjectOfType<PlayerHealthManager>();
        Debug.Log(MainMenu.playerMode);


        if (MainMenu.playerMode == 1) {
            one.SetActive(false);
            two.SetActive(false);
            playerModeCanvas.SetActive(false);
        }
        if (MainMenu.playerMode == 2)
        {
            StartCoroutine( FirstPlayer());
        }
        

    }

    void Update()
    {
       

        
    }

    public void RespawnPlayer()
    {
        //Debug.Log("Player respawn");
     //   player.transform.position = currentCheckPoint.transform.position;
        ScoreManager.AddPoints(-penaltyOnDeath);
        if (MainMenu.playerMode == 2)
            StartCoroutine(SecondPlayer());

        healthManager.FullHealth();
        healthManager.isDead = false;
        ScoreManager.ResetPoints();

        //Instantiate(player, checkPoint.position, checkPoint.rotation);
         player.transform.position = currentCheckPoint.transform.position;




    }

    IEnumerator FirstPlayer() {

        Debug.Log("first player");
       
            playerModeCanvas.SetActive(true);
            one.SetActive(true);
            two.SetActive(false);
            Time.timeScale = .0000001f;

            yield return new WaitForSeconds(setTimeDelay * Time.timeScale);
        
            Time.timeScale = 1f;
            one.SetActive(false);
            playerModeCanvas.SetActive(false);
        
    }

    IEnumerator  SecondPlayer() {

        //destroy all enemies for respawning -- respawning is done by the respawnEnemyGameObject.
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
            GameObject.Destroy(enemy);


        Debug.Log("second player");
        canon.GetComponent<EnemyHealthManager>().ResetEnemyHealth();
        playerModeCanvas.SetActive(true);
        two.SetActive(true);
        Time.timeScale = .0000001f;

        yield return new WaitForSeconds(setTimeDelay * Time.timeScale);

        
        playerModeCanvas.SetActive(false);
        two.SetActive(false);
        Time.timeScale = 1f;


    }
}
