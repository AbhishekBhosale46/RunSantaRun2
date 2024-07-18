using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMov : MonoBehaviour
{

    public Transform target;
    Vector3 distance;
    public float camSpeed;

    [SerializeField] [Range(0f, 1f)] float lerpTime;
    [SerializeField] Color[] colors;
    int colorIndex = 0;
    float change = 0f;
    int len;

    // Start is called before the first frame update
    void Start()
    {
        distance = target.position - transform.position;
        len = colors.Length;
    }

    // Update is called once per frame
    void Update()
    {
        if(target.position.y >= 0)
        {
            Follow();
        }

        // Change color
        Camera.main.backgroundColor = Color.Lerp(Camera.main.backgroundColor, colors[colorIndex], lerpTime * Time.deltaTime);
        change = Mathf.Lerp(change, 1f, lerpTime * Time.deltaTime);
        if (change > 0.9f)
        {
            change = 0f;
            colorIndex++;
            colorIndex = (colorIndex >= len) ? 0 : colorIndex;
        }

    }

    void Follow()
    {
        Vector3 currentPos = transform.position;
        Vector3 targetPos = target.position - distance;

        transform.position = Vector3.Lerp(currentPos, targetPos, camSpeed * Time.deltaTime);

    }
}
