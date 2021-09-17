using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;




public class DeadlyObstacle : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponentInChildren<SpriteRenderer>().enabled = false;
            collision.gameObject.GetComponent<Player>().enabled = false;
            ScoreManager.scoreManagerInstance.score -= 25;
            ScoreManager.scoreManagerInstance.scoreText.text = ScoreManager.scoreManagerInstance.score.ToString();

            StartCoroutine(Hold());
            
        }
    }
    public IEnumerator Hold()
    {
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
