using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject activeplanet;
    public GameObject playercontrol;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        activeplanet = playercontrol.GetComponent<PlayerController>().planet;
        if (activeplanet != null)
        {
            float xpos = activeplanet.transform.position.x;
            float ypos = activeplanet.transform.position.y;
            Vector3 campos = new Vector3(xpos, ypos, -10);
            transform.position = campos;
        }
    }
}
