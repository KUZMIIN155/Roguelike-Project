using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelNext : MonoBehaviour
{
    public GameObject m_player;
    public GameObject m_canvas;
    public GameObject m_camera;
    public GameObject A;
    public string m_Scene;
    private int StrCr = 1;

    void Start()
    {
        
    }

    void Update()
    {

    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            //SceneManager.MoveGameObjectToScene(m_player, SceneManager.GetSceneByName(m_Scene));
            //SceneManager.MoveGameObjectToScene(m_canvas, SceneManager.GetSceneByName(m_Scene));
            //SceneManager.MoveGameObjectToScene(m_camera, SceneManager.GetSceneByName(m_Scene));
            if (StrCr >= 1)
            {
                StartCoroutine(LoadYourAsyncScene());
                StrCr --;
                A.SetActive(false);
            }
        }
    }

    IEnumerator LoadYourAsyncScene()
    {
        // Получаем текущюю сцену. Потом её нужно будет выгрузить
        Scene currentScene = SceneManager.GetActiveScene();
 
        // Загружаем нужную сцену в фоновом режиме вместе с текущей сценой.
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(m_Scene, LoadSceneMode.Additive);
 
        // Ждем пока всё загружиться
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
 
        // Перемещаем объект в загруженную сцену.
        SceneManager.MoveGameObjectToScene(m_player, SceneManager.GetSceneByName(m_Scene));
        SceneManager.MoveGameObjectToScene(m_canvas, SceneManager.GetSceneByName(m_Scene));
        SceneManager.MoveGameObjectToScene(m_camera, SceneManager.GetSceneByName(m_Scene));
        // Выгружаем предыдущую сцену.
        SceneManager.UnloadSceneAsync(currentScene);
    }
}
