using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    -Este script es utilizado por PlayerPhone para 
    obtener la variable de control del checkpoint
    -Cuando se registra una colisión con el chackpoint,
    se alamacena en el jugador la posición donde se activó
    con un vector3
    -Se almacena en un archivo local los atributos del jugador
    al momento de activar el checkpoint
*/

public class CheckpointController : MonoBehaviour
{

    private PlayerPhone player;
    public Animator animator;

    //Bool de control de activación del checkpoint
    public bool checkpointReached;

    public GameObject enemyParameter;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerPhone>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //Colisión Player - Checkpoint
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !checkpointReached)
        {
            //Activar checkpoint
            animator.SetBool("Activated",true);
            checkpointReached = true;
            player.checkpointReached = checkpointReached;

            //Guardar atributos actuales en doc local
            SaveProgress();

            //Registrar posición en variables de player
            player.respawnPoint = collision.transform.position;

            //SFX
            FindObjectOfType<AudioManager>().Play("Checkpoint");
        }
    }

    //Guardar progreso al activar checkpoint
    private void SaveProgress()
    {
        PlayerPrefs.SetInt("CurrentScore", player.Score);
        PlayerPrefs.SetInt("CurrentStamina", player.myResistance);
        PlayerPrefs.SetInt("CurrentHealth", player.myHealth);
    }

    private void DestroyEnemies()
    {
        MonoBehaviour[] enemies = enemyParameter.GetComponentsInChildren<MonoBehaviour>();
        for (int i = 0; i < enemies.Length; i++)
        {
            if(!enemies[i].gameObject.activeInHierarchy)
            {
                Destroy(enemies[i].gameObject);
            }
        }
    }

    public void TurnOnEnemies()
    {
        MonoBehaviour[] enemies = enemyParameter.GetComponentsInChildren<MonoBehaviour>();
        for(int i = 0; i < enemies.Length; i++)
        {
            if (!enemies[i].gameObject.activeInHierarchy)
            {
                enemies[i].gameObject.SetActive(true);
                if(enemies[i].gameObject.GetComponent<EnemyMovement>() != null && enemies[i].gameObject.GetComponent<EnemyMovement>().isActiveAndEnabled)
                {
                    enemies[i].gameObject.GetComponent<EnemyMovement>().RestartHealth();
                } else if(enemies[i].gameObject.GetComponent<LargeDistanceEnemy>() != null && enemies[i].gameObject.GetComponent<LargeDistanceEnemy>().isActiveAndEnabled)
                {
                    enemies[i].gameObject.GetComponent<LargeDistanceEnemy>().RestartHealth();
                } else if(enemies[i].gameObject.GetComponent<Boss2Movement>() != null && enemies[i].gameObject.GetComponent<Boss2Movement>().isActiveAndEnabled)
                {
                    enemies[i].gameObject.GetComponent<Boss2Movement>().RestartHealth();
                }
            }
        }
    }
}
