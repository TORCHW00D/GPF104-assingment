using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseReticle : MonoBehaviour {
    Vector3 MousePos;
	// Use this for initialization
	void Start () {
        UnityEngine.Cursor.visible = false;
    }
	
	// Update is called once per frame
	void Update () {
        MousePos = (Camera.main.ScreenToWorldPoint(Input.mousePosition));
        this.transform.position = new Vector3(MousePos.x, MousePos.y, 0) ;
	}
}
