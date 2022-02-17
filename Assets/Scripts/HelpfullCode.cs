using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if false
public class HelpfullCode : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Vectors____DontUse ()
    {
        //Vectors----------------
            // https://docs.unity3d.com/Manual/VectorCookbook.html

            // If one point in space is subtracted from another, then the result is 
            // a vector that “points” from one object to the other:

            // Gets a vector that points from the player's position to the target's.
            var heading = target.position - player.position;

            //
            var distance = heading.magnitude;
            var direction = heading / distance; // This is now the normalized direction.

            // This approach is preferable to using both the magnitude and 
            // normalized properties separately, since they are both quite 
            // CPU-hungry (they both involve calculating a square root).
            // If you only need to use the distance for comparison 
            // (for a proximity check, say) then you can avoid the magnitude 
            // calculation altogether. The sqrMagnitude property gives the square 
            // of the magnitude value, and is calculated like the magnitude but 
            // without the time-consuming square root operation. Rather than 
            // compare the magnitude against a known distance, you can compare 
            // the squared magnitude against the squared distance:-
            
            if (heading.sqrMagnitude < maxRange * maxRange) {
                // Target is within range.
            }
    }

}
#endif
