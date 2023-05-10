using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CharacterController : MonoBehaviour
{
    public SimpleSampleCharacterControl control;
    public Animator m_animator;
    public Collector collector;
    public TMP_Text scoret;
    public TMP_Text scorelast;
    public GameObject canvas;
    public GameObject canvasmain;
    public float forwardSpeed;
    float moveSpeed = 10.0f;
    float limitValue = 4.5f;
    float positionX;
    

    void Start()
    {
        canvas.SetActive(false);
        forwardSpeed = 5f;
    }

    void Update()
    {
        forwardMovement();
        setPosition();
        //scoret.text = collector.getHigh().ToString();
        scoret.text = Turn_Move.score.ToString();
        scorelast.text = scoret.text;
        if (collector.getHigh() < 0)
        {
            canvasmain.SetActive(false);
            forwardSpeed = 0;
            transform.TransformPoint(transform.position.x, transform.position.y, transform.position.z-2);
            canvas.SetActive(true);
        }
    }

    private void forwardMovement()
    {
            //m_animator.Play("Movement");
        m_animator.SetFloat("MoveSpeed", 1);
        
        float horizontal = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        transform.Translate(horizontal,0,forwardSpeed*Time.deltaTime*0.7f);
    } 
    public void setPosition()
    {
        if(Input.touchCount > 0)
        {
            Touch fing = Input.GetTouch(0);
            float horizontal = fing.deltaPosition.x * moveSpeed * Time.fixedDeltaTime * 3 / 10;
            positionX = transform.position.x + horizontal;
            positionX = Mathf.Clamp(positionX, -limitValue, limitValue);
            transform.position = new Vector3(positionX, transform.position.y, transform.position.z);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Block")
        {
            Debug.Log("blocked first cube");
            collector.inscreaseHeight();
        }
    }
}
