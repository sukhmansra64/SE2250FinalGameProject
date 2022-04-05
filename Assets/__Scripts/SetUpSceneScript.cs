using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetUpSceneScript : MonoBehaviour
{
    public string player;
    public GameObject Swordsman;
    public GameObject Knight;
    public GameObject Gino;

    // Start is called before the first frame update
    void Awake()
    {
        player = PlayerPrefs.GetString("Hero");
        switch (player){
            case "Swordsman":
                Instantiate(Swordsman);
                if(PlayerPrefs.GetFloat("Health")>0){
                    ParentPlayer.health = PlayerPrefs.GetFloat("Health");
                }
                break;

            case "Knight":
                Instantiate(Knight);
                if(PlayerPrefs.GetFloat("Health")>0){
                    ParentPlayer.health = PlayerPrefs.GetFloat("Health");
                }
                break;

            case "Gino":
                Instantiate(Gino);
                if(PlayerPrefs.GetFloat("Health")>0){
                    ParentPlayer.health = PlayerPrefs.GetFloat("Health");
                }
                break;
        }
    }
}
