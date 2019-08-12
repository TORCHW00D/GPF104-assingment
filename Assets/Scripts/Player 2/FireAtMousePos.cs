using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAtMousePos : MonoBehaviour
{
    //raycast and lazer things
    public float DamagePerShot = 10f;
    public Transform FirePoint;
    private Vector3 MPOSHOLD;
    private Vector2 MousePos;

    public Vector3 testV = Vector3.zero;
    public LineRenderer line;


    //mouse vars
    private Vector3 mouse_pos;
    public Transform Target;
    private Vector3 object_pos;
    private float angle;


    // Update is called once per frame
    void LateUpdate()
    {
         
        MPOSHOLD = new Vector3(Input.mousePosition.x,Input.mousePosition.y,Camera.main.nearClipPlane);
        testV = Camera.main.ScreenToWorldPoint(MPOSHOLD);

        //MousePos = new Vector2(MPOSHOLD.x, MPOSHOLD.y);

        LookAtMyMouse();
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(Shoot());
        }

    }

    void LookAtMyMouse() {
        mouse_pos = Input.mousePosition;
        mouse_pos.z = 0;
        object_pos = Camera.main.WorldToScreenPoint(Target.position);
        mouse_pos.x = mouse_pos.x - object_pos.x;
        mouse_pos.y = mouse_pos.y - object_pos.y;
        angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
        angle = angle - 180.0f;
        transform.rotation = (Quaternion.Euler(new Vector3(0, 0, angle)));

    }

    IEnumerator Shoot()
    {
        RaycastHit2D HitInfo = Physics2D.Raycast(FirePoint.position, (testV - FirePoint.position),100f);

        Debug.DrawRay(FirePoint.position, (testV - FirePoint.position),Color.red);

        if (HitInfo)
        {
            line.SetPosition(0, FirePoint.position);
            line.SetPosition(1, testV);
            EnemyScript EnemyScript = HitInfo.transform.GetComponent<EnemyScript>();
            if (EnemyScript != null)
            {
                EnemyScript.TakeDamage(DamagePerShot);
            }
        }
        else
        {
            line.SetPosition(0, FirePoint.position);
            line.SetPosition(1, testV);

        }
        if (HitInfo)
        {
            if (HitInfo.transform.tag == "Destructable")
            {
                Debug.Log("Hit");
                BridgeControl damagable = HitInfo.transform.GetComponent<BridgeControl>();
                damagable.DamageTaken();
            }
        }
        line.enabled = true;
        yield return new WaitForSeconds(0.02f);
        line.enabled = false;
        //if (HitInfo)
        //{
        //    Debug.Log(HitInfo.transform.name);
        //}

    }
}
