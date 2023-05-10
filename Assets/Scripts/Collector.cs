using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collector : MonoBehaviour
{
    GameObject mainCube;
    public Animator m_animator;
    public GameObject ParticleEffect;
    int height;
    int cumScore;
    float time;
    void Start()
    {
        mainCube = GameObject.Find("mainCube");
    }

    // Update is called once per frame
    void Update()
    {
        mainCube.transform.position = new Vector3(transform.position.x, height + 1, transform.position.z);
        this.transform.localPosition = new Vector3(0, -height, 0);
    }
    public void inscreaseHeight()
    {
        height--;
        Debug.Log("height increased"+height);
    }
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Cube" && other.gameObject.GetComponent<Cube>().getCollected() == false)
        {
            m_animator.SetTrigger("isJumpp");
            height +=1;
            other.gameObject.GetComponent<Cube>().setCollected();
            other.gameObject.GetComponent<Cube>().setIndex(height);
            other.gameObject.transform.parent = mainCube.transform;
            Debug.Log("height decreased"+height+"  "+time);
            
        }
        if(other.gameObject.tag == "Finnish")
        {
            cumScore += height;
            FindObjectOfType<CharacterController>().forwardSpeed = 0;
            ParticleEffect.GetComponent<ParticleSystem>().Play();
            Invoke("loadScenewDelay", 2f);
        }
    }

    public int getHigh()
    {
        return height;
    }
    public int getCumScore()
    {
        return cumScore;
    }
    
    void loadScenewDelay()
    {
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            SceneManager.LoadScene("Level2");
        }
        if (SceneManager.GetActiveScene().name == "Level2")
        {
            SceneManager.LoadScene("Level3");
        }
        if (SceneManager.GetActiveScene().name == "Level3")
        {
            SceneManager.LoadScene("Level1");
        }
    }
}
