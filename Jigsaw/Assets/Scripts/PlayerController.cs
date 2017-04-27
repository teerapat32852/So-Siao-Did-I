using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float accel;
    public float maxSpeed;
    public bool canMove;
    public GameObject interact;
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
            Vector3 v = rigid.velocity;
            v.x = 0;
            v.y = 0;
            v.z = 0;
            rigid.velocity = v;
            anim.SetFloat("speed", Mathf.Abs(rigid.velocity.x));
            return;
        }
        float i = Input.GetAxis("Horizontal");
        anim.SetFloat("speed", Mathf.Abs(rigid.velocity.x));
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
            interact.transform.localScale = new Vector3(.4f, .4f, 1);
        }
        if (rigid.velocity.x < 0)
        {
            transform.localScale = new Vector3(-2f, 2f, 2f);
            interact.transform.localScale = new Vector3(-.4f, .4f, 1);
        }
    }
}
