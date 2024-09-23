using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TPS
{
	public class Loader : MonoBehaviour
	{
		[Header("Elements")]
		[SerializeField] private Image _progressBar;

		private AsyncOperation _operation;

		[Header("Settings")]
		[SerializeField] private int _sceneToLoadIndex;



		private IEnumerator Start()
		{
			yield return new WaitForEndOfFrame();
			_operation = SceneManager.LoadSceneAsync(_sceneToLoadIndex);
		}


		private void Update()
		{
			if (_operation != null)
			{
				_progressBar.fillAmount = _operation.progress;
			}
		}
	}
}