using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crusher : MonoBehaviour
{
    // Start is called before the first frame update

    //initialize coming and going vector as (0,0,0)
    Vector3 comingVector = Vector3.zero;
    Vector3 goingVector = Vector3.zero;

    //initialize the variables
    [SerializeField] Vector3 endCoords; //When the object turns back
    [SerializeField] float comingSpeed; //Coming speed of object (usually faster)
    [SerializeField] float goingSpeed; //Speed of object when it goes away (usually slower)
    [SerializeField] [Range(0,2)] int activeIndex; // 0 = x, 1 = y, 2 = z

    //initialize starting coordinates to set them as the starting position of object
    Vector3 startingCoords;

    //to determine whether the object is coming or going
    bool coming;



    void Start()
    {
        startingCoords = transform.position;
        comingVector[activeIndex] = comingSpeed;
        goingVector[activeIndex] = goingSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        // if the object 
        if (transform.position[activeIndex] <= startingCoords[activeIndex])
        {
            coming = false;
        }
        else if (transform.position[activeIndex] >= endCoords[activeIndex])
        {
            coming = true;
        }

        
        if (coming)
        {
            transform.position -= (comingVector);
        }
        else if (!coming)
        {
            transform.position += (goingVector);
            
        }
        else
        {
            Debug.LogError("Crusher object out of bounds");
            transform.position = startingCoords;
            return;
        }
    }
}
