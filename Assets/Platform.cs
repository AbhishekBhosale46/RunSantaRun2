using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

    public GameObject gift ,gift2, gift3;
    public GameObject rock;
    public GameObject snow;
    public GameObject tree;

    // Start is called before the first frame update
    void Start()
    {
       
        // Spwanning of Rock
        int rockRand = Random.Range(1, 101);
        Vector3 tempPos = transform.position;
        tempPos.y += 0.8f;

        if (rockRand < 21)
        {
            if(rockRand % 2 == 0)
            {
                tempPos.x -= 1.1f;
                Instantiate(rock, tempPos, rock.transform.rotation);
            }
        }
        else if(20 < rockRand && rockRand < 41)
        {
            if (rockRand % 2 == 0)
            {
                tempPos.x += 1.1f;
                Instantiate(rock, tempPos, rock.transform.rotation);
            }
        }
        else if (40 < rockRand && rockRand < 61)
        {
            if (rockRand % 2 == 0)
            {
                tempPos.z += 1f;
                tempPos.x -= 1.1f;
                Instantiate(rock, tempPos, rock.transform.rotation);
            }
        }
        else if (60 < rockRand && rockRand < 81)
        {
            if (rockRand % 2 == 0)
            {
                tempPos.z -= 1f;
                tempPos.x += 1.1f;
                Instantiate(rock, tempPos, rock.transform.rotation);
            }
        }
        else if (80 < rockRand && rockRand < 101)
        {
            if (rockRand % 2 == 0)
            {
                Instantiate(rock, tempPos, rock.transform.rotation);
            }
        }


        // Spwanning of Gifts
        int giftRand = Random.Range(1, 41);
        Vector3 giftPos = transform.position;
        giftPos.y += 0.8f;

        // Generate random gift
        GameObject tempGift = gift;
        int colorRand = Random.Range(1, 4);
        if(colorRand == 1)
        {
            tempGift = gift;
        }
        else if (colorRand == 2)
        {
            tempGift = gift2;
        }
        else if (colorRand == 3)
        {
            tempGift = gift3;
        }

        // Determine position
        if (giftRand < 11)
        {
            if (giftRand % 1 == 0)
            {
                giftPos.x -= 1.1f;
                giftPos.z += 1.1f;
                Instantiate(tempGift, giftPos, tempGift.transform.rotation);
            }
        }
        else if (10 < giftRand && giftRand < 21)
        {
            if (giftRand % 1 == 0)
            {
                giftPos.x += 1.1f;
                giftPos.z += 1.1f;
                Instantiate(tempGift, giftPos, tempGift.transform.rotation);
            }
        }
        else if (20 < giftRand && giftRand < 31)
        {
            if (giftRand % 1 == 0)
            {
                giftPos.x -= 1.1f;
                giftPos.z -= 1.1f;
                Instantiate(tempGift, giftPos, tempGift.transform.rotation);
            }
        }
        else if (30 < giftRand && giftRand < 41)
        {
            if (giftRand % 1 == 0)
            {
                giftPos.x += 1.1f;
                giftPos.z -= 1.1f;
                Instantiate(tempGift, giftPos, tempGift.transform.rotation);
            }
        }


        //Spwanning of snowFall
        Vector3 snowPos = transform.position;
        snowPos.y += 13f;
        Instantiate(snow, snowPos, Quaternion.identity);


        //Spwanning of Trees
        int treeRand = Random.Range(1, 10);
        Vector3 treePos = transform.position;
        
        if(treeRand%6 == 0)
        {
            treePos.y += 0.8f;
            treePos.x += 2.5f;
            Instantiate(tree, treePos, Quaternion.identity);
        }
        else if(treeRand%5 == 0)
        {
            treePos.y += 0.8f;
            treePos.x -= 2.5f;
            Instantiate(tree, treePos, Quaternion.identity);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            //Speed at which the plat will be destroyed after collision
            Invoke("destroyPlat", 3f);
        }
    }*/

    void destroyPlat()
    {
        Destroy(gameObject, 0.5f);
    }
}
