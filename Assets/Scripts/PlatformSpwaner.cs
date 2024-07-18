using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpwaner : MonoBehaviour
{

    public GameObject platform;     // Platform to spawn(prefab)
    public Transform lastPlatform;  // To determine last platform
    Vector3 lastPos;                // To save last position
    Vector3 newPos;                 // To save updated position
    public bool stop;               // To stop the spwaning

    // Start is called before the first frame update
    void Start()
    {
        // Initially determine the last position
        lastPos = lastPlatform.position;

        // Start the coroutine to spawn platforms
        StartCoroutine(SpawnPlatforms());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GeneratePosition()
    {

        // Set the new position
        newPos = lastPos;

        // Generate random integer
        int ran = Random.Range(0, 2);

        // Update the new position
        if (ran > 0)
        {
            newPos.z = newPos.z + 6f;
        }
        else
        {
            newPos.x = newPos.x - 6f;
        }

    }

    IEnumerator SpawnPlatforms()
    {
        while (!stop)
        {
            GeneratePosition();

            // Spawn the actual platform with updated position
            Instantiate(platform, newPos, Quaternion.identity);

            // Update the last position
            lastPos = newPos;

            yield return new WaitForSeconds(0.85f);
        }
    }
}
