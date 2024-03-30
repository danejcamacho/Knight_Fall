using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float walkSpeed = 5f;
    [SerializeField] float attackDelay = 0.4f;
    float xAxis = 0 ;

    Rigidbody2D rb2d;
    Animator animator;

    bool isAttacking;
    bool isAttackPressed;
    string currentAnimation;

    public Transform attackPos;
    public float attackRange;
    public LayerMask whatIsEnemies;

    MainManager mainManager;
    public AudioClip swing;
    AudioSource audioSource;



    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        mainManager = FindObjectOfType<MainManager>();
        audioSource = FindObjectOfType<AudioSource>();
    }

    void Update()
    {
        xAxis = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space)){
            //attack
            isAttackPressed = true;
        }
    }

    

    private void FixedUpdate() {

        Vector2 vel = new Vector2(0, rb2d.velocity.y);

        if(xAxis < 0){
            vel.x = -walkSpeed;
            transform.localScale = new Vector2(1, 1);
        }
        else if (xAxis > 0){
            vel.x = walkSpeed;
            transform.localScale = new Vector2(-1,1);
        }
        else {
            vel.x = 0;
        }
        if(!isAttacking){
            if(xAxis != 0){
                ChangeAnimationState("player_walk");
            }else{
                ChangeAnimationState("player_idle");
            }
        }
        

        rb2d.velocity = vel;

        if(isAttackPressed){
            isAttackPressed = false;
            if(!isAttacking){
                isAttacking = true;
                ChangeAnimationState("player_attack");
                audioSource.PlayOneShot(swing, 0.25f);
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                for(int i = 0; i < enemiesToDamage.Length; i++){
                    enemiesToDamage[i].GetComponent<Enemy>().TakeDamage();
                }
            }
            Invoke("AttackComplete", attackDelay);
            
            
        }
    }
    
    void AttackComplete(){
        isAttacking = false;
    }

    void ChangeAnimationState(string newAnimation) {
        if (currentAnimation == newAnimation) return;
        animator.Play(newAnimation);
        currentAnimation = newAnimation;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Enemy"){
            mainManager.GameOver();
        }
            
    }
}
