using UnityEngine;
using System.IO;
using System.IO.Ports;
using System.Collections;
using System.Collections.Generic;



public class SerialArduino : MonoBehaviour
{
    public static SerialArduino Instance { get; private set; }

    // Use COM3 for the port
    public static SerialPort serialPort = new SerialPort("\\\\.\\COM7", 9600, Parity.None, 8, StopBits.One);
    
    private void Awake()
    {
        Instance = this;

    }


    void Start()
    {
        OpenConnection();
    }

    void Update()
    {

        // Serial Receive Example 
        // Not used in Animationland
        // Uncomment to recieve serial from arduino
        /*
        try
        {
            string value = serialPort.ReadLine();
            Debug.Log(value);
            if (value == "S")
            {
                Debug.Log("start button pressed");
                //PlayerController.Instance.StartButtonPressed();

            }
            if (value == "1")
            {
                Debug.Log("1 - button");
                SendSerial("N");
            }
            if (value == "2")
            {
                Debug.Log("2 - button");
                SendSerial("G");
            }




        }
        catch (System.Exception e)
        {
            // To debug Uncomment last 2 lines to see what the exception is
            // Most of the time its the Timeout exception because unity
            // did not receive any serial data that update frame.
            // V V V V V V V V V V V 
            //print("Serial Exception happened");
            //Debug.Log(e);

        } */
        
    }

    public void SendSerial(string letter)
    {
        // Serial write function used for sending a char or a string
        // To the arduino. For Animationland send only 1 char.
        serialPort.Write(letter);
    }



    public void OpenConnection()
    {
        if (serialPort != null)
        {
            if (serialPort.IsOpen)
            {
                serialPort.Close();
                Debug.Log("Closing port, because it was already open!");
            }
            else
            {
                serialPort.Open();
                serialPort.ReadTimeout = 1;
                Debug.Log("Port Opened!");
            }
        }
        else
        {
            print("Port == null");
        }
    }

    void OnApplicationQuit()
    {
        serialPort.Close();
        Debug.Log("Port closed!");
    }


}