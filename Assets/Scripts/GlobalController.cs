using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalController : MonoBehaviour
{
    public string currentColor;
    private string preColor;
    public GameObject room;
    public GameObject boxes;

    public GameObject canvas;

    public float coolDowm;

    private float timer;

    private Color purple = new Color(1, 0, 1, 1);

    // Start is called before the first frame update
    void Start()
    {
        timer = coolDowm;
        currentColor = "White";
        room.GetComponent<MeshRenderer>().material.color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ReloadScene();
        }

        timer += Time.deltaTime;
        if (timer < coolDowm)
        {
            canvas.SetActive(false);
        }
        else
        {
            canvas.SetActive(true);
        }
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }

    public void ChangeWhite()
    {

        if (currentColor != "White")
        {
            if (timer >= coolDowm)
            {
                timer = 0;
                preColor = currentColor;
                currentColor = "White";
                room.GetComponent<MeshRenderer>().material.color = Color.white;
                boxes.GetComponent<BoxController>().RoomChange(preColor, currentColor);
            }

        }
    }

    public void ChangeRed()
    {

        if (currentColor != "Red")
        {
            if (timer >= coolDowm)
            {
                timer = 0;
                preColor = currentColor;
                currentColor = "Red";
                room.GetComponent<MeshRenderer>().material.color = Color.red;
                boxes.GetComponent<BoxController>().RoomChange(preColor, currentColor);
            }
        }
    }
    public void ChangeGreen()
    {

        if (currentColor != "Green")
        {
            if (timer >= coolDowm)
            {
                timer = 0;
                preColor = currentColor;
                currentColor = "Green";
                room.GetComponent<MeshRenderer>().material.color = Color.green;
                boxes.GetComponent<BoxController>().RoomChange(preColor, currentColor);
            }
        }
    }

    public void ChangeBlue()
    {

        if (currentColor != "Blue")
        {
            if (timer >= coolDowm)
            {
                timer = 0;
                preColor = currentColor;
                currentColor = "Blue";
                room.GetComponent<MeshRenderer>().material.color = Color.blue;
                boxes.GetComponent<BoxController>().RoomChange(preColor, currentColor);
            }
        }
    }

    public void ChangeYellow()
    {

        if (currentColor != "Yellow")
        {
            if (timer >= coolDowm)
            {
                timer = 0;
                preColor = currentColor;
                currentColor = "Yellow";
                room.GetComponent<MeshRenderer>().material.color = Color.yellow;
                boxes.GetComponent<BoxController>().RoomChange(preColor, currentColor);
            }
        }
    }

    public void ChangePurple()
    {

        if (currentColor != "Purple")
        {
            if (timer >= coolDowm)
            {
                timer = 0;
                preColor = currentColor;
                currentColor = "Purple";
                room.GetComponent<MeshRenderer>().material.color = purple;
                boxes.GetComponent<BoxController>().RoomChange(preColor, currentColor);
            }
        }
    }

    public void ChangeCyan()
    {

        if (currentColor != "Cyan")
        {
            if (timer >= coolDowm)
            {
                timer = 0;
                preColor = currentColor;
                currentColor = "Cyan";
                room.GetComponent<MeshRenderer>().material.color = Color.cyan;
                boxes.GetComponent<BoxController>().RoomChange(preColor, currentColor);
            }
        }
    }
}
