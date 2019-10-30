using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite[] HearthSprices;

    public Image HearthUI;
    private PlayerPhone player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerPhone>();

    }

    private void Update()
    {
        HearthUI.sprite = HearthSprices[player.myH];
    }
}
