using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    private Transform player;   //declare a player variablr of the transform type to make it as the transform component of the player.
    private Vector3 tempPos;    //temporary vector to store camera position

    [SerializeField]
    private float minX, maxX;   //the left and rightmost position to which the camera can move

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;  //from the 'GamePlay' scene, we are trying to find a game object with tag "Player" and access its transform property and then assign it to the player variable(of the transform type declared earlier)
        
    }


    // Update is called once per frame
    void LateUpdate()      //LateUpdate is called after all the calculations of the Update function is completed. 
    {
        tempPos = transform.position;   //we store the values of the position of the main camera from its transform compponent to the tempPos variable.(basically copies the position of the camera to tempPos) 
        
        if(player) //this condition is checked at the player enemy collision part(player script enemy_tag part). After destroying the gameObject(player) after colliding with enemy, this part of code still tries to access the player object. this will raise an error. So here we will give a condition to check, if player exists, then we will change position of camera, if it doesnt exist, we will not access it.
            tempPos.x = player.position.x;  //then we change the tempPos's x value to the players x value.

        if(tempPos.x < minX)
            tempPos.x = minX;   //checks if the position of the camera went beyond its allowed value in the left side. if then, we will stop moving the camera
        if(tempPos.x  > maxX)
            tempPos.x = maxX;   //same thing in the right side

        transform.position = tempPos;   //finally we make the tempPos value back to the original camera position variable.
    }
}

