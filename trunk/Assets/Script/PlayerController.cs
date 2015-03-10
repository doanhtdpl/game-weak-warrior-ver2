using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    
    //public Animato

    private Animator animator;

    public StatePlayer statePlayer;

    public bool attack;
    public float timeAttack;
    private float attackRate;

    public GameObject right;
    private Collider2D[] frontHits;

    public RuntimeAnimatorController[] listState;

	// Use this for initialization
	void Start () {
	    //Animator
        animator = GetComponent<Animator>();

        animator.runtimeAnimatorController = listState[(int)statePlayer];

        SetAttack(false);
        attackRate = timeAttack;
        right.SetActive(false);
        //animator.con
	}
	
	// Update is called once per frame
	void FixedUpdate () {

       // frontHits = Physics2D.OverlapPointAll(ri)


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

    private void Attack()
    {
        //if(frontHits != null)
        //foreach (Collider2D c in frontHits)
        //{
        //    if(attack)
        //    if (c.tag == "Enemy")
        //    {
        //        Debug.Log("va cham vs enemy");
        //        Destroy(c.gameObject);
        //        frontHits = null;
        //    }
        //}
        
        right.SetActive(attack);
    }
}
