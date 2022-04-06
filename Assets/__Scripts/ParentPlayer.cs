using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ParentPlayer : MonoBehaviour {
    //variable declarations for unity things
    public GameObject player, projectilePrefab, throwableProjectilePrefab, daggerPrefab;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public Transform attackPoint;
    public LayerMask enemyLayers;

    //variables for player traits
    protected int playerDamage;
    public static int maxHealth;
    protected float speed;
    protected static float teleportCooldown, invincibilityCooldown, healthResetCooldown, damageBoostCooldown;
    protected static float playerHealth, playerHealthBeforeInvincibility;

    //variables for attacking
    protected float attackRange;
    protected float attackRate, shootRate = 1f;
    protected float nextAttackTime, nextShootTime;
    public bool isDead = false;
    public bool left;
    public float projectileSpeed = 20f;

    //string variables used in the UI
    protected static string qAbilityPress = "Damage Boost", eAbilityPress = "Invincibility", shiftPress = "Teleport";

    //movement method, accepts the horizontal and vertical axis
    protected void Move(float horizontal, float vertical) {
        //change the position of the player by taking the current position and adding another vector that is dependant on the speed
        transform.position = transform.position + new Vector3(horizontal * speed * Time.deltaTime, vertical * speed * Time.deltaTime, 0);
    }

    //handles player animation  accepts the horizontal and vertical axis
    protected void Animation(float horizontal, float vertical) {
        //if the player is moving the animator triggers the walking animation
        if (horizontal != 0 || vertical != 0) {
            animator.SetFloat("Speed", 1);
        }
        else {
            animator.SetFloat("Speed", 0);
        }

        //if the player is looking left, the animator will make it so that the sprite is facing left
        if (horizontal < 0) {
            spriteRenderer.flipX = true;
            left = true;
        }

        //if the player is looking right, the animator will make it so that the sprite is facing right
        if (horizontal > 0) {
            spriteRenderer.flipX = false;
            left = false;
        }
    }

    //attack method for the player
    protected void Attack() {
        //sets the animators trigger to attack
        animator.SetTrigger("Attack");

        //creates an array of all the enemies that have been hit
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        //loops through the array and damages all the enmies in the array with the assigned playerDamage
        foreach (Collider2D enemy in hitEnemies) {
            enemy.GetComponent<EnemyScript>().TakeDamage(playerDamage);
        }
    }

    //allows the player to use their ranged ability
    protected void useRangedAbility(bool left) {
        //if the player chose Gun as their ranged ability it will shoot, and if the player chose a bomb as their ability it will throw a bomb
        if (PlayerPrefs.GetString("Ranged") == "Gun") {
            Fire(left, projectilePrefab);
        }
        else if (PlayerPrefs.GetString("Ranged") == "Bomb") {
            Fire(left, throwableProjectilePrefab);
        }
    }

    //allows the player to use their melee ability
    protected void useMeleeAbility(bool left) {
        //if the player chose slash as their melee ability it will do a slash, and if the player chose a stab as their ability it will stab
        if (PlayerPrefs.GetString("Attack") == "Slash") {
            Attack();
        }
        else if (PlayerPrefs.GetString("Attack") == "Stab") {
            Stab(left);
        }
    }

    //fire method that allows the player to shoot based on their ranged ability
    protected void Fire(bool left, GameObject rangedAbility) {

        //spawns the ranged ability at the player
        GameObject projGO = Instantiate(rangedAbility);
        projGO.transform.position = transform.position;
        Rigidbody2D rigidB = projGO.GetComponent<Rigidbody2D>();

        //depending on which way the player is facing fires the ranged ability
        if (!left) {
            rigidB.velocity = Vector3.right * projectileSpeed;
        }
        else {
            rigidB.velocity = Vector3.left * projectileSpeed;
        }
    }

    //stab method for the player
    protected void Stab(bool left) {

        //spawns the dagger at the player
        GameObject stabGO = Instantiate(daggerPrefab);
        stabGO.transform.position = transform.position;

        //depending on which way the player is facing transforms the dagger
        if (!left) {
            stabGO.transform.position = stabGO.transform.position + new Vector3(1, 0);
            stabGO.transform.rotation = new Quaternion(0f, 0f, 1f, 0.7071068f);
        }
        else {
            stabGO.transform.position = stabGO.transform.position + new Vector3(-1, 0);
            stabGO.transform.rotation = new Quaternion(0f, 0f, -1f, 0.7071068f);
        }

        //creates an array of all the enemies that have been hit
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(stabGO.transform.position, attackRange, enemyLayers);

        //loops through the array and damages all the enmies in the array with the assigned playerDamage
        foreach (Collider2D enemy in hitEnemies) {
            enemy.GetComponent<EnemyScript>().TakeDamage(playerDamage * 2);
        }

        //destroys the dagger after 0.5 seconds
        Destroy(stabGO, 0.1f);
    }

    //teleport method which teleports the character
    protected void Teleport(float horizontal, float vertical) {

        //teleports the player if the cooldown is gone
        if (teleportCooldown <= 0) {
            //sets the teleport cooldown to 10 seconds and teleports the character 5 units away
            teleportCooldown = 10;
            transform.position = transform.position + new Vector3(horizontal * 5f, vertical * 5f, 0f);
        }
    }

    //invincibility method which makes the character invincible
    protected void Invincibility() {

        //makes the character invincible if the cooldown is gone
        if (invincibilityCooldown <= 0) {
            //sets the invincibility cooldown to 3 minutes and makes the player invincible, after 30 seconds invincibility will end
            healthResetCooldown = 15;
            invincibilityCooldown = 180;
            playerHealth = 10000;
        }
    }

    //resets health to what the player had beforehand after invincibility ends
    protected void HealthReset(float health) {

        //resets the player's health to before invincibility, and then sets the cooldown to infinity, as not to activate the method again 
        playerHealth = health;
        healthResetCooldown = 1000000;
    }

    //damage boost method which doubles the player's damage
    protected void DamageBoost() {

        //if the cooldown is gone it will double the player's damage
        if (damageBoostCooldown <= 0) {
            //sets to cooldown to 2 minutes, doubles the players damage and after 15 seconds removes the damage boost
            damageBoostCooldown = 120;
            playerDamage = playerDamage * 2;
            Invoke("DamageReset", 15f);
        }
    }

    //resets the player's damage
    protected void DamageReset() {
        playerDamage = playerDamage / 2;
    }

    //method to handle collisions with the player
    protected void OnCollisionEnter2D(Collision2D collision) {

        //when picking up the screenWipe collectable it gives the player an ability to destroy all enemies on the screen
        if (collision.gameObject.tag == "screenWipe") {
            //destroys the collectable
            Destroy(collision.gameObject);
            this.GetComponent<CollectableNewSkill>().Activate();

            //displays text on screen to let the player know what they just picked up
            UIScript.message = ("Press Tab to destroy all enemies on screen");
        }

        //if the player collides with the ghost they will take 20 damage
        if (collision.gameObject.tag == "Ghost") {
            //calls the TakeDamage method and passes in 20
            TakeDamage(20);
        }

        //if the player collides with the skeleton they will take 20 damage
        if (collision.gameObject.tag == "Skeleton") {
            //calls the TakeDamage method and passes in 25
            TakeDamage(25);
        }

        //if the player collides with the eagle they will take 20 damage
        if (collision.gameObject.tag == "Eagle") {
            //calls the TakeDamage method and passes in 50
            TakeDamage(50);
        }

        //if the player collides with an enemy projectile they will take 20 damage
        if (collision.gameObject.tag == "EnemyProjectile") {
            //destroys the projectile and calls the TakeDamage method and passes in 20
            Destroy(collision.gameObject);
            TakeDamage(20);
        }

        //when the player picks up a heart collectable it will destroy the collectable and give the player max health
        if (collision.gameObject.tag == "Heart") {
            //destroys the heart pickup and gives the player max health
            Destroy(collision.gameObject);
            playerHealth = maxHealth;
        }

        //when the player picks up a diamond collectable it will destroy the collectable and give the player invincibility and reset the invincibility cooldown
        if (collision.gameObject.tag == "Invincibility") {
            //destroys the diamond pickup and gives the player invincibility
            Destroy(collision.gameObject);

            //sets the invincibility cooldown to -1 so invincibility can be used, stores the players health before invincibility, runs the method and resets the cooldown
            invincibilityCooldown = -1;
            playerHealthBeforeInvincibility = playerHealth;
            Invincibility();
            invincibilityCooldown = -1;
        }

        //when the player picks up the parrot it will destroy the pickup and the game end screen will display
        if (collision.gameObject.tag == "Parrot") {
            //destroys the collision
            Destroy(collision.gameObject);

            //loads the ending scene
            SceneManager.LoadScene("_EndingStory");
        }
    }

    //method that executes when the player's takes damage
    public void TakeDamage(int damage) {
        //reduces the players health based on the damage value passed in
        playerHealth -= damage;

        //if the player's health reaches 0 Die method will run
        if (playerHealth <= 0) {
            Die();
        }
    }

    //method that executes when the player's health reaches 0
    protected void Die() {
        isDead = true;
        //player death animation
        animator.SetTrigger("Death");

        //depending on the character chosen, will instantiate their health back to max
        switch (PlayerPrefs.GetString("Hero")) {
            case "Knight":
                PlayerPrefs.SetFloat("Health", 100f);
                playerHealth = 100;
                break;
            case "Swordsman":
                PlayerPrefs.SetFloat("Health", 150f);
                playerHealth = 150;
                break;
            case "Gino":
                PlayerPrefs.SetFloat("Health", 80f);
                playerHealth = 80;
                break;
            default:
                PlayerPrefs.SetFloat("Health", 100f);
                playerHealth = 100;
                break;
        }

        //resets the game when the player dies
        Invoke("Reset", 1.3f);
    }

    //resets the game and re-initializes everything
    protected virtual void Reset() {
        //loads the first scene, resets the cooldowns, and resets the score
        SceneManager.LoadScene("_Scene_1");
        damageBoostCooldown = 0;
        healthResetCooldown = 100000;
        invincibilityCooldown = 0;
        teleportCooldown = 0;
        UIScript.score = 0;
    }

    //properties for the UI elements
    //health property to access and set playerHealth
    public static float health {
        get {
            return playerHealth;
        }

        set {
            playerHealth = value;
        }
    }

    //qAbility property to access and set qAbilityPress
    public static string qAbility {
        get {
            return qAbilityPress;
        }
        set {
            qAbilityPress = value;
        }
    }

    //eAbility property to access and set eAbilityPress
    public static string eAbility {
        get {
            return eAbilityPress;
        }
        set {
            eAbilityPress = value;
        }
    }

    //shift property to access and set shiftPress
    public static string shift {
        get {
            return shiftPress;
        }
        set {
            shiftPress = value;
        }
    }

    //publicDamageCooldown property to access damageBoostCooldown
    public static int publicDamageCooldown {
        get {
            if (damageBoostCooldown < 0) {
                return 0;
            }

            return (int)damageBoostCooldown;
        }
    }

    //publicTeleportCooldown property to access teleportCooldown
    public static int publicTeleportCooldown {
        get {
            if (teleportCooldown < 0) {
                return 0;
            }
            return (int)teleportCooldown;
        }
    }

    //publicInvincibilityCooldown property to access invincibilityCooldown
    public static int publicInvincibilityCooldown {
        get {
            if (invincibilityCooldown < 0) {
                return 0;
            }
            return (int)invincibilityCooldown;
        }
    }
}
