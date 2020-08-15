using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{
    public Transform curseur;
    public int selectedWeapon = 0;
    // Start is called before the first frame update
    void Start()
    {
        selectWeapon();
        
    }

    // Update is called once per frame
    void Update()
    {
        int previousSelectedWeapon = selectedWeapon;
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (selectedWeapon >= transform.childCount - 1)
                selectedWeapon = 0;
            else
                selectedWeapon++;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
            if (selectedWeapon <= 0)
                selectedWeapon = transform.childCount - 1;
            else
                selectedWeapon--;

        if (previousSelectedWeapon != selectedWeapon)
        {
            selectWeapon();
        }
    }

    void selectWeapon()
    {
        
        int i = 0;
        foreach(Transform weapon in transform)
        {
            if (i == selectedWeapon)
            {
                curseur.gameObject.SetActive(false);
                weapon.gameObject.SetActive(true);

            }
            else
            {
                curseur.gameObject.SetActive(true);
                weapon.gameObject.SetActive(false);
            }
                i++;
            
            
        }
    }
}

