using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PortalEnter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision gameObjectInformation){
        if(gameObjectInformation.gameObject.name=="SCIENTIST_MODEL"){
            Debug.Log("Collision is there");
            SceneManager.LoadScene("Open World");
        }
    }
}
