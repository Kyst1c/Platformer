using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medkit : MonoBehaviour
{
   public int healAmount=20;

   private void OnTriggerEnter2D(Collider2D collision)
   {
       PlayerMovement pm=collision.GetComponent<PlayerMovement>();
       if(pm!=null)
       {
           pm.Heal(healAmount);
           Destroy(gameObject); // исчезает после использования
       }
   }
}
