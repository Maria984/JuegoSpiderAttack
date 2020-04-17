using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Salud : MonoBehaviour
{

    public enum deathAction { loadLevelWhenDead, doNothingWhenDead };

    public float healthPoints = 1f;
    public float respawnHealthPoints = 1f;      //base health points

    public int numberOfLives = 1;                   //lives and variables for respawning
    public bool isAlive = true;

    public GameObject explosionPrefab;

    public deathAction onLivesGone = deathAction.doNothingWhenDead;

    public string LevelToLoad = "";

    private Vector3 respawnPosition;
    private Quaternion respawnRotation;

    [SerializeField] public GameObject vida1;
    [SerializeField] public GameObject vida2;
    [SerializeField] public GameObject vida3;


    // Use this for initialization
    void Start()
    {
        // store initial position as respawn location
        respawnPosition = transform.position;
        respawnRotation = transform.rotation;

        if (LevelToLoad == "") // default to current scene 
        {
            Scene scene = SceneManager.GetActiveScene();

            LevelToLoad = scene.name;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (healthPoints <= 0)
        {               // if the object is 'dead'
           numberOfLives--;                    // decrement # of lives, update lives GUI

            if (explosionPrefab != null)
            {
                Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            }

            if (numberOfLives > 0)
           {  //respawn
                transform.position = respawnPosition;   // reset the player to respawn position
                transform.rotation = respawnRotation;
                healthPoints = respawnHealthPoints; // give the player full health again

                if (numberOfLives == 2)
                {
                    vida1.SetActive(false);
                }
                if (numberOfLives == 1)
                {
                    vida2.SetActive(false);
                }
                if (numberOfLives == 0)
                {
                    vida3.SetActive(false);
                }
            }
           
            



            else
            { // here is where you do stuff once ALL lives are gone)
                isAlive = false;

                switch (onLivesGone)
                {
                    case deathAction.loadLevelWhenDead:
                        SceneManager.LoadScene(3);

                        break;
                    case deathAction.doNothingWhenDead:
                        // do nothing, death must be handled in another way elsewhere
                        break;
                }
                Destroy(gameObject);
            }
        }
    }

    public void ApplyDamage(float amount)
    {
        healthPoints = healthPoints - amount;
    }

    public void ApplyHeal(float amount)
    {
        healthPoints = healthPoints + amount;
    }

    public void ApplyBonusLife(int amount)
    {
       numberOfLives = numberOfLives + amount;
    }

    public void updateRespawn(Vector3 newRespawnPosition, Quaternion newRespawnRotation)
    {
        respawnPosition = newRespawnPosition;
        respawnRotation = newRespawnRotation;
    }
}