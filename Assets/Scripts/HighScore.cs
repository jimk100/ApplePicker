using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{

    static public int score = 1000 ;

    // Start is called before the first frame update
    void Start()
    {
        
    }
void Awake() {

        if (PlayerPrefs.HasKey("ApplePickerHighScore")) {

            score = PlayerPrefs.GetInt("ApplePickerHighScore") ;

        }

        PlayerPrefs.SetInt("ApplePickerHighScore", score) ;

    }

    // Update is called once per frame
    void Update()
    {

        Text gt = this.GetComponent<Text>() ;
        gt.text = "HighScore:" + score.ToString() ;

        if (score > PlayerPrefs.GetInt("ApplePickerHighScore")) {

            PlayerPrefs.SetInt("ApplePickerHighScore", score) ;

        }
        
    }
}
