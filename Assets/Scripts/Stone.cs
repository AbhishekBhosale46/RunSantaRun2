using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (gameObject.tag == "Stone")
            {
                GameManager.instance.GameOver();
                Time.timeScale = 0;
            }
        }
    }

    //To destroy object
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Destroyer")
        {
            Invoke("DestroyStone", 1f);
        }
    }

    //To destroy object
    void DestroyStone()
    {
        Destroy(gameObject, 1f);
    }

}
