using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftPickup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0f, 90f, 0f) * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(gameObject.tag == "Gift")
            {
                GameManager.instance.GetGift();
                Destroy(gameObject);
            }

        }

        if (collision.gameObject.tag == "Destroyer")
        {
            Destroy(gameObject, 1f);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        
    }
}
