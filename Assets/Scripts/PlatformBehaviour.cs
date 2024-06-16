using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public bool hasPassed = false;
    public Transform[] lightOrbSpawnPoints;

    public GameObject lightOrb;

    private void Start()
    {
        if(lightOrb!= null && lightOrbSpawnPoints.Length > 0)
            Instantiate(lightOrb, lightOrbSpawnPoints[UnityEngine.Random.Range(0, lightOrbSpawnPoints.Length)]);
    }

}
