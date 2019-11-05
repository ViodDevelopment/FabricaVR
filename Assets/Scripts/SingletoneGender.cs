using System.Collections;
using System.Collections.Generic;

public class SingletoneGender 
{
    private static SingletoneGender instance;
    public enum Gender {NONE, MALE, FAMALE};
    private Gender currentGender;

    static public SingletoneGender GetInstance()
    {
        if (instance == null)
        {
            instance = new SingletoneGender();
            instance.SetGender(SingletoneGender.Gender.NONE);
        }
        return instance;
    }

    public void SetGender(SingletoneGender.Gender _gender)
    {
        currentGender = _gender;
    }

    public Gender GetGender()
    {
        return currentGender;
    }

}
