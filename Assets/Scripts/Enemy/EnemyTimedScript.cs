using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTimedScript : MonoBehaviour {

	// Kill self in 10 seconds
	void Start () {
        Destroy(gameObject, 10.0f);
	}
}
