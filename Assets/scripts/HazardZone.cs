using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardZone : MonoBehaviour
{
	public int damagePerTick=2;
	public float interval=1.5f;

	private float lastDamageTime=0f;

	void OnTriggerStay2D(Collider2D other)
	{
	   PlayerMovement pm=other.GetComponent<PlayerMovement>();
	   if(pm!=null && Time.time - lastDamageTime >= interval)
	   {
	       pm.TakeDamage();
	       lastDamageTime=Time.time;
	   }
   }
}