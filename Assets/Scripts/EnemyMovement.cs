using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;

    Rigidbody2D rb2d;
    void Awake() {
        rb2d = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if(IsFacingRight()){
            rb2d.velocity = new Vector2(moveSpeed, 0f);

        } else {
            rb2d.velocity = new Vector2(-moveSpeed, 0f);
        }
    }
    
    private bool IsFacingRight(){
        return transform.localScale.x > Mathf.Epsilon;
    }
    private void OnTriggerExit2D(Collider2D other) {
        transform.localScale = new Vector2(-(Mathf.Sign(rb2d.velocity.x)), transform.localScale.y);
    }
}
