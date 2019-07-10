using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallaxing : MonoBehaviour {

    public Transform[] Backgrounds; //holds images for background elements
    private float[] parallaxScales; //how far the objects move
    public float smoothing = 1; //how smooth bakground movement is (always above 0)

    private Transform cam;
    private Vector3 PrevCamPos;
    // Use this for initialization

    private void Awake() //runs before start but after game objects exist
    {
        cam = Camera.main.transform;
    }

    void Start () {
        PrevCamPos = cam.position;
        parallaxScales = new float[Backgrounds.Length];
        for (int i = 0; i < Backgrounds.Length; i++)
        {
            parallaxScales[i] = Backgrounds[i].position.z;
        }
	}
	
	// Update is called once per frame
	void Update () {
		for(int i = 0; i < Backgrounds.Length; i++)
        {
            float parallax = (PrevCamPos.x - cam.position.x) * parallaxScales[i];
            float backgroundTargetPosX = Backgrounds[i].position.x + parallax;

            Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX, Backgrounds[i].position.y, Backgrounds[i].position.z);

            //move the background using LERP!!
            Backgrounds[i].position = Vector3.Lerp(Backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);
        }

        PrevCamPos = cam.position;
	}
}
