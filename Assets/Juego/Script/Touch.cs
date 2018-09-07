using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch : MonoBehaviour {

    Renderer rend;

    public static bool tocado;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        StartCoroutine(FadeTo(0.0f, 0.3f));
    }

    private void Update()
    {
        if(rend.material.color.a <= 0.05)
        {
            Color resetColor = new Color(1, 1, 1, 1);
            GetComponent<Renderer>().material.color = resetColor;
            gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {
        Color resetColor = new Color(1, 1, 1, 1);
        GetComponent<Renderer>().material.color = resetColor;
        StartCoroutine(FadeTo(0.0f, 0.3f));
    }

    IEnumerator FadeTo(float aValue, float aTime)
    {
        float alpha = rend.material.color.a;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha, aValue, t));
            GetComponent<Renderer>().material.color = newColor;
            yield return null;
        }
    }
}
