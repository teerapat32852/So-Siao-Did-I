using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float accel;
    public float maxSpeed;
    public bool canMove;
    private Animator anim;
    private Rigidbody2D rigid;
	// Use this for initialization
	void Start () {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        
    }
    void FixedUpdate()
    {
        if(!canMove)
        {
            return;
        }
        float i = Input.GetAxis("Horizontal");
        anim.SetFloat("speed", Mathf.Abs(Input.GetAxis("Horizontal")));
        rigid.AddForce(Vector2.right * accel * i);
        if (rigid.velocity.x >= maxSpeed)
        {
            rigid.velocity = new Vector2(maxSpeed,rigid.velocity.y);
        }
        if (rigid.velocity.x <= -maxSpeed)
        {
            rigid.velocity = new Vector2(-maxSpeed, rigid.velocity.y);
        }
        if ( rigid.velocity.x>0)
        {
            transform.localScale = new Vector3(2f, 2f, 2f);
        }
        if (rigid.velocity.x < 0)
        {
            transform.localScale = new Vector3(-2f, 2f, 2f);
        }
    }
}
