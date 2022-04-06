using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    //When trigger collider is entered. 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If the tag is equal to "Hero"
        if (collision.gameObject.tag == "Hero")
        {
            //Commit it to local memory
            PlayerPrefs.SetFloat("Health",ParentPlayer.health);
            //Call the complete level method. 
            CompleteLevel();
        }
    }

    //Will be called when the player is completed. 
    private void CompleteLevel()
    {
        //If the scene is not even
        if (SceneManager.GetActiveScene().buildIndex % 2 == 1)
        {
            //Returns the index of the scene if it is not even value. 
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        } //If the scene is even.
        else if (SceneManager.GetActiveScene().buildIndex % 2 == 0)
        {
            //Returns the index if it is an even value
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }
}
