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
        //add code to make it so that it retrieves the health variable, and the chosen abilities from the player class
        //then do something like:
        //healthText.setText = "HP: " + playerClass.getHealth();
        //set up properties in the player class
        
    }

    // Update is called once per frame
    void Update()
    {
        //same code from up above that way theres no need to update it in the player class
    }
}
