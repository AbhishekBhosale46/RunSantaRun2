using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //To destroy object
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Destroyer")
        {
            Destroy(gameObject, 1f);
        }
    }

}
