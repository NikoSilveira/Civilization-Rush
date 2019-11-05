using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
    -Control del indicador de armas
    -Este script crea un objeto de tipo PlayerAttack para poder obtener
    el arma actualmente equipada y mostrarla en el indicador de arma
 */

public class CamWeapChan : MonoBehaviour
{
    
    //Variables para el sprite
    public Sprite[] weaponSel;
    public Image ChangeUI;

    private PlayerAttack weapon;

    // Start is called before the first frame update
    void Start()
    {
        weapon = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttack>();
    }

    // Update is called once per frame
    void Update()
    {
        //Actualizar en tiempo real el indicador de arma
        ChangeUI.sprite = weaponSel[weapon.weaponSelected -1];
    }
}
