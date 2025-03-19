using System.Collections;
using UnityEngine;
using TMPro;

public class DestroyGameObject : MonoBehaviour
{
    int score = 0;

    [SerializeField] TMP_Text txtScore;
    private Light directionalLight;

    private void Start()
    {
        directionalLight = FindObjectOfType<Light>();

        if (directionalLight == null)
        {
            Debug.LogError("Aucune Directional Light trouvée dans la scène !");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
        score++;
        txtScore.text = "Score " + score;

        Debug.Log("Score actuel : " + score);

        if (score >= 10 && directionalLight != null)
        {
            Debug.Log("Le soleil disparaît !");
            StartCoroutine(DiminuerLumiere());
        }
    }

    IEnumerator DiminuerLumiere()
    {
        float duree = 3f;
        float temps = 0;
        float intensiteInitiale = directionalLight.intensity;

        while (temps < duree)
        {
            temps += Time.deltaTime;
            directionalLight.intensity = Mathf.Lerp(intensiteInitiale, 0, temps / duree);
            yield return null;
        }

        directionalLight.intensity = 0;
    }
}