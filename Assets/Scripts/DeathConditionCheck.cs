using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathConditionCheck : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GameManager.instance.loseGame = true;
        }
    }
}
