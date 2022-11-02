using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public string characterClass = "Robot"; //Class scope, which means that the scope of the variable is accessible anywhere within it´s contaning class.

    int CharacterLevel = 3;

    int currentSkillevel = 4;
    int NextSkillLevel = 1;

    public int currentXP = 23;

    // Start is called before the first frame update
    void Start()
    {
        int characterHealth = 100; //Local scope 1, which means that the scope of the variable is only accessible inside the method in which the code is created in.
        Debug.Log(characterClass + " - HP: " + characterHealth);

        GenerateCharacter("Robotie", CharacterLevel); //Here Level and CharacterLevel are arguments.
       

        int NewSkillLevel = GenerateCharacter("Skill Level", currentSkillevel + NextSkillLevel);

        Debug.Log("New Skill Level Is: " + NewSkillLevel);


        int XP = 1;
        int nextXP;
        nextXP = XPLevel(currentXP, XP);
    }

    void CreateCharacter()
    {
        string characterName = "Robotie"; //Local scope 2, means the same as Local scope 1.
        Debug.Log(characterName + " - " + characterClass);
    }

    public int GenerateCharacter(string name, int level) //This is a public method with 2 parameters (name and level).
    {
        Debug.LogFormat("Character: {0} - Level: {1}", name, level); //Here name and level are parameters.

        return level += 1;
    }

    int XPLevel(int currentXP, int XP) //This is a method with 2 parameters (currentXP and XP).
    {
        int result = currentXP + XP; 
        Debug.Log("Next XP Level: " + result);
        return result;

    }



}
