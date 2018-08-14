using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public Text score;
    public Text TiempoText;
    public Text FinalScore;

    private int scoreCoins;
    private int random;

    private float esperar;
    private float tiempo = 40;

    public GameObject Win;
    public GameObject Topo1, Topo2, Topo3, Topo4, Topo5, Topo6, Topo7, Topo8, Topo9;

    private RaycastHit hit;
    private Ray Ray;

    public static GameManager Instance { set; get; }

    // Use this for initialization
    void Start () {
        Instance = this;
        esperar = 4;
        score.text = "Score: " + scoreCoins.ToString("0");
        TiempoText.text = "Segundos: " + tiempo.ToString("0");
        StartCoroutine(RandomSelect(esperar));
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.touchCount > 0 || Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            if (Physics.Raycast(Ray, out hit, Mathf.Infinity))
            {
                if(hit.transform.tag == "Enemy")
                {
                    if(Topos.tocado == false)
                    {
                        GetCoin();
                        Topos.tocado = true;
                    }
                }
            }
        }
    }

    private void FixedUpdate()
    {
        tiempo -= Time.fixedDeltaTime;
        TiempoText.text = "Segundos: " + tiempo.ToString("0");

        if(tiempo <= 0)
        {
            Win.SetActive(true);
            FinalScore.text = "Final Score: " + scoreCoins.ToString("0");
        }
    }

    public void Animar()
    {
        float random2 = Random.Range(0.5f, 2.5f);
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
