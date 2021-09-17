using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    [SerializeField] public string nameOfGameObject;
    // Start is called before the first frame update
    public void Awake()
    {
        DontDestroyOnLoad(this);
        
    }


}
