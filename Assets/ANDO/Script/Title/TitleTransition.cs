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
        //���j���[�I���ɐ؂�ւ��
        //OFF�ɂ���
        click.SetActive(false);
        //ON�ɂ���
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

	//�@�񓯊�����Ŏg�p����AsyncOperation
	private AsyncOperation async;
	//�@�V�[�����[�h���ɕ\������UI���
	[SerializeField]
	private GameObject loadUI;
	//�@�ǂݍ��ݗ���\������X���C�_�[
	[SerializeField]
	private Slider slider;

	public void NextScene()
	{
		//�@���[�h���UI���A�N�e�B�u�ɂ���
		loadUI.SetActive(true);
		ServiceLocator<ISoundService>.Instance.Stop();
		//�@�R���[�`�����J�n
		StartCoroutine("LoadData");
	}

	IEnumerator LoadData()
	{
		Debug.Log("�ʂ��Ă܂�");
		// �V�[���̓ǂݍ��݂�����
		async = SceneManager.LoadSceneAsync("GameScene");

		//�@�ǂݍ��݂��I���܂Ői���󋵂��X���C�_�[�̒l�ɔ��f������
		while (!async.isDone)
		{
			var progressVal = Mathf.Clamp01(async.progress / 0.9f);
			slider.value = progressVal;
			yield return null;
		}
	}
}
