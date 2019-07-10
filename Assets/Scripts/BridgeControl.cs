using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeControl : MonoBehaviour {

    public Sprite Full, Most, Half, Quater, Break;
    private int SpriteIndex = 5;
    public void DamageTaken()
    {
        SpriteIndex--;
        switch (SpriteIndex)
        {
            case 4:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = Most;
                break;
            case 3:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = Half;
                break;
            case 2:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = Quater;
                break;
            case 1:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = Break;
                Destroy(gameObject);
                break;
            
        }

    }


}
