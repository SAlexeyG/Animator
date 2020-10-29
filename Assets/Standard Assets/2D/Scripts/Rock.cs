using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rock : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject
            .GetComponent<UnityStandardAssets._2D.Platformer2DUserControl>())
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
