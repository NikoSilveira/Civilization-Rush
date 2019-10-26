using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CamWeapChan : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite[] weaponSel;
    public Image ChangeUI;
    private PlayerAttack weapon;


    void Start()
    {
        weapon = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttack>();
    }

    // Update is called once per frame
    void Update()
    {
        ChangeUI.sprite = weaponSel[weapon.weaponSelected -1];
    }
}
