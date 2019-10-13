using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class pauseScript : MonoBehaviour
{
    public Button pauseButton;
    public Sprite PlayIcon;
    public Sprite PauseIcon;
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            Debug.Log(hit.transform.name);
        }
    }

    public void Pause()
    { 
        if(Time.timeScale == 1)
        {
            Time.timeScale = 0;
            pauseButton.image.overrideSprite = PlayIcon;
        } else
        {
            Time.timeScale = 1;
            pauseButton.image.overrideSprite = PauseIcon;
        }
    }
}
