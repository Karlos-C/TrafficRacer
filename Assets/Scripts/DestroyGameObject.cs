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
            Debug.LogError("Aucune Directional Light trouv�e dans la sc�ne !");
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
            Debug.Log("Le soleil dispara�t !");
        }
    }
}