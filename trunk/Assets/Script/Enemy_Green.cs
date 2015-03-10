using UnityEngine;
using System.Collections;

public class Enemy_Green : Enemy {

    public float speed;
    public bool isLeft;
    private Animator animator;
    public RuntimeAnimatorController RAnimator;
    public GameObject destroyEnemy;

    // Use this for initialization
    void Start()
    {
        if(!isLeft)
        {
            Vector3 scale = this.transform.localScale;
            scale.x *= -1;
            this.transform.localScale = scale;
        }

        animator = GetComponent<Animator>();
        animator.runtimeAnimatorController = RAnimator;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void FixedUpdate()
    {

    }

    public override void Move()
    {
        if (isLeft)
        {
            //cong vs speed
            //this.transform.position.x += speed;
            Vector3 position = this.transform.position;
            position.x += (speed * Time.deltaTime) ;
            transform.position = position;
        }
        else
        {
            //c cong vs -speed
            Vector3 position = this.transform.position;
            position.x -= (speed * Time.deltaTime);
            transform.position = position;
        }
    }

    public override void Attack()
    {
        animator.SetBool(Animator.StringToHash("acttack"), true);  
    }

    public override void IsAttack()
    {
        Instantiate(destroyEnemy, gameObject.transform.position, gameObject.transform.rotation);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            speed = 0;
            Attack();
        }
        if (other.tag == "PlayerAttack")
        {
            Debug.Log("va cham vs box");

            Destroy(gameObject);
            IsAttack();
        }
    }

}
