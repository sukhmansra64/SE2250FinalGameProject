using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour {
    public static UIScript instance;
    public Text healthText, qAbilityText, eAbilityText, shiftText, levelText;


    private void Awake() {
        instance = this;
    }

    // Start is called before the first frame update
    void Start(){
        qAbilityText.text = "Q: " + Player1.qAbility;
        eAbilityText.text = "E: " + Player1.eAbility;
        shiftText.text = "Shift: " + Player1.shift;

        if (SceneManager.GetActiveScene().Equals(SceneManager.GetSceneByName("_Scene_1")) || SceneManager.GetActiveScene().Equals(SceneManager.GetSceneByName("_Scene_2"))) {

            levelText.text = "Level: 1";
        }
        else {
            levelText.text = "Level: 2";
        }

    }

    // Update is called once per frame
    void Update(){
        //same code from up above that way theres no need to update it in the player class
        healthText.text = "HP: " + Player1.health + "/" + Player1.maxHealth;
        qAbilityText.text = "Q: " + Player1.qAbility + "    " + Player1.publicDamageCooldown + " s";
        eAbilityText.text = "E: " + Player1.eAbility + "    " + Player1.publicInvincibilityCooldown + " s";
        shiftText.text = "Shift: " + Player1.shift + "    " + Player1.publicTeleportCooldown + " s";
    }
}
