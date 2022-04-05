using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ParentPlayer : MonoBehaviour{
    //variable declarations
    public GameObject player;
    protected int playerDamage;
    public static int maxHealth;
    protected float speed;
    protected static float teleportCooldown, invincibilityCooldown, healthResetCooldown, damageBoostCooldown;   //might need to undo static and private
    protected static float playerHealth, playerHealthBeforeInvincibility;
    protected float attackRange;
    protected float attackRate, shootRate = 1f;
    protected float nextAttackTime, nextShootTime;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public Transform attackPoint;
    public LayerMask enemyLayers;
    public bool isDead = false;
    public GameObject projectilePrefab;
    public GameObject throwableProjectilePrefab;
    public GameObject daggerPrefab;
    public bool left;
    public float projectileSpeed = 20f;
    public Transform LaunchOffset;
    
    public int rangedAbility = 1;

    //temporary variable that will need to be implemented in the children
    protected static string qAbilityPress = "Damage Boost", eAbilityPress = "Invincibility", shiftPress = "Teleport";
    
    //movement method
    protected void Move(float horizontal, float vertical) {

        //change the position of the player
        transform.position = transform.position + new Vector3(horizontal * speed * Time.deltaTime, vertical * speed * Time.deltaTime, 0);
    }
    
    //handles player animation
    protected void Animation(float horizontal, float vertical) {
        if (horizontal != 0 || vertical != 0) {
            animator.SetFloat("Speed", 1);
        }
        else {
            animator.SetFloat("Speed", 0);
        }
        if (horizontal < 0) {
            spriteRenderer.flipX = true;
            left = true;
        }
        if (horizontal > 0) {
            spriteRenderer.flipX = false;
            left = false;
        }
    }

    //attack method
    protected void Attack(){

        animator.SetTrigger("Attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies) {
            enemy.GetComponent<EnemyScript>().TakeDamage(playerDamage);
        }
    }

    protected void useRangedAbility(bool left)
    {
        if (PlayerPrefs.GetString("Ranged") == "Gun")
        {
            Fire(left, projectilePrefab);
        }
        else if (PlayerPrefs.GetString("Ranged") == "Bomb")
        {
            Fire(left, throwableProjectilePrefab);
        }
        else if (rangedAbility == 3)
        {
            //Add the method call here to do grappling hook
        }
    }

    protected void useMeleeAbility(bool left)
    {
        if (PlayerPrefs.GetString("Attack") == "Slash")
        {
            Attack();
        }
        else if (PlayerPrefs.GetString("Attack") == "Stab") 
        {
            Stab(left, daggerPrefab);
        }
    }
    protected void Fire(bool left, GameObject rangedAbility)
    {
        GameObject projGO = Instantiate<GameObject>(rangedAbility);
        projGO.transform.position = transform.position;
        Rigidbody2D rigidB = projGO.GetComponent<Rigidbody2D>();


        //Change this later depending on whether or not the enemy is facing the hero
        if (!left)
        {         
            rigidB.velocity = Vector3.right * projectileSpeed;
        }
        else
        {
            rigidB.velocity = Vector3.left * projectileSpeed;
        }
    }

    protected void Stab(bool left, GameObject meleeAbility)
    {
        GameObject stabGO = Instantiate<GameObject>(meleeAbility);
        stabGO.transform.position = transform.position;
        Rigidbody2D rigidB = stabGO.GetComponent<Rigidbody2D>();

        if (!left)
        {
            rigidB.velocity = Vector3.right * projectileSpeed;
        }
        else
        {
            rigidB.velocity = Vector3.left * projectileSpeed;
        }
    }

    //teleport method
    protected void Teleport(float horizontal, float vertical) {

        //teleports the player if the cooldown is gone
        if (teleportCooldown <= 0) {
            teleportCooldown = 10;
            transform.position = transform.position + new Vector3(horizontal * 5f, vertical * 5f, 0f);
        }
    }

    //invincibility method
    protected void Invincibility() {

        if (invincibilityCooldown <= 0) {
            //sets the invincibility cooldown to 3 minutes and makes the player invincible, after 30 seconds invincibility will end
            healthResetCooldown = 15;
            invincibilityCooldown = 180;
            playerHealth = 10000;
        }
    }

    //resets health after invincibility ends
    protected void HealthReset(float health) {

       //resets the player's health to before invincibility, and then sets the cooldown to infinity, as not to activate the method again 
       playerHealth = health;
       healthResetCooldown = 1000000;
    }

    //damage boost method
    protected void DamageBoost() {

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

    //method to handle collisions
    protected void OnCollisionEnter2D(Collision2D collision) {

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

        if (collision.gameObject.tag == "Eagle") {

            TakeDamage(50);
        }

        if (collision.gameObject.tag == "EnemyProjectile")
        {
            Destroy(collision.gameObject);
            TakeDamage(20);
        }

        if(collision.gameObject.tag == "Heart") {
            Destroy(collision.gameObject);
            playerHealth = maxHealth;
        }

        if (collision.gameObject.tag == "Parrot")
        {
            Destroy(collision.gameObject);
            SceneManager.LoadScene("_EndingStory");
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
    protected void Die() {
        isDead = true;
        //player death animation
        animator.SetTrigger("Death");
        switch (PlayerPrefs.GetString("Hero"))
        {
            case "Knight":
                PlayerPrefs.SetFloat("Health",100f);
                playerHealth = 100;
                break;
            case "Swordsman":
                PlayerPrefs.SetFloat("Health",150f);
                playerHealth = 150;
                break;
            case "Gino":
                PlayerPrefs.SetFloat("Health",80f);
                playerHealth = 80;
                break;
            default:
                PlayerPrefs.SetFloat("Health",100f);
                playerHealth = 100;
                break;
        }
        //resets the game when the player dies
        Invoke("Reset", 1.3f);

    }

    //resets the game and re-initializes everything
    protected virtual void Reset() {
        
        SceneManager.LoadScene("_Scene_1");
        damageBoostCooldown = 0;
        healthResetCooldown = 100000;
        invincibilityCooldown = 0;
        teleportCooldown = 0;
        UIScript.score = 0;
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
