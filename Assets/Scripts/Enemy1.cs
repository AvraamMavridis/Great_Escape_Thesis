using UnityEngine;
using System.Collections;


public class Enemy1 : MonoBehaviour {

    private Vector2 screen_end_coordinates;
    private Vector2 screen_start_coordinates;
    int direction;
    Animator anim;

	// Use this for initialization
	void Start () {
        screen_end_coordinates = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        screen_start_coordinates = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        direction = 0;
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        MoveEnemy();
	}

    void MoveEnemy()
    {
       if (rigidbody2D.transform.position.x > screen_start_coordinates.x + 5 && direction==0) { 
            rigidbody2D.transform.position = new Vector2(rigidbody2D.transform.position.x - 0.15f, rigidbody2D.transform.position.y);
       }
       else if (rigidbody2D.transform.position.x < screen_start_coordinates.x + 5 && direction == 0)
       {
           direction = 1;
           anim.SetInteger("direction", 1);
           
       }
       else if (rigidbody2D.transform.position.x < screen_end_coordinates.x + 5 && direction == 1)
       {
           rigidbody2D.transform.position = new Vector2(rigidbody2D.transform.position.x + 0.15f, rigidbody2D.transform.position.y);
       }
       else if (rigidbody2D.transform.position.x > screen_end_coordinates.x + 5 && direction == 1)
       {
           direction = 0;
           anim.SetInteger("direction", 0);
       }

    }
}
