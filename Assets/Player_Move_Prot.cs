using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move_Prot : MonoBehaviour { 

    public int player_speed = 10;
    private bool facing_right = false;
    public int player_jump_power = 1250;
    private float move_x;

    // Update is called once per frame
    void Update()
    {
        Player_Move();
    }

    void Player_Move()
    {
        //Controls
        move_x = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
        //Animation
        //Player Direction

        if (move_x < 0.0f && facing_right == false)
        {
            Flip_Player();
        }
        else if (move_x > 0.0f && facing_right == true)
        {
            Flip_Player();
        }
        //Physics
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(move_x * player_speed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }

    void Jump()
    {
        //Jumping Code
        GetComponent<Rigidbody2D>().AddForce (Vector2.up * player_jump_power);
    }

    void Flip_Player()
    {
        facing_right = !facing_right;
        Vector2 local_scale = gameObject.transform.localScale;
        local_scale.x *= -1;
        transform.localScale = local_scale;
    }
}
