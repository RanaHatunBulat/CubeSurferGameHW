using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cube : MonoBehaviour
{
    bool isCollected;
    int index;
    public Collector collector;
    public Animator m_animator;
    
    void Start()
    {
        isCollected = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isCollected == true)
        {
            if (transform.parent != null)
            {
                transform.localPosition = new Vector3(0, -index, 0);
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Block")
        {
            m_animator.SetTrigger("isFall");
            collector.inscreaseHeight();
            transform.parent = null;
            GetComponent<BoxCollider>().enabled = false;
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
            if (collector.getHigh() == 0)
            {
                //SceneManager.LoadScene("GameOver");
            }
        }
    }
    public bool getCollected()
    {
        return isCollected;
    }

    public void setCollected()
    {
        isCollected = true;
    }

    public void setIndex(int index)
    {
        this.index = index;
    }
}
