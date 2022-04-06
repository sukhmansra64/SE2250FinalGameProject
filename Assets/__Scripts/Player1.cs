using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player1 : ParentPlayer {

    // Awake is called when the script instance is being loaded
    void Awake() {

        //initializes player health depending on the scene
        if (this.gameObject.scene.name == "_Scene_1" || this.gameObject.scene.name == "_Scene_2") {
            playerHealth = 100;
            maxHealth = 100;
        }
        else {
            playerHealth = 150;
            maxHealth = 150;
        }

        //initializes player damage
        playerDamage = 30;

        //initializes the cooldowns so that all abilities are available off spawn
        teleportCooldown = 0;
        damageBoostCooldown = 0;
        healthResetCooldown = 1000000;
        invincibilityCooldown = 0;

        //initializes the speed of the player
        speed = 4;

        //initializes all of the attack specifics
        attackRange = 2.5f;
        attackRate = 2f;
        nextAttackTime = 0f;

        //initiliazes the player object for use in other scripts
        player = this.gameObject;
    }

    // Update is called once per frame
    void Update() {
        //variable declaration
        if (!isDead) {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            //handles player melee attack, if the time is greater than the next melee attack time then it will run
            if (Time.time >= nextAttackTime) {
                //if space has been pressed useMeleeAbility will run and the next attack time will be determined based off the attackRate
                if (Input.GetKeyDown(KeyCode.Space)) {
                    useMeleeAbility(left);
                    nextAttackTime = Time.time + 1f / attackRate;
                }
            }

            //handles player ranged attack, if the time is greater than the next ranged attack time then it will run
            if (Time.time >= nextShootTime) {
                //if B has been pressed useRangedAbility will run and the next ranged attack time will be determined based off the shootRate
                if (Input.GetKeyDown(KeyCode.B)) {
                    useRangedAbility(left);
                    nextShootTime = Time.time + 1f / shootRate;
                }
            }

            //moves the player by calling the parent Move method and passes in the variables horizontal and vertical
            Move(horizontal, vertical);

            //handles player animation by calling the parent Animation method and passes in the variables horizontal and vertical
            Animation(horizontal, vertical);

            //if the LeftShift key has been pressed the Teleport method will run and passes in the variables horizontal and vertical
            if (Input.GetKeyDown(KeyCode.LeftShift)) {
                Teleport(horizontal, vertical);
            }

        }

        //if the E key has been pressed the Invincibility method will run
        if (Input.GetKeyDown(KeyCode.E)) {
            playerHealthBeforeInvincibility = playerHealth;
            Invincibility();
        }

        //if the Q key has been pressed the DamageBoost method will run
        if (Input.GetKeyDown(KeyCode.Q)) {
            DamageBoost();
        }

        //after 15 seconds invincibility ends by calling the HealthReset method and passes in the player's health before invincibility was activated
        if (healthResetCooldown <= 0) {
            HealthReset(playerHealthBeforeInvincibility);
        }

        //cooldown handling
        teleportCooldown -= Time.deltaTime;
        invincibilityCooldown -= Time.deltaTime;
        healthResetCooldown -= Time.deltaTime;
        damageBoostCooldown -= Time.deltaTime;
    }
}
