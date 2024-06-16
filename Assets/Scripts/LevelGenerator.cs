using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelGenerator : MonoBehaviour
{

    [SerializeField]
    private Transform[] PlatformTransforms;
    [SerializeField]
    private Transform StartPlatform;
    [SerializeField]
    private GameObject Player;

    private float distanceFromPlayerToSpawnNextPlatformPart = 200f;

    private Vector3 lastEndPosition;

    private void Awake()
    {
        lastEndPosition = StartPlatform.Find("EndPoint").position;
    }

    private void SpawnPlatform()
    {
        Transform previousPlatformEnd = SpawnPlatformPart(lastEndPosition);
        
        lastEndPosition = previousPlatformEnd.Find("EndPoint").position;
    }

    private Transform SpawnPlatformPart(Vector3 spawnPosition)
    {

        return Instantiate(PlatformTransforms[UnityEngine.Random.Range(0, PlatformTransforms.Length)], spawnPosition, Quaternion.identity);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // spawn when distance of the player reduces
        if(Vector3.Distance(Player.transform.position,lastEndPosition) < distanceFromPlayerToSpawnNextPlatformPart)
        {
            SpawnPlatform();
        }
    }
}
