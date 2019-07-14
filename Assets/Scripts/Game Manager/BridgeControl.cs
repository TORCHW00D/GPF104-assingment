using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeControl : MonoBehaviour {

    public Sprite Full, Half, Broken;
    private int SpriteIndex = 5;
    public void DamageTaken()
    {
        SpriteIndex--;
        switch (SpriteIndex)
        {
            case 4:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = Half;
                break;
            case 3:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = Broken;
                Destroy(gameObject, 6f);
                break;
            
        }

    }


}
