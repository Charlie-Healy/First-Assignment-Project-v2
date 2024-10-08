using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class DeathScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Respawn")
        {
            SceneManager.LoadScene("SampleScene");
        }
        if (other.gameObject.tag == "Enemy")
        {
            SceneManager.LoadScene("SampleScene");
        }

    }

}
