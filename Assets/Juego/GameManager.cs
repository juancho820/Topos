using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public Text score;
    private int scoreCoins;
    private int random;
    private float esperar;
    public bool tocado1, tocado2, tocado3, tocado4, tocado5, tocado6, tocado7, tocado8, tocado9;

    public GameObject Topo1, Topo2, Topo3, Topo4, Topo5, Topo6, Topo7, Topo8, Topo9;

    public static GameManager Instance { set; get; }

    // Use this for initialization
    void Start () {
        Instance = this;
        esperar = 4;
        score.text = "Score: " + scoreCoins.ToString("0");
        StartCoroutine(RandomSelect(esperar));
    }
	
	// Update is called once per frame
	void Update () {

    }
    public void Animar()
    {
        float random2 = Random.Range(0.5f, 3.0f);
        switch (random)
        {
            case 1:
                Topo1.GetComponent<Animator>().SetTrigger("Subir");
                Invoke("Bajar", random2);
                break;
            case 2:
                Topo2.GetComponent<Animator>().SetTrigger("Subir");
                Invoke("Bajar", random2);
                break;
            case 3:
                Topo3.GetComponent<Animator>().SetTrigger("Subir");
                Invoke("Bajar", random2);
                break;
            case 4:
                Topo4.GetComponent<Animator>().SetTrigger("Subir");
                Invoke("Bajar", random2);
                break;
            case 5:
                Topo5.GetComponent<Animator>().SetTrigger("Subir");
                Invoke("Bajar", random2);
                break;
            case 6:
                Topo6.GetComponent<Animator>().SetTrigger("Subir");
                Invoke("Bajar", random2);
                break;
            case 7:
                Topo7.GetComponent<Animator>().SetTrigger("Subir");
                Invoke("Bajar", random2);
                break;
            case 8:
                Topo8.GetComponent<Animator>().SetTrigger("Subir");
                Invoke("Bajar", random2);
                break;
            case 9:
                Topo9.GetComponent<Animator>().SetTrigger("Subir");
                Invoke("Bajar", random2);
                break;
        }
    }

    public void Bajar()
    {
        switch (random)
        {
            case 1:
                Topo1.GetComponent<Animator>().SetTrigger("Bajar");
                break;
            case 2:
                Topo2.GetComponent<Animator>().SetTrigger("Bajar");
                break;
            case 3:
                Topo3.GetComponent<Animator>().SetTrigger("Bajar");
                break;
            case 4:
                Topo4.GetComponent<Animator>().SetTrigger("Bajar");
                break;
            case 5:
                Topo5.GetComponent<Animator>().SetTrigger("Bajar");
                break;
            case 6:
                Topo6.GetComponent<Animator>().SetTrigger("Bajar");
                break;
            case 7:
                Topo7.GetComponent<Animator>().SetTrigger("Bajar");
                break;
            case 8:
                Topo8.GetComponent<Animator>().SetTrigger("Bajar");
                break;
            case 9:
                Topo9.GetComponent<Animator>().SetTrigger("Bajar");
                break;
        }
    }

    public void GetCoin()
    {
        scoreCoins++;
        score.text = "Score: " + scoreCoins.ToString("0");
    }

    public void Resetiar()
    {
        SceneManager.LoadScene("AR");
    }

    IEnumerator RandomSelect(float Wait)
    {
        random = Random.Range(1, 10);
        Animar();
        yield return new WaitForSeconds(Wait);
        StartCoroutine(RandomSelect(esperar));
    }

}
