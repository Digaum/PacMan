using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMove : MonoBehaviour {

    public Transform[] destinoGeral;
    int cont = 0;

    public int posicaoChegou;

    public float speed = 0.3f;

    SpriteRenderer m_SpriteRenderer;


    void Start()
    {
        //Fetch the SpriteRenderer from the GameObject
        //m_SpriteRenderer = GetComponent<SpriteRenderer>();
        //Set the GameObject's Color quickly to a set Color (blue)
        //m_SpriteRenderer.color = Color.blue;
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        if (transform.position != destinoGeral[cont].position)
        {
            Vector2 p = Vector2.MoveTowards(transform.position, destinoGeral[cont].position, speed);
            GetComponent<Rigidbody2D>().MovePosition(p);

        }
        else
        {
            cont++;

            if (cont == destinoGeral.Length)
            {
                cont = 0;
            }
        }


        Vector2 dir = destinoGeral[cont].position - transform.position;
        GetComponent<Animator>().SetFloat("DirX", dir.x);
        GetComponent<Animator>().SetFloat("DirX", dir.y);

    }

    void OnTriggerEnter2D(Collider2D co)
    {
        if (co.name == "pacman")
        {
            Destroy(co.gameObject);
        }
    }
}
