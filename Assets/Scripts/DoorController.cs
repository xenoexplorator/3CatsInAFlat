using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour
{

    public string TargetScene;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void Interact(PlayerControllerScript player)
    {
        SceneManager.LoadScene(TargetScene);
        Vector3 positionNew = new Vector3(
            FindObjectOfType<DoorController>().transform.position.x, 
            FindObjectOfType<DoorController>().transform.position.y+1, 
            FindObjectOfType<DoorController>().transform.position.z);
        player.transform.position = positionNew;
    }
}
