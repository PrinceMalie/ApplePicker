using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    // Start is called before the first frame update

    [Header("Inscribed")]

    //Prefab for instantiating apples
    public GameObject applePrefab; 

    //speed at which the AppleTree moves
    public float speed = 1f;

    //distance where AppleTree turns around
    public float leftandRightEdge = 10f;

    // Chance that the AppleTree will change directions
    public float changeDirChance = 0.1f;

    // Seconds between Apple instantiations
    public float appleDropDelay = 1f; 
    void Start()
    {
        //Start dropping apples
        Invoke("DropApple", 2f);
    }

    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", appleDropDelay); 
    }

    // Update is called once per frame
    void Update()
    {
        // basic movement
        Vector3 pos = transform.position;

        pos.x += speed * Time.deltaTime;

        transform.position = pos;

        // Changing Direction

        if (pos.x < -leftandRightEdge)
        {
            speed = Mathf.Abs(speed); // move right
        }
        else if (pos.x > leftandRightEdge)
        {
            speed = -Mathf.Abs(speed); // move left
        } //else if ( Random.value < changeDriChance )
          // {
          //speed *= -1; //Changes direction 
          //}
    }
        
     void FixedUpdate()
    {
        if ( Random.value < changeDirChance)
            {
                speed *= -1; //Change direction 
            }
     }
}

