using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour {
    public static UIScript instance;
    public Text healthText, qAbilityText, eAbilityText, shiftText;


    private void Awake() {
        instance = this;
    }

    // Start is called before the first frame update
    void Start(){
        qAbilityText.text = "Q: " + Player.qAbility;
        eAbilityText.text = "E: " + Player.eAbility;
        shiftText.text = "Shift: " + Player.shift;
        
    }

    // Update is called once per frame
    void Update(){
        //same code from up above that way theres no need to update it in the player class
        healthText.text = "HP: " + Player.health + "/100";
        qAbilityText.text = "Q: " + Player.qAbility + "    " + Player.publicDamageCooldown + " s";
        eAbilityText.text = "E: " + Player.eAbility + "    " + Player.publicInvincibilityCooldown + " s";
        shiftText.text = "Shift: " + Player.shift + "    " + Player.publicTeleportCooldown + " s";

    }
}
