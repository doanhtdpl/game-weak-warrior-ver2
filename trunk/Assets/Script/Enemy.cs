using UnityEngine;
using System.Collections;

public abstract class Enemy : MonoBehaviour {
    public GameObject player;

    public abstract void Move();
    public abstract void Attack();
    public abstract void IsAttack();
}
