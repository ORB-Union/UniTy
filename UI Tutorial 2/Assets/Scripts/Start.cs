using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Start : MonoBehaviour {
	
	void Awake() {
        
    }

    public void StartButton()
    {
        Invoke("startgame", 3f);        
        //invoke 함수는 startgame 이라는 함수를 실행시켜주는데 몇초뒤(3f는 3초뒤)에 실행 시켜줄거냐 이다.
    }

    void startgame()
    {
        Application.LoadLevel("InGame Zeta");
    }


    public void optionbutton()
    {
        Invoke("OptionGame", 0f);
        //invoke 함수는 startgame 이라는 함수를 실행시켜주는데 몇초뒤(3f는 3초뒤)에 실행 시켜줄거냐 이다.
    }

    void OptionGame()
    {
        Application.LoadLevel("InGame");
    }

    public void TitleButton()
    {
        Invoke("MainTitleGame", 0f);
    }

    void MainTitleGame()
    {
        Application.LoadLevel("MainTitle");
    
    }
}
