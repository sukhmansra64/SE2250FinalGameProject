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
                break;

            case "Knight":
                Instantiate(Knight);
                break;

            case "Gino":
                Instantiate(Gino);
                break;
        }
    }
}
