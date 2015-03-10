using UnityEngine;
using System.Collections;

public abstract class Enemy : MonoBehaviour {

    public abstract void Move();
    public abstract void Attack();
    public abstract void IsAttack();
}
