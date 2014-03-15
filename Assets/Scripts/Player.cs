using UnityEngine;
using System.Collections;
using System.IO.Pipes;
using System;


public class Player : MonoBehaviour
{
    #region variables
    private Vector2 player_position;
    float speed = 500;
    Animator anim;
    enum Direction { down, up, down_idle, up_idle, left, right, left_idle, right_idle };
    Direction dir;
    #endregion
    NamedPipeClientStream pipeClient;

    // Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
       
        
	}
	
	// Update is called once per frame
	void Update () {
        MovePlayer();
        //if (pipeClient.IsConnected)
        //{
        //    print("Client connected");
        //}
	}

    

    void MovePlayer()
    {

        //player_position = new Vector2(player_position.x, Input.GetAxis("Vertical"));
        //rigidbody2D.AddForce(player_position * speed);
        
        if (Input.GetKey(KeyCode.UpArrow))
        {
            

            player_position = new Vector2(0, Input.GetAxis("Vertical"));
            rigidbody2D.AddForce(player_position * speed);
            anim.SetInteger("direction", (int)Direction.up);
            dir=Direction.up;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            player_position = new Vector2(0, Input.GetAxis("Vertical"));
            rigidbody2D.AddForce(player_position * speed);
            anim.SetInteger("direction", (int)Direction.down);
            dir=Direction.down;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            player_position = new Vector2(Input.GetAxis("Horizontal"), 0 );
            rigidbody2D.AddForce(player_position * speed);
            anim.SetInteger("direction", (int)Direction.left);
            dir = Direction.left;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            player_position = new Vector2(Input.GetAxis("Horizontal"), 0);
            rigidbody2D.AddForce(player_position * speed);
            anim.SetInteger("direction", (int)Direction.right);
            dir = Direction.right;
        }
        else if (Input.anyKey == false)
        {
            if (dir == Direction.up)
                anim.SetInteger("direction", (int)Direction.up_idle);
            else if (dir == Direction.down)
                anim.SetInteger("direction", (int)Direction.down_idle);
            else if (dir == Direction.left)
                anim.SetInteger("direction", (int)Direction.left_idle);
            else if (dir == Direction.right)
                anim.SetInteger("direction", (int)Direction.right_idle);
        }
        
       
    }
}
