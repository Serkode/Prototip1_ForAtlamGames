using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameControl : MonoBehaviour
{
    [Header("GameController Settings")]
    float CubeCreateTime;
    public float CubeTiming, cubeRandomCounter, enemyCreatingTime;

    public GameObject gun, gunRotation, goodJob, failed, congratulations;

    public GameObject cubeX2, cubeIkiyeBol, slime, turtle, spiderBlack, spiderBrown, spiderGreen;
    public GameObject metalonGreen, metalonPurple, metalonRed, pa_warrior, pa_drone, spikeBallBig, spikeBallSmall;

    public Vector3 CubeX2Loc, cubeIkiyeBolLoc;

    float randomCount;
    float enemyCreateTiming, enemyCount = 0, goNextLevelCounter;
    public short enemyFailNumber, enemyDestroyed = 0;

    bool slimeCreated = false, turtleCreated = false, endOfTheGame = false, spiderBlackCreated = false, spiderBrownCreated = false, spiderGreenCreated = false;
    bool paDroneCreated = false, paWarriorCreated = false, metalonGreenCreated = false, metalonPurpleCreated = false, metalonRedCreated = false;
    bool spikeBigCreated = false, spikeSmallCreated = false;

    public TMP_Text enemyCountText, enemyFailNumberText, enemyHitText, levelText;



    void Start()
    {
        if(PlayerPrefs.GetInt("savelevel") < SceneManager.GetActiveScene().buildIndex)//if current level is never saved befor, save it.
        {
            PlayerPrefs.SetInt("savelevel", SceneManager.GetActiveScene().buildIndex);
        }

        levelText.text = SceneManager.GetActiveScene().buildIndex.ToString();//for show the current level on the screen.
    }


    void Update()
    {
        CubeCreateTime += Time.deltaTime;
        if(CubeCreateTime >= CubeTiming)
        {
            randomCount = Random.Range(1, 10);
            if (randomCount < cubeRandomCounter)
            {
                Instantiate(cubeX2, CubeX2Loc, Quaternion.identity);
                Instantiate(cubeIkiyeBol, cubeIkiyeBolLoc, Quaternion.identity);
            }
            CubeCreateTime = 0;
        }

        if(Input.GetKeyDown(KeyCode.Escape))//go to main menu if touch "Back" on the phone during the game.
        {
            SceneManager.LoadScene("MainMenu");
        }

        if(SceneManager.GetActiveScene().buildIndex == 1)//if current level is 1
        {
            Level1Scene();
        }
        else if (SceneManager.GetActiveScene().buildIndex == 2)//if current level is 2
        {
            Level2Scene();
        }
        else if (SceneManager.GetActiveScene().buildIndex == 3)//if current level is 3
        {
            Level3Scene();
        }
        else if (SceneManager.GetActiveScene().buildIndex == 4)//if current level is 4
        {
            Level4Scene();
        }
        else if (SceneManager.GetActiveScene().buildIndex == 5)//if current level is 5
        {
            Level5Scene();
        }

    }

    void Level1Scene()
    {
        enemyCreateTiming += Time.deltaTime;
        if (enemyCreateTiming >= enemyCreatingTime)
        {
            if (enemyCount < 10 && !slimeCreated)//Creating Slime enemy
            {
                slimeCreated = true;
                turtleCreated = false;

                enemyCount++;
                enemyCreateTiming = 0;
                Instantiate(slime, new Vector3(Random.Range(-6.5f, 6.5f), -0.0944348f, 30f), slime.transform.rotation);
            }
            else if (enemyCount < 10 && !turtleCreated)//Creating Turtle enemy
            {
                turtleCreated = true;
                slimeCreated = false;

                enemyCount++;
                enemyCreateTiming = 0;
                Instantiate(turtle, new Vector3(Random.Range(-6.5f, 6.5f), -0.0944348f, 30f), turtle.transform.rotation);
            }
        }
        Debug.Log("Enemy count: " + enemyCount);
        enemyCountText.text = "Enemy: " + enemyCount + "/10";
        enemyFailNumberText.text = "Fail: " + enemyFailNumber;
        enemyHitText.text = "Destroyed: " + enemyDestroyed;

        if(enemyDestroyed+enemyFailNumber >= 10)
        {
            gun.GetComponent<GunControl>().enabled = false;

            if(enemyDestroyed > enemyFailNumber && !endOfTheGame)
            {

                Instantiate(goodJob, new Vector3(0, -5, 0), goodJob.transform.rotation);//Good Job Animation
            }
            else if(enemyDestroyed <= enemyFailNumber && !endOfTheGame)
            {

                Instantiate(failed, new Vector3(0, -5, 0), failed.transform.rotation);//Failed Animation
            }
            endOfTheGame = true;
        }

        if(endOfTheGame)
        {
            goNextLevelCounter += Time.deltaTime;
            if(goNextLevelCounter >=3)
            {
                if (enemyDestroyed > enemyFailNumber)//if destroyed enemy count is more than failed enemy count, go next level.
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
                else if (enemyDestroyed <= enemyFailNumber)//if failed enemy count is more than or equals destroyed enemy count, go main menu.
                {
                    SceneManager.LoadScene(0);
                }
            }
        }
    }
    //---------------------------------------------------
    //the following code structures are the same as above
    //---------------------------------------------------
    void Level2Scene()
    {
        enemyCreateTiming += Time.deltaTime;
        if (enemyCreateTiming >= enemyCreatingTime)
        {
            if (enemyCount < 10 && !spiderGreenCreated)
            {
                spiderGreenCreated = true;
                spiderBrownCreated = false;
                spiderBlackCreated = false;

                enemyCount++;
                enemyCreateTiming = 0;
                Instantiate(spiderGreen, new Vector3(Random.Range(-6.5f, 6.5f), -0.0944348f, 30f), spiderGreen.transform.rotation);
            }
            else if (enemyCount < 10 && !spiderBrownCreated)
            {
                spiderGreenCreated = true;
                spiderBrownCreated = true;
                spiderBlackCreated = false;

                enemyCount++;
                enemyCreateTiming = 0;
                Instantiate(spiderBrown, new Vector3(Random.Range(-6.5f, 6.5f), -0.0944348f, 30f), spiderBrown.transform.rotation);
            }
            else if (enemyCount < 10 && !spiderBlackCreated)
            {
                spiderGreenCreated = false;
                spiderBrownCreated = false;
                spiderBlackCreated = true;

                enemyCount++;
                enemyCreateTiming = 0;
                Instantiate(spiderBlack, new Vector3(Random.Range(-6.5f, 6.5f), -0.0944348f, 30f), spiderBlack.transform.rotation);
            }
        }
        Debug.Log("Enemy count: " + enemyCount);
        enemyCountText.text = "Enemy: " + enemyCount + "/10";
        enemyFailNumberText.text = "Fail: " + enemyFailNumber;
        enemyHitText.text = "Destroyed: " + enemyDestroyed;

        if (enemyDestroyed + enemyFailNumber >= 10)
        {
            gun.GetComponent<GunControl>().enabled = false;

            if (enemyDestroyed > enemyFailNumber && !endOfTheGame)
            {

                Instantiate(goodJob, new Vector3(0, -5, 0), goodJob.transform.rotation);
            }
            else if (enemyDestroyed <= enemyFailNumber && !endOfTheGame)
            {

                Instantiate(failed, new Vector3(0, -5, 0), failed.transform.rotation);
            }
            endOfTheGame = true;
        }

        if (endOfTheGame)
        {
            goNextLevelCounter += Time.deltaTime;
            if (goNextLevelCounter >= 3)
            {
                if (enemyDestroyed > enemyFailNumber)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
                else if (enemyDestroyed <= enemyFailNumber)
                {
                    SceneManager.LoadScene(0);
                }
            }
        }
    }


    void Level3Scene()
    {
        enemyCreateTiming += Time.deltaTime;
        if (enemyCreateTiming >= enemyCreatingTime)
        {
            if (enemyCount < 15 && !paWarriorCreated)
            {
                paWarriorCreated = true;
                paDroneCreated = false;

                enemyCount++;
                enemyCreateTiming = 0;
                Instantiate(pa_warrior, new Vector3(Random.Range(-6.5f, 6.5f), -0.0944348f, 30f), pa_warrior.transform.rotation);
            }
            else if (enemyCount < 15 && !paDroneCreated)
            {
                paWarriorCreated = false;
                paDroneCreated = true;

                enemyCount++;
                enemyCreateTiming = 0;
                Instantiate(pa_drone, new Vector3(Random.Range(-6.5f, 6.5f), pa_drone.transform.position.y, 30f), pa_drone.transform.rotation);
            }
        }
        Debug.Log("Enemy count: " + enemyCount);
        enemyCountText.text = "Enemy: " + enemyCount + "/15";
        enemyFailNumberText.text = "Fail: " + enemyFailNumber;
        enemyHitText.text = "Destroyed: " + enemyDestroyed;

        if (enemyDestroyed + enemyFailNumber >= 15)
        {
            gun.GetComponent<GunControl>().enabled = false;

            if (enemyDestroyed > enemyFailNumber && !endOfTheGame)
            {

                Instantiate(goodJob, new Vector3(0, -5, 0), goodJob.transform.rotation);
            }
            else if (enemyDestroyed <= enemyFailNumber && !endOfTheGame)
            {

                Instantiate(failed, new Vector3(0, -5, 0), failed.transform.rotation);
            }
            endOfTheGame = true;
        }

        if (endOfTheGame)
        {
            goNextLevelCounter += Time.deltaTime;
            if (goNextLevelCounter >= 3)
            {
                if (enemyDestroyed > enemyFailNumber)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
                else if (enemyDestroyed <= enemyFailNumber)
                {
                    SceneManager.LoadScene(0);
                }
            }
        }
    }

    void Level4Scene()
    {
        enemyCreateTiming += Time.deltaTime;
        if (enemyCreateTiming >= enemyCreatingTime)
        {
            if (enemyCount < 10 && !metalonGreenCreated)
            {
                metalonGreenCreated = true;
                metalonPurpleCreated = false;
                metalonRedCreated = false;

                enemyCount++;
                enemyCreateTiming = 0;
                Instantiate(metalonGreen, new Vector3(Random.Range(-6.5f, 6.5f), -0.0944348f, 30f), metalonGreen.transform.rotation);
            }
            else if (enemyCount < 10 && !metalonPurpleCreated)
            {
                metalonGreenCreated = true;
                metalonPurpleCreated = true;
                metalonRedCreated = false;

                enemyCount++;
                enemyCreateTiming = 0;
                Instantiate(metalonPurple, new Vector3(Random.Range(-6.5f, 6.5f), -0.0944348f, 30f), metalonPurple.transform.rotation);
            }
            else if (enemyCount < 10 && !metalonRedCreated)
            {
                metalonGreenCreated = false;
                metalonPurpleCreated = false;
                metalonRedCreated = true;

                enemyCount++;
                enemyCreateTiming = 0;
                Instantiate(metalonRed, new Vector3(Random.Range(-6.5f, 6.5f), -0.0944348f, 30f), metalonRed.transform.rotation);
            }
        }
        Debug.Log("Enemy count: " + enemyCount);
        enemyCountText.text = "Enemy: " + enemyCount + "/10";
        enemyFailNumberText.text = "Fail: " + enemyFailNumber;
        enemyHitText.text = "Destroyed: " + enemyDestroyed;

        if (enemyDestroyed + enemyFailNumber >= 10)
        {
            gun.GetComponent<GunControl>().enabled = false;

            if (enemyDestroyed > enemyFailNumber && !endOfTheGame)
            {

                Instantiate(goodJob, new Vector3(0, -5, 0), goodJob.transform.rotation);
            }
            else if (enemyDestroyed <= enemyFailNumber && !endOfTheGame)
            {

                Instantiate(failed, new Vector3(0, -5, 0), failed.transform.rotation);
            }
            endOfTheGame = true;
        }

        if (endOfTheGame)
        {
            goNextLevelCounter += Time.deltaTime;
            if (goNextLevelCounter >= 3)
            {
                if (enemyDestroyed > enemyFailNumber)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
                else if (enemyDestroyed <= enemyFailNumber)
                {
                    SceneManager.LoadScene(0);
                }
            }
        }
    }
    void Level5Scene()
    {
        enemyCreateTiming += Time.deltaTime;
        if (enemyCreateTiming >= enemyCreatingTime)
        {
            if (enemyCount < 15 && !spikeSmallCreated)
            {
                spikeSmallCreated = true;
                spikeBigCreated = false;

                enemyCount++;
                enemyCreateTiming = 0;
                Instantiate(spikeBallSmall, new Vector3(Random.Range(-6.5f, 6.5f), spikeBallSmall.transform.position.y, 30f), spikeBallSmall.transform.rotation);
            }
            else if (enemyCount < 15 && !spikeBigCreated)
            {
                spikeSmallCreated = false;
                spikeBigCreated = true;

                enemyCount++;
                enemyCreateTiming = 0;
                Instantiate(spikeBallBig, new Vector3(Random.Range(-6.5f, 6.5f), spikeBallBig.transform.position.y, 35f), spikeBallBig.transform.rotation);
            }
        }
        Debug.Log("Enemy count: " + enemyCount);
        enemyCountText.text = "Enemy: " + enemyCount + "/15";
        enemyFailNumberText.text = "Fail: " + enemyFailNumber;
        enemyHitText.text = "Destroyed: " + enemyDestroyed;

        if (enemyDestroyed + enemyFailNumber >= 15)
        {
            gun.GetComponent<GunControl>().enabled = false;

            if (enemyDestroyed > enemyFailNumber && !endOfTheGame)
            {

                Instantiate(congratulations, new Vector3(0, -5, 0), congratulations.transform.rotation);
            }
            else if (enemyDestroyed <= enemyFailNumber && !endOfTheGame)
            {

                Instantiate(failed, new Vector3(0, -5, 0), failed.transform.rotation);
            }
            endOfTheGame = true;
        }

        if (endOfTheGame)
        {
            goNextLevelCounter += Time.deltaTime;
            if (goNextLevelCounter >= 3)
            {
                if (enemyDestroyed > enemyFailNumber)
                {
                    //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);/*----------*/// Level is 5. So, no necessary to this code line.
                    SceneManager.LoadScene(0);
                }
                else if (enemyDestroyed <= enemyFailNumber)
                {
                    SceneManager.LoadScene(0);
                }
            }
        }
    }

    public void GoMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
