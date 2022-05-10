using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleTransition : MonoBehaviour
{
    [SerializeField] GameObject click;

    [SerializeField] GameObject menu;

    public void ClickOnTheScreen()
    {
        //メニュー選択に切り替わる
        //OFFにする
        click.SetActive(false);
        //ONにする
        menu.SetActive(true);
    }

	public void ClickExit()
    {
#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
	}

	//　非同期動作で使用するAsyncOperation
	private AsyncOperation async;
	//　シーンロード中に表示するUI画面
	[SerializeField]
	private GameObject loadUI;
	//　読み込み率を表示するスライダー
	[SerializeField]
	private Slider slider;

	public void NextScene()
	{
		//　ロード画面UIをアクティブにする
		loadUI.SetActive(true);
		ServiceLocator<ISoundService>.Instance.Stop();
		//　コルーチンを開始
		StartCoroutine("LoadData");
	}

	IEnumerator LoadData()
	{
		Debug.Log("通ってます");
		// シーンの読み込みをする
		async = SceneManager.LoadSceneAsync("GameScene");

		//　読み込みが終わるまで進捗状況をスライダーの値に反映させる
		while (!async.isDone)
		{
			var progressVal = Mathf.Clamp01(async.progress / 0.9f);
			slider.value = progressVal;
			yield return null;
		}
	}
}
