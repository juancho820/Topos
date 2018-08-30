using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public Text score;
    public Text TiempoText;
    public Text FinalScore;

    public bool noMasMonedas;

    public Text Highscore;
    private int highscore;

    private int scoreCoins;

    private float tiempo = 40;

    public GameObject Win;

    private RaycastHit hit;
    private Ray Ray;

    public static GameManager Instance { set; get; }

    // Use this for initialization
    void Start () {
        Time.timeScale = 1;
        Instance = this;
        score.text = "Puntaje: " + scoreCoins.ToString("0");
        TiempoText.text = "Segundos: " + tiempo.ToString("0");
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
                    if(noMasMonedas == false)
                    {
                        hit.collider.GetComponent<Topos>().tocado = true;
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
            Time.timeScale = 0;
            tiempo = 0;
            Win.SetActive(true);
            FinalScore.text = "Puntaje Final: " + scoreCoins.ToString("0");

            highscore = PlayerPrefs.GetInt("highscore");
            Highscore.text = "Maximo Puntaje: " + highscore.ToString("0");

            if (scoreCoins > highscore)
            {
                highscore = scoreCoins;
                Highscore.text = "Maximo Puntaje: " + highscore.ToString("0");

                PlayerPrefs.SetInt("highscore", highscore);
            }
        }
    }
    public void GetCoin()
    {
        scoreCoins++;
        score.text = "Puntaje: " + scoreCoins.ToString("0");
    }

    public void Resetiar()
    {
        SceneManager.LoadScene("AR");
    }
}
