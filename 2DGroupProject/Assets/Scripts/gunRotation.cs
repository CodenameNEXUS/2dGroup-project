using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunRotation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //rotation
        Vector3 mousePOS = Input.mousePosition;
        mousePOS.z = 5.23f;

        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
        mousePOS.y = mousePOS.y - objectPos.y;
        mousePOS.x = mousePOS.x - objectPos.x;

        float angle = Mathf.Atan2(mousePOS.y, mousePOS.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle)); ;
    }
}
