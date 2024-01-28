using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fight : MonoBehaviour
{
    [SerializeField] Animator attackAnimation;
    [SerializeField] GameObject lifeBar;
    [SerializeField] GameObject duck;
    [SerializeField] Sprite deathDuck;

    private int contador;
    private float escala;
    public float timer;
    private float time;
    
    void Start()
    {
        escala = 2;
        contador = 0;
        time = 0;
        
    }

    void Update()
    {
        time += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.F) && time > timer)
        {
            attackAnimation.SetInteger("Walk", 4);
            escala -= 0.1f;
            lifeBar.transform.localScale = new Vector2(escala, 0.3f);

            contador++;
            time = 0;
        }
        
        if (contador == 20)
        {
            duck.GetComponent<SpriteRenderer>().sprite = deathDuck;
            gameObject.GetComponentInChildren<Camera>().orthographicSize = 10;
            for (int i = 0; i < Inventory.Instance.cards.Length; i++)
            {
                if (!Inventory.Instance.cards[i])
                {
                    Inventory.Instance.cards[i] = true;
                    i = Inventory.Instance.cards.Length;
                }
            }

            gameObject.GetComponent<Movement_Player>().enabled = true;
            this.enabled = false;
        }
    }
}
