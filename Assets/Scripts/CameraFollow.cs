using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class CameraFollow : MonoBehaviour
{
    public Transform followTarget;
    public Transform background;
    public Transform backgroundOffset;

    private float size;


    private void Start()
    {
        size = background.GetComponent<BoxCollider2D>().size.y;
    }

    void LateUpdate()
    {
        // follow player
        Vector3 newPos = new Vector3(transform.position.x, followTarget.position.y, transform.position.z);
        transform.position = newPos;

        //move background to follow camera when moving up
        if(transform.position.y >= backgroundOffset.position.y)
        {
            background.position= new Vector3(background.position.x,backgroundOffset.position.y+size,background.position.z);
            ChangeBackground();
        }
        //move background to follow camera when moving down/falling down
        if(transform.position.y < background.position.y) 
        {
            backgroundOffset.position = new Vector3(backgroundOffset.position.x, background.position.y - size, backgroundOffset.position.z);
            ChangeBackground();
        }

    }

    private void ChangeBackground()
    {
        Transform temp = background;
        background = backgroundOffset;
        backgroundOffset = temp;
    }
}
