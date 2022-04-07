using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject startplanet;
    [System.NonSerialized] public GameObject planet;
    Rigidbody2D rb;
    public float force;
    bool reset = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        planet = startplanet;
        transform.parent = planet.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (reset)
        {            
            StartCoroutine(Spritereset());
            reset = false;
        }
        if (planet != null )
        {
            if (Input.GetKeyDown("space"))
            {
                transform.parent = null;
                planet = null;
                rb.AddForce(transform.TransformDirection(Vector3.up)  * force * 50 );
                this.gameObject.transform.GetChild(1).gameObject.SetActive(false);
            }


        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        transform.position = collision.transform.position + new Vector3(0, collision.transform.localScale.y * (7 / 10), 0);
        planet = collision.gameObject;
        transform.localRotation = Quaternion.Euler(0, 0, 0);
        transform.parent = collision.transform;
        this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        
        reset = true;
    }

    
    IEnumerator Spritereset() 
    {
        yield return new WaitForSeconds(1f);
        this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        this.gameObject.transform.GetChild(1).gameObject.SetActive(true);

    }

    public void Restart()
    {
        planet = startplanet;
        transform.position = planet.transform.position + new Vector3(0, planet.transform.localScale.y * (7 / 10), 0);
    }
}
