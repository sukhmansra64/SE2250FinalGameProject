using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour {
    public static UIScript instance;
    public Text scoreText, healthText, qAbilityText, eAbilityText, shiftText, levelText;
    public static int score;


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
        }
        else {
            levelText.text = "Level: 2";
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

        qAbilityText.text = "Q: " + ParentPlayer.qAbility + "    " + ParentPlayer.publicDamageCooldown + " s";
        eAbilityText.text = "E: " + ParentPlayer.eAbility + "    " + ParentPlayer.publicInvincibilityCooldown + " s";
        shiftText.text = "Shift: " + ParentPlayer.shift + "    " + ParentPlayer.publicTeleportCooldown + " s";
    }
}
