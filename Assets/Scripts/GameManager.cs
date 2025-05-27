using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("UI Elements")]
    public GameObject winPanel;
    public Text timeText;
    public Image[] starImages;
    public Button restartButton;
    public Button mainMenuButton;

    [Header("Star Settings")]
    public Color emptyStarColor = new Color(0.3f, 0.3f, 0.3f, 0.5f);
    public Color goldenStarColor = Color.yellow;
    public float starAnimationDuration = 0.5f;

    private float startTime;
    private bool isGameActive = true;
    public ObjectScript objectScript;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        startTime = Time.time;
        winPanel.SetActive(false);
        InitializeStars();

        restartButton.onClick.AddListener(RestartLevel);
        mainMenuButton.onClick.AddListener(GoToMainMenu);
    }

    void InitializeStars()
    {
        foreach (Image star in starImages)
        {
            star.color = emptyStarColor;
            star.transform.localScale = Vector3.one * 0.8f;
        }
    }

    void Update()
    {
        if (isGameActive && objectScript != null && objectScript.CheckAllCarsInPlace())
        {
            WinGame();
        }
    }

    void WinGame()
    {
        isGameActive = false;
        winPanel.SetActive(true);

        float elapsedTime = Time.time - startTime;
        int stars = CalculateStars(elapsedTime);

        timeText.text = FormatTime(elapsedTime);
        StartCoroutine(AnimateStars(stars));

        objectScript.audioSource.PlayOneShot(objectScript.audioClips[14]);
    }

    IEnumerator AnimateStars(int starsCount)
    {
        for (int i = 0; i < starsCount; i++)
        {
            yield return new WaitForSeconds(0.3f);

            float timer = 0;
            Vector3 startScale = starImages[i].transform.localScale;
            Vector3 targetScale = Vector3.one * 1.3f;

            while (timer < starAnimationDuration / 2)
            {
                timer += Time.deltaTime;
                starImages[i].transform.localScale =
                    Vector3.Lerp(startScale, targetScale, timer / (starAnimationDuration / 2));
                starImages[i].color =
                    Color.Lerp(emptyStarColor, goldenStarColor, timer / (starAnimationDuration / 2));
                yield return null;
            }

            timer = 0;
            while (timer < starAnimationDuration / 2)
            {
                timer += Time.deltaTime;
                starImages[i].transform.localScale =
                    Vector3.Lerp(targetScale, Vector3.one, timer / (starAnimationDuration / 2));
                yield return null;
            }
        }
    }

    string FormatTime(float seconds)
    {
        System.TimeSpan time = System.TimeSpan.FromSeconds(seconds);
        return string.Format("{0:D2}:{1:D2}:{2:D2}",
               time.Hours, time.Minutes, time.Seconds);
    }

    int CalculateStars(float time)
    {
        if (time < 60f) return 3;   
        if (time < 120f) return 2;   
        return 1;                  
    }

    void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}