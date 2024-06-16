using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LanternBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // every 1 seconds the ligth radius reduces by 0.1
        StartCoroutine(ReduceLanternRange());
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.GetComponent<Light2D>().pointLightOuterRadius >= 7f)
        {
            transform.GetComponent<Light2D>().pointLightOuterRadius = 7f;
        }
        if (transform.GetComponent<Light2D>().pointLightOuterRadius < 0.8f)
        {
            transform.GetComponent<Light2D>().pointLightOuterRadius = 0.8f;
        }
    }

    private IEnumerator ReduceLanternRange()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            transform.GetComponent<Light2D>().pointLightOuterRadius -= 0.5f;
            GameManager.instance.UpdateLanternBrightnessSlider();
        }
    }
}
