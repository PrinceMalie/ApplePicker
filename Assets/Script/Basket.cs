using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    public ScoreCounter scoreCounter; 
    // Start is called before the first frame update
    void Start()
    {
        GameObject scoreGO = GameObject.Find("ScoreCounter");

        scoreCounter = scoreGO.GetComponent<ScoreCounter>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get the current screen position of the mouse from

        Vector3 mousePos2D = Input.mousePosition;

        // The Camera's z position sets how far to push the mouse into 3D

        // If this line causes a NullReferenceExeception, slect the main camera. 

        // In the Hierarchy and set its tag to MainCamera in the Inspector. 

        mousePos2D.z = -Camera.main.transform.position.z; 

        //Convert the point from 2D screeen space into 3D game world space

        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        //Move the x position of this Basket to the x position of the Mouse

        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos; 
    }

    void OnCollisionEnter(Collision coll)
    {
        GameObject collidedWith = coll.gameObject; 

        if ( collidedWith.CompareTag("Apple"))
        {
            Destroy(collidedWith );
            scoreCounter.score += 100;
            HighScore.TRY_SET_HIGH_SCORE(scoreCounter.score);
        }
    }
}
