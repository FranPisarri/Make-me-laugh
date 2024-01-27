using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fight : MonoBehaviour
{
    [SerializeField] Animation attackAnimation;
    [SerializeField] GameObject duck;
    
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            //Animación de ataque
            //Animación de recibir golpe del pato
        }
    }
}
