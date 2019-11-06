using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteButton : MonoBehaviour
{

    //Variables para control del sprite del boton mute
    public Sprite unmuted;
    public Sprite muted;
    private SpriteRenderer muteSpriteRenderer;

    private bool muteControl = false;

    // Start is called before the first frame update
    void Start()
    {
        muteSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MuteSpriteControl()
    {
        Debug.Log("hola");
        if (!muteControl)
        {
            Debug.Log(false);
            //sprite mute
            muteSpriteRenderer.sprite = muted;
            muteControl = true;
        }
        else
        {
            Debug.Log(true);
            //sprite unmute
            muteSpriteRenderer.sprite = unmuted;
            muteControl = false;
        }
    }
}
