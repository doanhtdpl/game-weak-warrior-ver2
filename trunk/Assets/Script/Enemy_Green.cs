using UnityEngine;
using System.Collections;

public class Enemy_Green : Enemy {

    public float speed;
    private bool isLeft;
    private Animator animator;
    public RuntimeAnimatorController RAnimator;
    public GameObject destroyEnemy;
    public GameObject effect_Blood;

    //private GameObject player;

    public bool attack;
    public float timeAttack;
    private float attackRate;
    public float timeWaitAttack;
    private float attackWaitRate;
    private bool isCollis = false;//kiem tra xem da va cham vs chien binh chua
    // Use this for initialization
    void Start()
    {

        Vector3 pos = this.transform.localPosition;
        float posX = pos.x;
        if (posX < 0)
            isLeft = true;
        else
        {
            isLeft = false;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }


        animator = GetComponent<Animator>();
        animator.runtimeAnimatorController = RAnimator;
        SetAttack(false);
        attackRate = timeAttack;
        attackWaitRate = timeWaitAttack;

        //player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void FixedUpdate()
    {
        if (attack)
        {
            attackRate -= Time.deltaTime;
            if (attackRate < 0)
            {
                attack = false;
                attackRate = timeAttack;
                Attack();
            }
        }
        else
        {
            if (isCollis)
            {
                attackWaitRate -= Time.deltaTime;
                if (attackWaitRate < 0)
                {
                    attack = true;
                    attackWaitRate = timeWaitAttack;
                }
            }
        }

        SetAttack(attack);
    }

    private void SetAttack(bool attack)
    {
        animator.SetBool(Animator.StringToHash("acttack"), attack);
    }

    public override void Move()
    {
        if (isLeft)
        {
            //cong vs speed
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
        player.GetComponent<PlayerController>().IsAttack();

    }

    public override void IsAttack()
    {
        Instantiate(destroyEnemy, gameObject.transform.position, gameObject.transform.rotation);
        Instantiate(effect_Blood, gameObject.transform.position, gameObject.transform.rotation);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            speed = 0;
            attack = true;
            isCollis = true;
        }
        if (other.tag == "PlayerAttack")
        {
            Debug.Log("va cham vs box");

            Destroy(gameObject);
            IsAttack();
        }
    }

}
