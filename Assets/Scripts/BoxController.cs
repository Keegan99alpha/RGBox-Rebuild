using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    private bool roomChangeNextFrame;
    private string para1;
    private string para2;
    // Start is called before the first frame update
    void Start()
    {
        roomChangeNextFrame = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (roomChangeNextFrame)
        {
            roomChangeNextFrame = false;
            RoomChangeAction(para1, para2);
            //Debug.Log(0 + "  " + Time.frameCount);
        }
    }

    private void RoomChangeAction(string preColor, string curColor)
    {
        for (int n = 0; n < transform.childCount; n++)
        {
            if (transform.GetChild(n).tag == curColor)
            {
                transform.GetChild(n).GetComponent<Box>().Disappear();
            }
        }

        for (int n = 0; n < transform.childCount; n++)
        {
            if (transform.GetChild(n).tag == preColor)
            {
                 //Debug.Log(transform.GetChild(n).name);
                transform.GetChild(n).GetComponent<Box>().Recover();
            }
        }
    }

    public void RoomChange(string preColor, string curColor)
    {
        roomChangeNextFrame = true;
        para1 = preColor;
        para2 = curColor;
    }
}
