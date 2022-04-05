using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetUpSceneScript : MonoBehaviour
{
    public string player;
    public GameObject Swordsman;
    public GameObject Knight;
    public GameObject Gino;
    public Scene Scene;
    public string SceneName;

    // Start is called before the first frame update
    void Awake()
    {
        Scene = SceneManager.GetActiveScene();
        SceneName = Scene.name;
        player = PlayerPrefs.GetString("Hero");
        switch (player){
            case "Swordsman":
                Instantiate(Swordsman);
                if(PlayerPrefs.GetFloat("Health")>0){
                    ParentPlayer.health = PlayerPrefs.GetFloat("Health");
                }
                if(SceneName == "_Scene_3"){
                    ParentPlayer.health = ParentPlayer.maxHealth;
                }
                break;

            case "Knight":
                Instantiate(Knight);
                if(PlayerPrefs.GetFloat("Health")>0){
                    ParentPlayer.health = PlayerPrefs.GetFloat("Health");
                }
                if(SceneName == "_Scene_3"){
                    ParentPlayer.health = ParentPlayer.maxHealth;
                }
                break;

            case "Gino":
                Instantiate(Gino);
                if(PlayerPrefs.GetFloat("Health")>0){
                    ParentPlayer.health = PlayerPrefs.GetFloat("Health");
                }
                if(SceneName == "_Scene_3"){
                    ParentPlayer.health = ParentPlayer.maxHealth;
                }
                break;
        }
    }
}
