using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SceneLoader))]
public class GoalL1Anim : MonoBehaviour
{
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            anim.SetBool("didFinish", true);
            collision.gameObject.GetComponent<Player>().enabled = false;
            StartCoroutine(Hold());
        }
                
        
    }

    public IEnumerator Hold()
    {
        yield return new WaitForSeconds(5f);
        this.GetComponent<SceneLoader>().loadScene(6);
    }
}
