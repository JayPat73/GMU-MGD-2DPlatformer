using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableCoin : MonoBehaviour
{
    public int value = 100;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            ScoreManager.scoreManagerInstance.score += value;
            ScoreManager.scoreManagerInstance.scoreText.text = ScoreManager.scoreManagerInstance.score.ToString();
            //Destroy(this.gameObject);
            this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            this.gameObject.GetComponent<Animator>().enabled = false;
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
