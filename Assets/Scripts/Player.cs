using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    #region variables
    private Vector2 player_position;
    float speed = 500;
    Animator anim;
    enum Direction { down, up, down_idle, up_idle, left, right, left_idle, right_idle };
    Direction dir;
    #endregion

    // Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        MovePlayer();
	}

    

    void MovePlayer()
    {
        player_position = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        rigidbody2D.AddForce(player_position*speed);
        
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
           anim.SetInteger("direction", (int)Direction.up);
           dir=Direction.up;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            anim.SetInteger("direction", (int)Direction.down);
            dir=Direction.down;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            anim.SetInteger("direction", (int)Direction.left);
            dir = Direction.left;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
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
