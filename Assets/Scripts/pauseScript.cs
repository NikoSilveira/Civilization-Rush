using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseScript : MonoBehaviour
{
    public Sprite PlayIcon;
    public Sprite PauseIcon;
    void Update()
    {
    }

    public void Pause()
    { 
            if(Time.timeScale == 1)
            {
                Time.timeScale = 0;
                this.gameObject.GetComponent<SpriteRenderer>().sprite = PlayIcon;
            } else
            {
                Time.timeScale = 1;
                this.gameObject.GetComponent<SpriteRenderer>().sprite = PauseIcon;
            }
    }
}
