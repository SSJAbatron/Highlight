using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPartBehaviour : MonoBehaviour
{
    public GameObject platformPart;
    // Start is called before the first frame update
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GameManager.instance.ActivateDeathZone();
            Destroy(platformPart,2f);
        }
    }
}
