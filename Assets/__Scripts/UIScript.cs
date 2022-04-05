using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour {
    public static UIScript instance;
    public Text scoreText, healthText, qAbilityText, eAbilityText, shiftText, levelText, helpText, bottomText;
    public static int score;
    public static string message;


    private void Awake() {
        instance = this;
    }

    // Start is called before the first frame update
    void Start(){
        qAbilityText.text = "Q: " + ParentPlayer.qAbility;
        eAbilityText.text = "E: " + ParentPlayer.eAbility;
        shiftText.text = "Shift: " + ParentPlayer.shift;

        if (this.gameObject.scene.name == "_Scene_1" || this.gameObject.scene.name == "_Scene_2") {

            levelText.text = "Level: 1";
            bottomText.text = "Collect 200 points to advance to the next level";
        }

        else if(this.gameObject.scene.name == "_Scene_3") {
            levelText.text = "Level: 2";
        }

        else if (this.gameObject.scene.name == "_Scene_4") {
            levelText.text = "Level: 2";
            bottomText.text = "Destroy all enemies to rescue the parrot!";
        }

    }

    // Update is called once per frame
    void Update(){
        //same code from up above that way theres no need to update it in the player class
        scoreText.text = "Points: " + score;

        if(ParentPlayer.health > 0) {
            healthText.text = "HP: " + ParentPlayer.health + "/" + ParentPlayer.maxHealth;
        }
        else {
            healthText.text = "HP: 0/" + ParentPlayer.maxHealth;
        }

        if (message != "") {
            helpText.text = message;
            Invoke("deleteMiddleText", 2f);
        }


        qAbilityText.text = "Q: " + ParentPlayer.qAbility + "    " + ParentPlayer.publicDamageCooldown + " s";
        eAbilityText.text = "E: " + ParentPlayer.eAbility + "    " + ParentPlayer.publicInvincibilityCooldown + " s";
        shiftText.text = "Shift: " + ParentPlayer.shift + "    " + ParentPlayer.publicTeleportCooldown + " s";
    }

    void deleteMiddleText() {
        message = "";
        helpText.text = "";
    }
}
