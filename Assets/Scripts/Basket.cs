using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{   public TextMesh scoreGT;
    // Start is called before the first frame update
    void Start()
    {
        //Find a reference to scoreCounter GameObject
        GameObject scoreGO=GameObject.Find("ScoreCounter");
        //get the GUIText component of the GameObject
        scoreGT=scoreGO.GetComponent<TextMesh>();
        //set the starting number of points to 0
        scoreGT.text="0";
    }

    // Update is called once per frame
    void Update()
    {  //get current screen position from mouse to input
        Vector3 mousePos2D=Input.mousePosition;

        //camera's position sets hte how far to push the mouse into 3d
        mousePos2D.z=-Camera.main.transform.position.z;

        //convert the point from 2D screen space into 3D game world space
        Vector3  mousePos3D=Camera.main.ScreenToWorldPoint(mousePos2D);

        //move the x position of this basket to the x position of the mouse
        Vector3 pos=this.transform.position;
        pos.x=mousePos3D.x;
        this.transform.position=pos;
        
    }
        void OnCollisionEnter(Collision coll){
            //Find out what hit this basket
            GameObject collidedWith=coll.gameObject;
            if (collidedWith.tag=="Apple"){
                Destroy(collidedWith);

                //parse the text of the scoreGT into an int
                int score=int.Parse(scoreGT.text);
                //Add points for cathing the  Apple
                score+=100;
                scoreGT.text=score.ToString();
            } 
        }
}
