using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardController : MonoBehaviour {

    // Uses the SerialArduino.cs script to send a serial string to an arduino
    // via the SendSerial() method.
    private SerialArduino serialArduino;
    private MeshRenderer mesh;
	void Start () {
        serialArduino = GetComponent<SerialArduino>();
        mesh = GetComponent<MeshRenderer>();
		
	}
	
	void Update () {
		
        if(Input.GetKeyDown("o"))
        {
            // Sending a "O" char to arduino to turn the LED on
            serialArduino.SendSerial("O");
            print("O input detected - 'O' sent"); // Turn LED on
            mesh.enabled = true;

        }
        if(Input.GetKeyDown("s"))
        {
            // Sending a "O" char to arduino to turn the LED off
            serialArduino.SendSerial("F");
            print("s input detected - 'F' sent"); // Turn LED off
            mesh.enabled = false;
        }

	}
}
