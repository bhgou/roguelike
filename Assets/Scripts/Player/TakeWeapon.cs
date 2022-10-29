using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeWeapon : MonoBehaviour
{

    [SerializeField] private List<GameObject> unlocked_Weaapon;
    [SerializeField] private Weapon[] all_weapon;
    [SerializeField] private weaponId weaponid;
     [SerializeField] private int max_slots = 2;
    public int count_slots;
    int count_ = 0;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Weapon") && count_slots < max_slots)
        {
            weaponid = collision.GetComponent<weaponId>();
            for (int i = 0; i < all_weapon.Length; i++)
            {
                if (weaponid.id == all_weapon[i].id)
                {
                    count_slots++;
                    unlocked_Weaapon.Add(all_weapon[i].gameObject);
                }
            }
            Destroy(collision.gameObject);
            SwitchWeapon();
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SwitchWeapon();
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            RemoveWeapon();
        }
        if(count_slots > max_slots)
        {
            count_slots = max_slots;
        }
        if(count_slots < 0)
        {
            count_slots = 0;
        }
    }
    void RemoveWeapon()
    {
        count_++;
        count_slots--;
        if (count_ > max_slots) { count_ = 0; }
        unlocked_Weaapon.RemoveAt(count_);
    }
    void SwitchWeapon()
    {
        
        for (int i = 0; i < unlocked_Weaapon.Count; i++)
        {
           
     
            if (unlocked_Weaapon[i].activeInHierarchy)
            {
               
                unlocked_Weaapon[i].SetActive(false);
                if(i != 0)
                {
                    unlocked_Weaapon[i - 1].SetActive(true);
                   
                }
                else
                {
                    unlocked_Weaapon[unlocked_Weaapon.Count - 1].SetActive(true);
                 
                }
                break;
            }
        }
    }

}
