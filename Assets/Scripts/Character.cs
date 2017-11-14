using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Character : MonoBehaviour
{
    public string mName;
    public int mMaxHealth;
    public int mCurrentHealth;
    public bool mIsStunned;
    public bool mIsDead;

    void Awake()
    {
        mName = (mName == "") ? "Default" : mName;
        mMaxHealth = (mMaxHealth == 0) ? 1 : mMaxHealth;
        mCurrentHealth = mMaxHealth;
        CharacterEvent.Event.mCharacterUpdated.Invoke(this);
        CharacterEvent.Event.mCharacterDamaged.AddListener(TakeDamage);
        CharacterEvent.Event.mCharacterStunned.AddListener(Stun);
    }

    void TakeDamage(int amount, Character character)
    {
        if (character != this || amount == 0)
            return;
        mCurrentHealth = (mCurrentHealth - amount < 0) ? 0 : mCurrentHealth - amount;
        CharacterEvent.Event.mCharacterUpdated.Invoke(this);
        if (mCurrentHealth == 0)
            StartCoroutine(Death());
    }

    IEnumerator Death()
    {
        mIsDead = true;
        float counter = 0;
        while (counter != 5)
        {
            counter += Time.deltaTime;
            yield return null;
        }
        CharacterEvent.Event.mCharacterUpdated.Invoke(this);
    }

    void Stun(float duration, Character character)
    {       
        if(character != this || duration <= 0)
            return;
        mIsStunned = true;
        StartCoroutine(StunnedDelay(duration));
    }

    IEnumerator StunnedDelay(float delay)
    {
        CharacterEvent.Event.mCharacterUpdated.Invoke(this);
        while (mIsStunned)
        {            
            yield return new WaitForSeconds(delay);
            mIsStunned = false;            
        }
        CharacterEvent.Event.mCharacterUpdated.Invoke(this);
    } 
}
