using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBlock : MonoBehaviour {

    public bool isThere;
    
    public void DoorCheck()
    {
        if (!isThere)
        {
            gameObject.SetActive(false);
        }
    }
    private void Update()
    {
        DoorCheck();
    }

}
