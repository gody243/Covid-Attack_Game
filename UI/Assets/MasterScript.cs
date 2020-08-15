using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class MasterScript : MonoBehaviour
    {

        // Assign the characters to this array:
        public GameObject[] zombies;

        // Call this when you process a line in the text file:
        void ProcessTextFileItem(int outfielderNumber, string newState)
        {
        // Change the outfielder's animation state:
        zombies[outfielderNumber].GetComponent<Animator>().Play(newState);
        }

    }

