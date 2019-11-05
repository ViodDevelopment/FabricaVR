using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChargeMenu : MonoBehaviour
{
    //public AnimationEvent CallScene;
    int numScene =1;
    public Image m_FEm;
    public Image m_Male;
    public Image m_Start;
    public Image m_Credits;
    public Image m_Exit;

    float currentTimer=0;
    float maxTimer=2;
    bool activateTimer = false;

    float currentTimerMale = 0;
    bool activateTimerMale = false;

    float currentTimerFem = 0;
    bool activateTimerFem = false;

    float currentTimerCred = 0;
    bool activateTimerCred = false;

    float currentTimerExit = 0;
    bool activateTimerExit = false;

    bool FemSelected;
    bool MaleSelected;

    bool genreSelected=false;

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (activateTimerFem)
        {
            currentTimerFem += Time.deltaTime;
            if (currentTimerFem >= maxTimer)
            {
                ChargeGameFemale();
            }
        }
        else if (currentTimerFem > 0 && !FemSelected)
            currentTimerFem = 0;

        if (activateTimerMale)
        {
            currentTimerMale += Time.deltaTime;
            if (currentTimerMale >= maxTimer)
            {
                ChargeGameMale();
            }
        }
        else if (currentTimerMale > 0 && !MaleSelected)
            currentTimerMale = 0;

        if (activateTimer && genreSelected)
        {
            currentTimer += Time.deltaTime;
            if (currentTimer >= maxTimer)
            {
                ChargeGameFemOrMale();
            }
        }
        else if (currentTimer > 0)
            currentTimer = 0;


        if (activateTimerCred)
        {
            currentTimerCred += Time.deltaTime;
            if (currentTimerCred >= maxTimer)
            {
                Credits();
            }
        }
        else if (currentTimerCred > 0)
            currentTimerCred = 0;


        if (activateTimerExit)
        {
            currentTimerExit += Time.deltaTime;
            if (currentTimerExit >= maxTimer)
            {
                Quit();
            }
        }
        else if (currentTimerExit > 0)
            currentTimerExit = 0;

        if (m_FEm != null)
        {
            m_FEm.fillAmount = currentTimerFem / maxTimer;
            m_Male.fillAmount = currentTimerMale / maxTimer;
            m_Start.fillAmount = currentTimer / maxTimer;
            m_Credits.fillAmount = currentTimerCred / maxTimer;
            m_Exit.fillAmount = currentTimerExit / maxTimer;
        }
    }
    
    public void ChargeScene()
    {
         SceneManager.LoadScene(1);
    }

    public void ChargeGameFemOrMale()
    {
        SceneManager.LoadScene(numScene);
    }

    public void ChargeGameMale()
    {
        SingletoneGender.GetInstance().SetGender(SingletoneGender.Gender.MALE);
        print(SingletoneGender.GetInstance().GetGender());
        numScene = 2;
        FemSelected = false;
        MaleSelected = true;
        if (!genreSelected)
            genreSelected = true;
    }
    public void ChargeGameFemale()
    {
        SingletoneGender.GetInstance().SetGender(SingletoneGender.Gender.FAMALE);
        print(SingletoneGender.GetInstance().GetGender());
        numScene = 3;
        MaleSelected = false;
        FemSelected = true;
        if (!genreSelected)
            genreSelected = true;
    }

    void ChangeGameLow()
    {
        SceneManager.LoadScene(4);
    }

    void ChangeUpperFem()
    {
        SceneManager.LoadScene(6);
    }
    void ChangeUpperMale()
    {
        SceneManager.LoadScene(5);
    }

    public void Quit()
    {
        Application.Quit();    
    }

    public void Credits()
    {
        SceneManager.LoadScene(7);
    }

    public void ActivateStart()
    {
        activateTimer = true;
    }
    public void DesactivateStart()
    {
        activateTimer = false;
    }
    public void ActivateFem()
    {
        activateTimerFem = true;
    }
    public void DesactivateFem()
    {
        activateTimerFem = false;
    }
    public void ActivateMale()
    {
        activateTimerMale = true;
    }
    public void DesacativateMale()
    {
        activateTimerMale = false;
    }
    public void ActivateCred()
    {
        activateTimerCred = true;
    }
    public void DesacativateCred()
    {
        activateTimerCred = false;
    }
    public void ActivateExit()
    {
        activateTimerExit = true;
    }
    public void DesacativateExit()
    {
        activateTimerExit = false;
    }
}
