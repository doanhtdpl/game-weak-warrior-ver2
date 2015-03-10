using UnityEngine;
using System.Collections;

public class DestroyByTime : MonoBehaviour {

	// Use this for initialization
    public float timeDestroy;

	void Start () {
        Destroy(gameObject, timeDestroy);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
