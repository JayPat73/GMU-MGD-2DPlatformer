using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollectableInstanceCheck : MonoBehaviour
{
    private static CollectableInstanceCheck instance;

    public static CollectableInstanceCheck Instance
    {
        get { return instance; }
    }

    private void Start()
    {
        if (SceneManager.GetActiveScene().name != "Level1")
        {
            Destroy(gameObject);
        }
    }

    private void Awake()
    {
        
        // If no Player ever existed, we are it.
        if (instance == null)
            instance = this;
        // If one already exist, it's because it came from another level.
        else if (instance != this)
        {
            Destroy(gameObject);
            return;
        }
    }

}
