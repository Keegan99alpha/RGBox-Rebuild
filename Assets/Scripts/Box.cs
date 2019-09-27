using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Box : MonoBehaviour
{
    //private bool interactive;
    private bool collided;
    //private bool collideWithUpper;

    private Vector3 pastPosition;
    //public Animator[] animator;
    private Rigidbody rigid;

    private Color purple = new Color(1, 0, 1, 1);

    private bool lateCheck;

    private Transform trigger;
    //private Transform triggers;
    private Transform frame;
    private Transform frames;
    private Transform wasteBin;

    private GameObject globalCon;

    // Start is called before the first frame update
    void Start()
    {
        globalCon = GameObject.Find("GlobalController");

        //triggers = GameObject.Find("Triggers").transform;
        trigger = transform.GetChild(0);
        //trigger.SetParent(triggers);
        frames = GameObject.Find("FrameBoxes").transform;
        frame = transform.GetChild(1);
        frame.SetParent(frames);
        wasteBin = GameObject.Find("WasteBin").transform;

        //collideWithUpper = false;
        lateCheck = false;
        rigid = GetComponent<Rigidbody>();
        // interactive = true;
        collided = false;
        switch (tag)
        {
            case "Red":
                gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
                frame.GetComponent<MeshRenderer>().material.color = Color.red;
                break;
            case "Blue":
                gameObject.GetComponent<MeshRenderer>().material.color = Color.blue;
                frame.GetComponent<MeshRenderer>().material.color = Color.blue;
                break;
            case "Green":
                gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
                frame.GetComponent<MeshRenderer>().material.color = Color.green;
                break;
            case "Cyan":
                gameObject.GetComponent<MeshRenderer>().material.color = Color.cyan;
                frame.GetComponent<MeshRenderer>().material.color = Color.cyan;
                break;
            case "Purple":
                gameObject.GetComponent<MeshRenderer>().material.color = purple;
                frame.GetComponent<MeshRenderer>().material.color = purple;
                break;
            case "Yellow":
                gameObject.GetComponent<MeshRenderer>().material.color = Color.yellow;
                frame.GetComponent<MeshRenderer>().material.color = Color.yellow;
                break;


        }
    }

    // Update is called once per frame
    void Update()
    {
        //if (tag == globalCon.GetComponent<GlobalController>().currentColor)
        //{
        //    Disappear();
        //}
    }

    //private void LateUpdate()
    //{
    //    if (lateCheck)
    //    {
    //        Debug.Log(5 + "  " + Time.frameCount);
    //        if (collided)
    //        {
    //            RecoverActions();
    //        }
    //        lateCheck = false;
    //    }
    //}

    IEnumerator WaitFor(float second)
    {
        yield return new WaitForSeconds(second);
        frame.gameObject.SetActive(false);
        if (collided == false)
        {
            //rigid.useGravity = true;
            rigid.velocity = Vector3.zero;
            transform.position = pastPosition;
            // interactive = true;
        }
        collided = false;
        rigid.useGravity = true;
        trigger.position = transform.position;
    }

    //private void RecoverActions()
    //{
    //    frame.gameObject.SetActive(false);
    //    //rigid.useGravity = true;
    //    rigid.velocity = Vector3.zero;
    //    transform.position = pastPosition;
    //    interactive = true;
    //}

    public void Disappear()
    {
        pastPosition = transform.position;
        transform.position += Vector3.right * 100;
        //trigger.position = transform.position;
        //rigid.useGravity = false;
        //rigid.velocity = Vector3.zero;

        frame.position = pastPosition;
        frame.gameObject.SetActive(true);
        // interactive = false;
    }

    public void Recover()
    {
        //Debug.Log(2 + "  " + Time.frameCount);
        trigger.position = pastPosition;

        rigid.useGravity = false;
        rigid.velocity = Vector3.zero;

        StartCoroutine(WaitFor(0.5f));

        //lateCheck = true;

        //if (collided == false)
        //{
        //    lateCheck = true;
        //}
    }

    private void Wasted()
    {
        //collided = false;
        frame.SetParent(transform);
        transform.position += Vector3.left * 100;
        transform.SetParent(wasteBin);
        gameObject.SetActive(false);

    }

    private void OnTriggerEnter(Collider col)
    {
        // Debug.Log(Time.frameCount + "   OnTriggerEnter");
        Debug.Log(col);
        //Wasted();
        //collided = true;

        switch (gameObject.tag)
        {
            case "Red":
                switch (col.tag)
                {
                    case "Red":
                        //Debug.Log("Red+Red");
                        break;
                    case "Blue":
                        collided = true;
                        col.tag = "Purple";
                        col.GetComponent<MeshRenderer>().material.color = purple;
                        col.GetComponent<Box>().frame.GetComponent<MeshRenderer>().material.color = purple;
                        Wasted();
                        break;
                    case "Green":
                        collided = true;
                        col.tag = "Yellow";
                        col.GetComponent<MeshRenderer>().material.color = Color.yellow;
                        col.GetComponent<Box>().frame.GetComponent<MeshRenderer>().material.color = Color.yellow;
                        Wasted();
                        break;

                    case "Yellow":
                        Wasted();
                        break;
                    case "Purple":
                        Wasted();
                        break;
                    case "Cyan":
                        Wasted();
                        break;
                }
                break;
            case "Green":
                //Debug.Log(4 + "  " + Time.frameCount);
                switch (col.tag)
                {
                    case "Red":
                        collided = true;
                        col.tag = "Yellow";
                        col.GetComponent<MeshRenderer>().material.color = Color.yellow;
                        col.GetComponent<Box>().frame.GetComponent<MeshRenderer>().material.color = Color.yellow;
                        Wasted();
                        break;
                    case "Blue":
                        collided = true;
                        col.tag = "Cyan";
                        col.GetComponent<MeshRenderer>().material.color = Color.cyan;
                        col.GetComponent<Box>().frame.GetComponent<MeshRenderer>().material.color = Color.cyan;
                        Wasted();
                        break;
                    case "Green":
                        //Debug.Log("Green+Green");
                        break;
                    case "Yellow":
                        Wasted();
                        break;
                    case "Purple":
                        Wasted();
                        break;
                    case "Cyan":
                        Wasted();
                        break;
                }
                break;
            case "Blue":
                // Debug.Log(3 + "  " + Time.frameCount);
                switch (col.tag)
                {
                    case "Red":
                        col.tag = "Purple";
                        collided = true;
                        col.GetComponent<MeshRenderer>().material.color = purple;
                        col.GetComponent<Box>().frame.GetComponent<MeshRenderer>().material.color = purple;
                        Wasted();
                        break;
                    case "Blue":
                        //Debug.Log("Blue+Blue");
                        break;
                    case "Green":
                        col.tag = "Cyan";
                        collided = true;
                        col.GetComponent<MeshRenderer>().material.color = Color.cyan;
                        col.GetComponent<Box>().frame.GetComponent<MeshRenderer>().material.color = Color.cyan;
                        Wasted();
                        break;

                    case "Yellow":
                        Wasted();
                        break;
                    case "Purple":
                        Wasted();
                        break;
                    case "Cyan":
                        Wasted();
                        break;
                }
                break;

            case "Yellow":
                Wasted();
                break;
            case "Purple":
                Wasted();
                break;
            case "Cyan":
                Wasted();
                break;

        }
        //if (interactive == false)
        //{
        //    gameObject.SetActive(false);
        //}
    }
}
