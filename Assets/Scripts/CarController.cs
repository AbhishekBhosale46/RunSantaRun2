using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{

    public float speed;
    bool faceLeft = true;

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isStarted)
        {
            CheckInput();
            Move();
        }

        if(transform.position.y <= -2)
        {
            GameManager.instance.GameOver();
        }

        // Increase speed
        if(GameManager.instance.score%50 == 0)
        {
            speed += 0.03f;
        }

    }

    void Move()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    void ChangeDir()
    {
        if (faceLeft)
        {
            faceLeft = false;
            transform.rotation = Quaternion.Euler(0, -90, 0);
        }
        else
        {
            faceLeft = true;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    void CheckInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ChangeDir();
        }

    }

}
