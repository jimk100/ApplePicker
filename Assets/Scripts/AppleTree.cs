using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    public GameObject applePrefab;
    public float speed=10f;
    public float leftAndRightEdge=50f;
    public float chanceToChangeDirections=0.05f;
    public float secondsBetweenAppleDrops=1f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating ("DropApple",2f,secondsBetweenAppleDrops);
    }

     void DropApple() {

        GameObject apple = Instantiate(applePrefab)as GameObject ;
        apple.transform.position = transform.position ;

    }

    // Update is called once per frame
    void Update()
    {
        //Basic movement
        Vector3 pos=transform.position;
        pos.x +=speed*Time.deltaTime;
        transform.position=pos;
        //change direction
        if (pos.x<-leftAndRightEdge){
            speed = Mathf.Abs(speed);       
        }else if (pos.x>leftAndRightEdge){
            speed=-Mathf.Abs(speed);//Moveleft
        }
    }
        void FixedUpdate(){
        if (Random.value<chanceToChangeDirections){
            speed *=-1;//change directions
        }
    }
}
