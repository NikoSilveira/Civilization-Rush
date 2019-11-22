using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSetter : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform leftButton;
    public Transform rightButton;
    public Transform attackButton;
    public Transform defenseButton;
    public Transform jumpButton;
    public Transform pauseButton;
    private Camera cam;

    void Start()
    {
        //Setting left button position
        cam = GetComponent<Camera>();
        float cameraHalf = cam.pixelWidth / 2;
        leftButton.position = new Vector3(-cameraHalf, leftButton.position.y, leftButton.position.z);
        Debug.Log(leftButton.position.x);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
