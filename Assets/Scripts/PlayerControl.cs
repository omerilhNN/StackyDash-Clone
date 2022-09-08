using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public static PlayerControl Instance;
    public float speed;

    public GameObject dashesParent;
    public GameObject prevDash;

    private Rigidbody rb;
    private bool isMoving = false;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow) || MobileInput.Instance.swipeLeft && !isMoving)
        {
            isMoving = true;
            rb.velocity = Vector3.left * speed * Time.deltaTime;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) || MobileInput.Instance.swipeRight && !isMoving)
        {
            isMoving = true;
            rb.velocity = Vector3.right * speed * Time.deltaTime;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) || MobileInput.Instance.swipeUp && !isMoving)
        {
            isMoving = true;
            rb.velocity = Vector3.forward * speed * Time.deltaTime;
        }
        
        else if (Input.GetKeyDown(KeyCode.DownArrow) || MobileInput.Instance.swipeDown && !isMoving)
        {
            isMoving = true;
            rb.velocity = Vector3.back * speed * Time.deltaTime;
        }
        if(rb.velocity == Vector3.zero)
        {
            isMoving = false;
        }
    }
    public void TakeDashes(GameObject dash)
    {
        dash.transform.SetParent(dashesParent.transform);
        Vector3 pos = prevDash.transform.localPosition;
        pos.y -= 0.098f;
        dash.transform.localPosition = pos;

        Vector3 characterPos = transform.localPosition;
        characterPos.y += 0.098f;
        transform.localPosition = characterPos;
        prevDash = dash;

        prevDash.GetComponent<BoxCollider>().isTrigger = false;


    }
}
