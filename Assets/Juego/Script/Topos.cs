using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Topos : MonoBehaviour {

    public bool subido;
    public bool tocado;
    
    private int random;
    private int random2;

    private float tiempo;



    public void Start()
    {
        RandomSelect();
    }

    public void Update()
    {
        tiempo += Time.deltaTime;
        if(tiempo >= random)
        {
            if(subido == false)
            {
                GetComponent<Animator>().SetTrigger("Subir");
                subido = true;
            }
            if(tocado == false)
            {
                if (tiempo >= random + random2)
                {
                    GetComponent<Animator>().SetTrigger("Bajar");
                    tiempo = 0;
                    RandomSelect();
                    subido = false;
                }
            }

        }
        if (tocado == true)
        {
            GameManager.Instance.noMasMonedas = true;
            GameManager.Instance.GetCoin();
            GetComponent<Animator>().SetTrigger("Bajar");
            tiempo = 0;
            RandomSelect();
            subido = false;
            tocado = false;
        }

    }

    public void Resetiar()
    {
        GameManager.Instance.noMasMonedas = false;
    }

    public void RandomSelect()
    {
        random = Random.Range(2, 10);
        random2 = Random.Range(1, 3);
    }
}
