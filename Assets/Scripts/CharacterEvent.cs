using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



namespace CharacterEvent
{
    public class CharacterUpdateEvent : UnityEvent<Character> { }
    public class CharacterTakeDamageEvent : UnityEvent<int, Character> { }
    public class CharacterStunEvent : UnityEvent<float, Character> { }
    public class CharacterAttackEvent : UnityEvent<Character> { }

    public static class Event
    { 
        public static CharacterUpdateEvent mCharacterUpdated = new CharacterUpdateEvent();
        public static CharacterTakeDamageEvent mCharacterDamaged = new CharacterTakeDamageEvent();
        public static CharacterStunEvent mCharacterStunned = new CharacterStunEvent();
        public static CharacterAttackEvent mCharacterAttacked = new CharacterAttackEvent();
    }

}
