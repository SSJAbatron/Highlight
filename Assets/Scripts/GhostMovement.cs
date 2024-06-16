using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class GhostMovement : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform pointA, pointB;

    private Transform currentPoint;

    private Rigidbody2D ghostRigidBody;


    private float speed = 3f;

    private void Start()
    {
        currentPoint = pointB.transform;
        ghostRigidBody= GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Vector2 point = currentPoint.position - transform.position;
        // moving along the x axis and retaining the y axis as such
       
        if(currentPoint == pointB.transform)
        {
            ghostRigidBody.velocity = new Vector2(speed, 0f);
            
        }
        else
        {
            ghostRigidBody.velocity = new Vector2(-speed, 0f);
        }

        if(Vector2.Distance(transform.position,currentPoint.position) < 0.5f && currentPoint == pointB.transform)
        {
            FlipSpriteDirection();
            currentPoint = pointA.transform;
        }

        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointA.transform)
        {
            FlipSpriteDirection();
            currentPoint = pointB.transform;
        }

    }


    //  to flip the player sprite and all the child objects under it
    private void FlipSpriteDirection()
    {
        // get players current local scale
        Vector3 localScale = transform.localScale;
        // flip along the x axis or invert along the x axis
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GameObject player = collision.gameObject;
            if(player.transform.GetChild(0).gameObject.GetComponent<Light2D>().pointLightOuterRadius <= 1f)
            {
                GameManager.instance.loseGame = true;
            }
            else
            {
                player.transform.GetChild(0).gameObject.GetComponent<Light2D>().pointLightOuterRadius -= 1f;
                GameManager.instance.ChangeSliderColorTemp();
            }
        }
    }
}
