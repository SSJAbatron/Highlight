using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightBallBehaviour : MonoBehaviour
{
    public GameObject CaptureVFX;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // increase light and destroy
        if (collision.gameObject.tag == "Player")
        {
            AudioManager.instance.PlaySFX("Collect");
            GameObject player = collision.gameObject;
            player.transform.GetChild(0).gameObject.GetComponent<Light2D>().pointLightOuterRadius += 2f;
            Instantiate(CaptureVFX, transform.position,Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
