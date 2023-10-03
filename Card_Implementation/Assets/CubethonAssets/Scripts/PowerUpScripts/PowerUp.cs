﻿using UnityEngine;

namespace Pattern.Visitor
{
    [CreateAssetMenu(fileName = "PowerUp", menuName = "PowerUp")]
    public class PowerUp : ScriptableObject, IVisitor
    {
        public string powerupName;
        public GameObject powerupPrefab;
        public string powerupDescription;

        public Rigidbody _cubeRB; 

        //-----SHRINK-----//
        //originally our heal shield
        [Tooltip("Shrink our cube")]
        public bool shrinkPlayer;
        public Vector3 shrinkSize = new Vector3(0.5f, 0.5f, 0.5f);

        //[Tooltip("Fully heal shield")]
        //public bool healShield;

        //-----TURBO BOOST-----//
        //Keeping turboBoost cause I like the chaos of it
        [Range(0.0f, 50f)]
        [Tooltip(
            "Boost turbo settings up to increments of 50/mph")]
        public float turboBoost;
        

        //-----CHANGE COLOR-----//
        [Range(0.0f, 25)]
        [Tooltip(
            "Boost weapon range in increments of up to 25 units")]
        public int weaponRange;

        [Range(0.0f, 50f)]
        [Tooltip(
            "Boost weapon strength in increments of up to 50%")]
        public float weaponStrength;

        public void Visit(BikeShield bikeShield) 
        {
            if (shrinkPlayer)
            {
                bikeShield.currentSize = shrinkSize;
                _cubeRB.transform.localScale = bikeShield.currentSize;
            }
                
            //if (healShield) 
               //bikeShield.health = 100.0f;
        } 
    
        public void Visit(BikeWeapon bikeWeapon) 
        {
            int range = bikeWeapon.range += weaponRange;

            if (range >= bikeWeapon.maxRange)
                bikeWeapon.range = bikeWeapon.maxRange;
            else
                bikeWeapon.range = range;
            
            float strength = 
                bikeWeapon.strength += 
                    Mathf.Round(
                        bikeWeapon.strength 
                        * weaponStrength / 100);

            if (strength >= bikeWeapon.maxStrength)
                bikeWeapon.strength = bikeWeapon.maxStrength;
            else
                bikeWeapon.strength = strength;
        }
    
        public void Visit(BikeEngine bikeEngine)
        {
            float boost = bikeEngine.turboBoost += turboBoost;
            
            if (boost < 0.0f)
                bikeEngine.turboBoost = 0.0f;

            if (boost >= bikeEngine.maxTurboBoost)
                bikeEngine.turboBoost = bikeEngine.maxTurboBoost;
        }
    }
}