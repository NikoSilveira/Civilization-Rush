using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Script para los créditos del juego. Añadir lógica de nuevos features a este script
 */

public class Credits : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Llamado con delay - 55.5s
        Invoke("FinishCredits",55.5f);
    }

    public void FinishCredits()
    {
        //Volver al menú principal
        FindObjectOfType<LevelChanger>().FadeToLevel(0);
    }
}
