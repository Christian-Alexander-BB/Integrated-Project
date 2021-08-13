using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    // player camera
    public Camera fpsCam;
    // layer mask for the door
    public LayerMask doorMask;
    // set interaction distance
    public float interactionDistance = 2f;
    // prompt for player to open the door
    public GameObject doorPrompt;
    
    // animations for the doors in the level
    public Animator doorOpen;
    public Animator doorOpen1;
    public Animator doorOpen2;
    public Animator doorOpen3;
    public Animator doorOpen4;
    public Animator doorOpen5;
    public Animator doorOpen6;
    public Animator doorOpen7;
    public Animator doorOpen8;
    public Animator doorOpen9;
    public Animator doorOpen10;

    // bool to check each door if it has been opened
    public bool doorOpenFlag = false;
    public bool doorOpenFlag1 = false;
    public bool doorOpenFlag2 = false;
    public bool doorOpenFlag3 = false;
    public bool doorOpenFlag4 = false;
    public bool doorOpenFlag5 = false;
    public bool doorOpenFlag6 = false;
    public bool doorOpenFlag7 = false;
    public bool doorOpenFlag8 = false;
    public bool doorOpenFlag9 = false;
    public bool doorOpenFlag10 = false;

    // timer to check if it has been 10 seconds
    public float timer;
    public float timer1;
    public float timer2;
    public float timer3;
    public float timer4;
    public float timer5;
    public float timer6;
    public float timer7;
    public float timer8;
    public float timer9;
    public float timer10;

    // Start is called before the first frame update
    void Start()
    {
        // hide the open door prompt first
        doorPrompt.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // starts timer when door is open
        if (doorOpenFlag)
        {
            timer += Time.deltaTime;
        }

        // starts timer when door is open
        if (doorOpenFlag1)
        {
            timer1 += Time.deltaTime;
        }

        // starts timer when door is open
        if (doorOpenFlag2)
        {
            timer2 += Time.deltaTime;
        }

        // starts timer when door is open
        if (doorOpenFlag3)
        {
            timer3 += Time.deltaTime;
        }

        // starts timer when door is open
        if (doorOpenFlag4)
        {
            timer4 += Time.deltaTime;
        }

        // starts timer when door is open
        if (doorOpenFlag5)
        {
            timer5 += Time.deltaTime;
        }

        // starts timer when door is open
        if (doorOpenFlag6)
        {
            timer6 += Time.deltaTime;
        }

        // starts timer when door is open
        if (doorOpenFlag7)
        {
            timer7 += Time.deltaTime;
        }

        // starts timer when door is open
        if (doorOpenFlag8)
        {
            timer8 += Time.deltaTime;
        }

        // starts timer when door is open
        if (doorOpenFlag9)
        {
            timer9 += Time.deltaTime;
        }

        // starts timer when door is open
        if (doorOpenFlag10)
        {
            timer10 += Time.deltaTime;
        }

        
        // checks if it has been 10 seconds, if so, close the door
        if (timer >= 10f)
        {
            timer = 0;
            doorOpen.SetBool("doorOpen", false);
            doorOpenFlag = false;
        }

        // checks if it has been 10 seconds, if so, close the door
        if (timer1 >= 10f)
        {
            timer1 = 0;
            doorOpen1.SetBool("doorOpen", false);
            doorOpenFlag1 = false;
        }

        // checks if it has been 10 seconds, if so, close the door
        if (timer2 >= 10f)
        {
            timer2 = 0;
            doorOpen2.SetBool("doorOpen", false);
            doorOpenFlag2 = false;
        }

        // checks if it has been 10 seconds, if so, close the door
        if (timer3 >= 10f)
        {
            timer3 = 0;
            doorOpen3.SetBool("doorOpen", false);
            doorOpenFlag3 = false;
        }

        // checks if it has been 10 seconds, if so, close the door
        if (timer4 >= 10f)
        {
            timer4 = 0;
            doorOpen4.SetBool("doorOpen", false);
            doorOpenFlag4 = false;
        }

        // checks if it has been 10 seconds, if so, close the door
        if (timer5 >= 10f)
        {
            timer5 = 0;
            doorOpen5.SetBool("doorOpen", false);
            doorOpenFlag5 = false;
        }

        // checks if it has been 10 seconds, if so, close the door
        if (timer6 >= 10f)
        {
            timer6 = 0;
            doorOpen6.SetBool("doorOpen", false);
            doorOpenFlag6 = false;
        }

        // checks if it has been 10 seconds, if so, close the door
        if (timer7 >= 10f)
        {
            timer7 = 0;
            doorOpen7.SetBool("doorOpen", false);
            doorOpenFlag7 = false;
        }

        // checks if it has been 10 seconds, if so, close the door
        if (timer8 >= 10f)
        {
            timer8 = 0;
            doorOpen8.SetBool("doorOpen", false);
            doorOpenFlag8 = false;
        }

        // checks if it has been 10 seconds, if so, close the door
        if (timer9 >= 10f)
        {
            timer9 = 0;
            doorOpen9.SetBool("doorOpen", false);
            doorOpenFlag9 = false;
        }

        // checks if it has been 10 seconds, if so, close the door
        if (timer10 >= 10f)
        {
            timer10 = 0;
            doorOpen10.SetBool("doorOpen", false);
            doorOpenFlag10 = false;
        }

        // initialise raycasting to open doors
        RaycastHit result;
        // allow raycast to only detect items in Door layer
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out result, interactionDistance, doorMask))
        {
            // if game object's name is bluedoor_v2 (7), run the code below
            if (result.transform.name == "bluedoor_v2 (7)")
            {
                // display door prompt in UI if door is closed
                if (!doorOpenFlag)
                {
                    doorPrompt.SetActive(true);
                }
                // opens the door if player presses E
                if (Input.GetKeyDown(KeyCode.E))
                {
                    // if door is not open, open the door and start the timer that will close the door automatically after 10 seconds
                    if (!doorOpenFlag)
                    {
                        doorOpenFlag = true;
                        doorPrompt.SetActive(false);
                        // play animation for opening door
                        doorOpen.SetBool("doorOpen", true);
                    }
                }
            }

            // if game object's name is whitedoor_v2 (1), run the code below
            if (result.transform.name == "whitedoor_v2 (1)")
            {
                // display door prompt in UI if door is closed
                if (!doorOpenFlag1)
                {
                    doorPrompt.SetActive(true);
                }
                // opens the door if player presses E
                if (Input.GetKeyDown(KeyCode.E))
                {
                    // if door is not open, open the door and start the timer that will close the door automatically after 10 seconds
                    if (!doorOpenFlag1)
                    {
                        doorOpenFlag1 = true;
                        doorPrompt.SetActive(false);
                        // play animation for opening door
                        doorOpen1.SetBool("doorOpen", true);
                    }
                }
            }

            // if game object's name is bluedoor_v2 (3), run the code below
            if (result.transform.name == "bluedoor_v2 (3)")
            {
                // display door prompt in UI if door is closed
                if (!doorOpenFlag2)
                {
                    doorPrompt.SetActive(true);
                }
                // opens the door if player presses E
                if (Input.GetKeyDown(KeyCode.E))
                {
                    // if door is not open, open the door and start the timer that will close the door automatically after 10 seconds
                    if (!doorOpenFlag2)
                    {
                        doorOpenFlag2 = true;
                        doorPrompt.SetActive(false);
                        // play animation for opening door
                        doorOpen2.SetBool("doorOpen", true);
                    }
                }
            }

            // if game object's name is bluedoor_v2, run the code below
            if (result.transform.name == "bluedoor_v2")
            {
                // display door prompt in UI if door is closed
                if (!doorOpenFlag3)
                {
                    doorPrompt.SetActive(true);
                }
                // opens the door if player presses E
                if (Input.GetKeyDown(KeyCode.E))
                {
                    // if door is not open, open the door and start the timer that will close the door automatically after 10 seconds
                    if (!doorOpenFlag3)
                    {
                        doorOpenFlag3 = true;
                        doorPrompt.SetActive(false);
                        // play animation for opening door
                        doorOpen3.SetBool("doorOpen", true);
                    }
                }
            }

            // if game object's name is bluedoor_v2 (1), run the code below
            if (result.transform.name == "bluedoor_v2 (1)")
            {
                // display door prompt in UI if door is closed
                if (!doorOpenFlag4)
                {
                    doorPrompt.SetActive(true);
                }
                // opens the door if player presses E
                if (Input.GetKeyDown(KeyCode.E))
                {
                    // if door is not open, open the door and start the timer that will close the door automatically after 10 seconds
                    if (!doorOpenFlag4)
                    {
                        doorOpenFlag4 = true;
                        doorPrompt.SetActive(false);
                        // play animation for opening door
                        doorOpen4.SetBool("doorOpen", true);
                    }
                }
            }

            // if game object's name is bluedoor_v2 (2), run the code below
            if (result.transform.name == "bluedoor_v2 (2)")
            {
                // display door prompt in UI if door is closed
                if (!doorOpenFlag5)
                {
                    doorPrompt.SetActive(true);
                }
                // opens the door if player presses E
                if (Input.GetKeyDown(KeyCode.E))
                {
                    // if door is not open, open the door and start the timer that will close the door automatically after 10 seconds
                    if (!doorOpenFlag5)
                    {
                        doorOpenFlag5 = true;
                        doorPrompt.SetActive(false);
                        // play animation for opening door
                        doorOpen5.SetBool("doorOpen", true);
                    }
                }
            }

            // if game object's name is bluedoor_v2 (4), run the code below
            if (result.transform.name == "bluedoor_v2 (4)")
            {
                // display door prompt in UI if door is closed
                if (!doorOpenFlag6)
                {
                    doorPrompt.SetActive(true);
                }
                // opens the door if player presses E
                if (Input.GetKeyDown(KeyCode.E))
                {
                    // if door is not open, open the door and start the timer that will close the door automatically after 10 seconds
                    if (!doorOpenFlag6)
                    {
                        doorOpenFlag6 = true;
                        doorPrompt.SetActive(false);
                        // play animation for opening door
                        doorOpen6.SetBool("doorOpen", true);
                    }
                }
            }

            // if game object's name is bluedoor_v2 (5), run the code below
            if (result.transform.name == "bluedoor_v2 (5)")
            {
                // display door prompt in UI if door is closed
                if (!doorOpenFlag7)
                {
                    doorPrompt.SetActive(true);
                }
                // opens the door if player presses E
                if (Input.GetKeyDown(KeyCode.E))
                {
                    // if door is not open, open the door and start the timer that will close the door automatically after 10 seconds
                    if (!doorOpenFlag7)
                    {
                        doorOpenFlag7 = true;
                        doorPrompt.SetActive(false);
                        // play animation for opening door
                        doorOpen7.SetBool("doorOpen", true);
                    }
                }
            }

            // if game object's name is bluedoor_v2 (6), run the code below
            if (result.transform.name == "bluedoor_v2 (6)")
            {
                // display door prompt in UI if door is closed
                if (!doorOpenFlag8)
                {
                    doorPrompt.SetActive(true);
                }
                // opens the door if player presses E
                if (Input.GetKeyDown(KeyCode.E))
                {
                    // if door is not open, open the door and start the timer that will close the door automatically after 10 seconds
                    if (!doorOpenFlag8)
                    {
                        doorOpenFlag8 = true;
                        doorPrompt.SetActive(false);
                        // play animation for opening door
                        doorOpen8.SetBool("doorOpen", true);
                    }
                }
            }

            // if game object's name is whitedoor_v2 (2), run the code below
            if (result.transform.name == "whitedoor_v2 (2)")
            {
                // display door prompt in UI if door is closed
                if (!doorOpenFlag9)
                {
                    doorPrompt.SetActive(true);
                }
                // opens the door if player presses E
                if (Input.GetKeyDown(KeyCode.E))
                {
                    // if door is not open, open the door and start the timer that will close the door automatically after 10 seconds
                    if (!doorOpenFlag9)
                    {
                        doorOpenFlag9 = true;
                        doorPrompt.SetActive(false);
                        // play animation for opening door
                        doorOpen9.SetBool("doorOpen", true);
                    }
                }
            }

            // if game object's name is whitedoor_v2 (3), run the code below
            if (result.transform.name == "whitedoor_v2 (3)")
            {
                // display door prompt in UI if door is closed
                if (!doorOpenFlag10)
                {
                    doorPrompt.SetActive(true);
                }
                // opens the door if player presses E
                if (Input.GetKeyDown(KeyCode.E))
                {
                    // if door is not open, open the door and start the timer that will close the door automatically after 10 seconds
                    if (!doorOpenFlag10)
                    {
                        doorOpenFlag10 = true;
                        doorPrompt.SetActive(false);
                        // play animation for opening door
                        doorOpen10.SetBool("doorOpen", true);
                    }
                }
            }

        }

        else
        {
            // hides door prompt if player is outside of the interaction distance
            doorPrompt.SetActive(false);
        }
    }
}
