using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour {
    //variable declarations for the text, score, and message
    public static UIScript instance;
    public Text scoreText, healthText, qAbilityText, eAbilityText, shiftText, levelText, helpText, bottomText;
    public static int score;
    public static string message;

    // Awake is called when the script instance is being loaded
    private void Awake() {
        instance = this;
    }

    // Start is called before the first frame update
    void Start(){
        //sets the text of qAbilityText, eAbilityText, and shiftText to their respective abilities
        qAbilityText.text = "Q: " + ParentPlayer.qAbility;
        eAbilityText.text = "E: " + ParentPlayer.eAbility;
        shiftText.text = "Shift: " + ParentPlayer.shift;

        //if scene 1 or 2 is active the bottom text will be updated to say level 1 and that the player needs to collect 200 points to advance to the next level
        if (this.gameObject.scene.name == "_Scene_1" || this.gameObject.scene.name == "_Scene_2") {

            //sets the levelText to Level: 1, and sets the bottomText to Collect 200 points to advance to the next level
            levelText.text = "Level: 1";
            bottomText.text = "Collect 200 points to advance to the next level";
        }

        //if the active scene is 3 then the level text is updated to display level 2
        else if(this.gameObject.scene.name == "_Scene_3") {
            levelText.text = "Level: 2";
        }

        //if the active scene is 4 then the level text is updated to display level 2 and the bottom text is updated to say Destroy all enemies to rescue the parrot!
        else if (this.gameObject.scene.name == "_Scene_4") {
            levelText.text = "Level: 2";
            bottomText.text = "Destroy all enemies to rescue the parrot!";
        }

    }

    // Update is called once per frame
    void Update(){
        //sets the scoreText to display the number of points the player has
        scoreText.text = "Points: " + score;

        //if the player's health is above 0 it displays their health, otherwise it displays 0 that way there is no negatives
        if(ParentPlayer.health > 0) {
            healthText.text = "HP: " + ParentPlayer.health + "/" + ParentPlayer.maxHealth;
        }
        else {
            healthText.text = "HP: 0/" + ParentPlayer.maxHealth;
        }

        //if message isnt "" then it will set helpText to the message and then after 2 seconds it will delete it
        if (message != "") {
            helpText.text = message;
            Invoke("deleteMiddleText", 2f);
        }

        //sets the text of qAbilityText, eAbilityText, and shiftText to their respective abilities, as well as displaying their cooldowns
        qAbilityText.text = "Q: " + ParentPlayer.qAbility + "    " + ParentPlayer.publicDamageCooldown + " s";
        eAbilityText.text = "E: " + ParentPlayer.eAbility + "    " + ParentPlayer.publicInvincibilityCooldown + " s";
        shiftText.text = "Shift: " + ParentPlayer.shift + "    " + ParentPlayer.publicTeleportCooldown + " s";
    }

    //method to delete the helpText, sets the message to "" that way it doesnt run again
    void deleteMiddleText() {
        message = "";
        helpText.text = "";
    }
}
