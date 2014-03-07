using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    private Vector2 player_position;
    float speed = 500;
    Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        MovePlayer();
	}

    enum Direction { down, up }
    Direction dir;

    void MovePlayer()
    {
        player_position = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        rigidbody2D.AddForce(player_position*speed);
        
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
           anim.SetInteger("direction", 1);
           dir=Direction.up;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            anim.SetInteger("direction", 0);
            dir=Direction.down;
        }
        else if (Input.anyKey == false)
        {
            if(dir == Direction.up)
                anim.SetInteger("direction", 3);
            else if(dir == Direction.down)
                anim.SetInteger("direction", 2);
        }
        
       
    }
}
