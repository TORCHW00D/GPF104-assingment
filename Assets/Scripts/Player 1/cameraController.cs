using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public GameObject player;
    private float offset;


    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position.x - player.transform.position.x;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(player.transform.position.x + offset, gameObject.transform.position.y, gameObject.transform.position.z);
    }
}
