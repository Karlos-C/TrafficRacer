using TMPro;
using UnityEngine;

public class DestroyGameObject : MonoBehaviour
{
    int score = 0;

    [SerializeField] TMP_Text txtScore;

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject); 
        score++; 
        txtScore.text = "Score " + score; 

        Debug.Log("Score actuel : " + score);
    }
}