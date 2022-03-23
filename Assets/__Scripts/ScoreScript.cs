using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    //initiallizes the score text object and a integer value for the score
    //which can be used by all other scripts 
    public GameObject ScoreText;
    public static int score;

    // Start is called before the first frame update
    void Awake()
    {
        if(this.gameObject.scene.name == "_Scene_2"){
        score = 15;
        }
        if(this.gameObject.scene.name == "_Scene_1"){
        score = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.GetComponent<Text>().text = "Score: "+score;
    }
}
