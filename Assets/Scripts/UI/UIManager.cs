using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private CanvasGroup m_MainCanvasLayoutGroup;

    [SerializeField] private CanvasGroup m_TitleLayoutGroup;

    [SerializeField] private CanvasGroup m_WinLayoutGroup;

    [SerializeField] private CanvasGroup m_LoseLayoutGroup;

    [SerializeField] private CanvasGroup m_AwakeLayoutGroup;

    [SerializeField] private CanvasGroup m_OpaqueLayoutGroup;

    [SerializeField] private CanvasGroup m_BearWarningGroup;

    [SerializeField] private CanvasEvent OnControlsEnabled = new CanvasEvent();

    [SerializeField] private CanvasEvent OnControlsDisabled = new CanvasEvent();
    [System.Serializable] public class CanvasEvent : UnityEvent { };

    CanvasOpen currentOpenCanvas = CanvasOpen.None;
    enum CanvasOpen 
    {
        None,
        Title,
        Win,
        Lose,
        Awake,
        Bear

    }

	// Start is called before the first frame update
	void Awake()
    {
        SetCanvasGroupActiveWithAlpha(m_OpaqueLayoutGroup, true);
        SetCanvasGroupActiveWithAlpha(m_MainCanvasLayoutGroup, true);
        SetCanvasGroupActiveWithAlpha(m_TitleLayoutGroup, true);
        TweenCanvasToInvisible(m_OpaqueLayoutGroup, 2.0f).setDelay(1.0f).setOnComplete(OnOpaqueFadeOut);
        currentOpenCanvas = CanvasOpen.Title;
    }

	private void Start()
	{
        OnControlsDisabled.Invoke();
	}

	void OnOpaqueFadeOut() 
    {
        SetCanvasGroupActive(m_OpaqueLayoutGroup, false);
    }

    public void OnPressPlay() 
    {
        TweenCanvasToInvisible(m_MainCanvasLayoutGroup, 1.0f).setOnComplete(OnPressPlayTitleMenuCloseComplete);
    }

    public void OnEnableControls() { OnControlsEnabled.Invoke(); }
    public void OnDisableControls() { OnControlsDisabled.Invoke(); }
    void OnPressPlayTitleMenuCloseComplete() 
    {
        SetCanvasGroupActiveWithAlpha(m_TitleLayoutGroup, false);
        SetCanvasGroupActive(m_MainCanvasLayoutGroup, false);
        currentOpenCanvas = CanvasOpen.None;
        OnEnableControls();
    }

    public void BearWarning()
	{
        //Debug.Log("Hey");

        SetCanvasGroupActiveWithAlpha(m_BearWarningGroup, true);

        TweenCanvasToVisible(m_MainCanvasLayoutGroup, 0.5f).setOnComplete(OnBearWarningShown);
        
    }

    void OnBearWarningShown()
	{
        TweenCanvasToInvisible(m_MainCanvasLayoutGroup, 0.5f).setDelay(2f).setOnComplete(OnBearWarningComplete);
       
    }
    void OnBearWarningComplete()
	{
        SetCanvasGroupActiveWithAlpha(m_BearWarningGroup, false);
    }


    public void OnWinGame()
	{
        //Debug.Log("Beaten");
        if (currentOpenCanvas != CanvasOpen.None)
            return;
        OnDisableControls();
        currentOpenCanvas = CanvasOpen.Win;
        SetCanvasGroupActiveWithAlpha(m_WinLayoutGroup, true);
        TweenCanvasToVisible(m_MainCanvasLayoutGroup, 1.0f).setOnComplete(OnOpenMenuComplete);
	}
    public void OnLoseGame()
    {
        
        if (currentOpenCanvas != CanvasOpen.None)
            return;
        OnDisableControls();
        currentOpenCanvas = CanvasOpen.Lose;
        SetCanvasGroupActiveWithAlpha(m_LoseLayoutGroup, true);
        TweenCanvasToVisible(m_MainCanvasLayoutGroup, 1.0f).setOnComplete(OnOpenMenuComplete);
    }

    void OnOpenMenuComplete() 
    {
        SetCanvasGroupActive(m_MainCanvasLayoutGroup, true);
    }

    public void OnClickRestart() 
    {
        SetCanvasGroupActive(m_OpaqueLayoutGroup, false);
        TweenCanvasToVisible(m_OpaqueLayoutGroup, 1.0f).setDelay(0.5f).setOnComplete(OnClickRestartComplete);
    }

    void OnClickRestartComplete() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnBearHasAwakenFromHisEternalSlumber(){
        currentOpenCanvas = CanvasOpen.Awake;
        SetCanvasGroupActiveWithAlpha(m_AwakeLayoutGroup, true);
        TweenCanvasToVisible(m_OpaqueLayoutGroup, 1.0f).setDelay(0.5f);
    }


    void SetCanvasGroupActive(CanvasGroup canvasGroup, bool active) 
    {
        canvasGroup.blocksRaycasts = active;
        canvasGroup.interactable = active;
    }

    void SetCanvasGroupActiveWithAlpha(CanvasGroup canvasGroup, bool active) 
    {
        canvasGroup.blocksRaycasts = active;
        canvasGroup.interactable = active;
        canvasGroup.alpha = active ? 1.0f : 0.0f;
    }



    LTDescr TweenCanvasToVisible(CanvasGroup group, float time) 
    {
        return LeanTween.alphaCanvas(group, 1.0f, time);
    }

    LTDescr TweenCanvasToInvisible(CanvasGroup group, float time)
    {
        return LeanTween.alphaCanvas(group, 0.0f, time);
    }
}
