using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    //variable declarations
    public GameObject player;
    int playerDamage;
    float speed = 4;
    private static float teleportCooldown, invincibilityCooldown, healthResetCooldown, damageBoostCooldown;   //might need to undo static and private
    private static float playerHealth, playerHealthBeforeInvincibility;
    float attackRange = 1.2f;
    float attackRate = 2f;
    float nextAttackTime = 0f;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public Transform attackPoint;
    public LayerMask enemyLayers;
    public bool isDead = false;
    public GameObject projectilePrefab;
    public bool left;
    public float projectileSpeed = 20f;

    //temporary variable that will need to be implemented in the children
    private static string qAbilityPress = "Damage Boost", eAbilityPress = "Invincibility", shiftPress = "Teleport";

    // Awake is called when the script instance is being loaded
    void Awake() {

        //initializes player health and damage
        playerHealth = 100;
        playerDamage = 30;

        //initializes the cooldowns so that all abilities are available off spawn
        teleportCooldown = 0;
        damageBoostCooldown = 0;
        healthResetCooldown = 1000000;
        invincibilityCooldown = 0;

        //initiliazes the player object for use in other scripts
        player = this.gameObject;
    }

    // Update is called once per frame
    void Update() {
        //variable declaration
        if(!isDead){
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

        //handles player animation
        if(horizontal!=0||vertical!=0){
            animator.SetFloat("Speed",1);
        }else{
            animator.SetFloat("Speed",0);
        }
        if(horizontal<0){
            spriteRenderer.flipX=true;
            left=true;
        }
        if(horizontal>0){
            spriteRenderer.flipX=false;
            left=false;
        }

        //handles player attack
        if(Input.GetKeyDown(KeyCode.Space)){
            Attack();
        }

        if(Input.GetKeyDown(KeyCode.B)){
            Fire(left);
        }

        //moves the player
        Move(horizontal, vertical);

        //code used for player teleporting
        if (Input.GetKeyDown(KeyCode.LeftShift)) {
            Teleport(horizontal, vertical);
        }

        }
        if(Time.time >= nextAttackTime) {
            if (Input.GetKeyDown(KeyCode.Space)) {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
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
        if(Input.GetKeyDown(KeyCode.P)) {
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

    //movement method
    void Move(float horizontal, float vertical) {

        //change the position of the player
        transform.position = transform.position + new Vector3(horizontal * speed * Time.deltaTime, vertical * speed * Time.deltaTime, 0);
    }

    //attack method
    void Attack(){

        animator.SetTrigger("Attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies) {
            enemy.GetComponent<EnemyScript>().TakeDamage(playerDamage);
        }
    }

    void Fire(bool left)
    {
        GameObject projGO = Instantiate<GameObject>(projectilePrefab);
        projGO.transform.position = transform.position;
        Rigidbody2D rigidB = projGO.GetComponent<Rigidbody2D>();

        //Change this later depending on whether or not the enemy is facing the hero
        if (!left)
        {
            rigidB.velocity = Vector3.right * projectileSpeed;
        }
        else if (left)
        {
            rigidB.velocity = Vector3.left * projectileSpeed;
        }
    }

    //teleport method
    void Teleport(float horizontal, float vertical) {

        //teleports the player if the cooldown is gone
        if (teleportCooldown <= 0) {
            teleportCooldown = 10;
            transform.position = transform.position + new Vector3(horizontal * 5f, vertical * 5f, 0f);
        }
    }

    //invincibility method
    void Invincibility() {

        if (invincibilityCooldown <= 0) {
            //sets the invincibility cooldown to 3 minutes and makes the player invincible, after 30 seconds invincibility will end
            healthResetCooldown = 15;
            invincibilityCooldown = 180;
            playerHealth = 10000;
        }
    }

    //resets health after invincibility ends
    void HealthReset(float health) {

       //resets the player's health to before invincibility, and then sets the cooldown to infinity, as not to activate the method again 
       playerHealth = health;
       healthResetCooldown = 1000000;
    }

    //damage boost method
    void DamageBoost() {

        if (damageBoostCooldown <= 0) {
            //sets to cooldown to 2 minutes, doubles the players damage and after 15 seconds removes the damage boost
            damageBoostCooldown = 120;
            playerDamage = playerDamage * 2;
            Invoke("DamageReset", 15f);
        }
    }

    //resets the player's damage
    void DamageReset() {
        playerDamage = playerDamage / 2;
    }

    //method to handle collisions
    void OnCollisionEnter2D(Collision2D collision) {
        GameObject otherGO = collision.gameObject;
        //when picking up the screenWipe collectable it gives the player an ability to destroy all enemies on the screen
        if (collision.gameObject.tag == "screenWipe") {
            Destroy(collision.gameObject);
            this.GetComponent<CollectableNewSkill>().Activate();
        }

        if(collision.gameObject.tag == "Ghost") {
            TakeDamage(20);
        }

        if(collision.gameObject.tag == "Skeleton") {
            TakeDamage(25);
        }

        if (otherGO.tag == "EnemyProjectile")
        {
            Destroy(otherGO);
            TakeDamage(20);
        }
    }

    //method that executes when the player's takes damage
    public void TakeDamage(int damage) {
        playerHealth -= damage;

        if (playerHealth <= 0) {
            Die();
        }
    }

    //method that executes when the player's health reaches 0
    void Die() {
        isDead = true;
        //player death animation
        animator.SetTrigger("Death");

        //resets the game when the player dies
        Invoke("Reset", 1.3f);

    }

    //resets the game and re-initializes everything
<<<<<<< Updated upstream:Assets/__Scripts/Player.cs
    private void Reset() {
=======
    protected virtual void Reset() {
>>>>>>> Stashed changes:Assets/__Scripts/ParentPlayer.cs
        SceneManager.LoadScene("_Scene_1");
        playerHealth = 100;
        damageBoostCooldown = 0;
        healthResetCooldown = 100000;
        invincibilityCooldown = 0;
        teleportCooldown = 0;
    }

    //properties for the UI elements might have to change later
    public static float health {
        get {
            return playerHealth;
        }

        set {
            playerHealth = value;
        }
    }

    public static string qAbility {
        get {
            return qAbilityPress;
        }
        set {
            qAbilityPress = value;
        }
    }

    public static string eAbility {
        get {
            return eAbilityPress;
        }
        set {
            eAbilityPress = value;
        }
    }

    public static string shift {
        get {
            return shiftPress;
        }
        set {
            shiftPress = value;
        }
    }

    public static int publicDamageCooldown {
        get {
            if (damageBoostCooldown < 0) {
                return 0;
            }

            return (int)damageBoostCooldown;
        }
    }

    public static int publicTeleportCooldown {
        get {
            if(teleportCooldown < 0) {
                return 0;
            }
            return (int)teleportCooldown;
        }
    }

    public static int publicInvincibilityCooldown {
        get {
            if (invincibilityCooldown < 0) {
                return 0;
            }
            return (int)invincibilityCooldown;
        }
    }
}
