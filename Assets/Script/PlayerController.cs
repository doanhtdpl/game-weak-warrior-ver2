using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    
    //public Animato

    private Animator animator;

    public StatePlayer statePlayer;

    public bool attack;
    public float timeAttack;
    private float attackRate;

    public GameObject destroy_LegArmor;
    public GameObject destroy_ShoulderArmor;
    //mau
    public int HP;

    public GameObject right;

    public RuntimeAnimatorController[] listState;

	// Use this for initialization
	void Start () {
	    //Animator
        animator = GetComponent<Animator>();

        animator.runtimeAnimatorController = listState[(int)statePlayer];

        SetAttack(false);
        attackRate = timeAttack;
        right.SetActive(false);
        
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            attack = true;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            Vector3 scale = transform.localScale;
            if (scale.x > 0)
            {
                scale.x = -scale.x;
                transform.localScale = scale;
            }
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            Vector3 scale = transform.localScale;
            if (scale.x < 0)
            {
                scale.x = -scale.x;
                transform.localScale = scale;
            }
        }
            
        if(attack)
            attackRate -= Time.deltaTime;
        if (attackRate < 0)
        {
            attack = false;
            attackRate = timeAttack;
        }
        SetAttack(attack);
	}

    private void SetAttack(bool attack)
    {
        animator.SetBool(Animator.StringToHash("acttack"), attack);
        Attack();
    }

    public void Attack()
    {
        right.SetActive(attack);
       
    }

    public  void IsAttack()
    {
        //Giam mau
        HP--;
        switch (HP)
        {
            case 0:
                //chet
                DestroyObject(gameObject);
                break;
            case 10:
                //chuyen trang thai cua chien binh
                animator.runtimeAnimatorController = listState[1];

                Instantiate(destroy_LegArmor, gameObject.transform.position, gameObject.transform.rotation);
                break;
            case 11:
                //chuyen trang thai cua chien binh
                animator.runtimeAnimatorController = listState[2];

                Instantiate(destroy_ShoulderArmor, gameObject.transform.position, gameObject.transform.rotation);
                break;
        }

    }

    public void AttackMiss()
    {
        Debug.Log("Miss roi! ");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //if (other.tag == "Enemy")
        //{
        //    if (other.GetComponent<Animator>().GetBool(Animator.StringToHash("acttack")))
        //    {
        //        Debug.Log("Bi tan cong");
        //        IsAttack();
        //    }
        //}

    }
}
