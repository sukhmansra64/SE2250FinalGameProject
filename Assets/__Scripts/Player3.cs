using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player3 : ParentPlayer {
    // Start is called before the first frame update
    void Awake() {

        //initializes player health and damage
        playerHealth = 140;
        playerDamage = 25;
        maxHealth = 140;

        //initializes the cooldowns so that all abilities are available off spawn
        teleportCooldown = 0;
        damageBoostCooldown = 0;
        healthResetCooldown = 1000000;
        invincibilityCooldown = 0;

        //initializes the speed of the player
        speed = 2;

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


            //handles player attack
            if (Time.time >= nextAttackTime) {
                if (Input.GetKeyDown(KeyCode.Space)) {
                    Attack();
                    nextAttackTime = Time.time + 1f / attackRate;
                }
            }

            if (Input.GetKeyDown(KeyCode.B)) {
                Fire(left);
            }

            //moves the player
            Move(horizontal, vertical);

            //handles player animation
            Animation(horizontal, vertical);

            //code used for player teleporting
            if (Input.GetKeyDown(KeyCode.LeftShift)) {
                Teleport(horizontal, vertical);
            }

        }


        //code used for invincibility
        if (Input.GetKeyDown(KeyCode.E)) {
            playerHealthBeforeInvincibility = playerHealth;
            Invincibility();
        }

        //code used for activating a damage boost
        if (Input.GetKeyDown(KeyCode.Q)) {
            DamageBoost();
        }

        //code for testing death
        if (Input.GetKeyDown(KeyCode.P)) {
            Die();
        }

        //after 30 seconds invincibility ends
        if (healthResetCooldown <= 0) {
            HealthReset(playerHealthBeforeInvincibility);
        }

        //cooldown handling
        teleportCooldown -= Time.deltaTime;
        invincibilityCooldown -= Time.deltaTime;
        healthResetCooldown -= Time.deltaTime;
        damageBoostCooldown -= Time.deltaTime;
    }
    //resets the game and re-initializes everything
    protected override void Reset() {
        SceneManager.LoadScene("_Scene_1");
        playerHealth = 140;
        damageBoostCooldown = 0;
        healthResetCooldown = 100000;
        invincibilityCooldown = 0;
        teleportCooldown = 0;
    }
}
