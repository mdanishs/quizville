using UnityEngine;
using System.Collections;

public class GameConstants {

    /** SCENE NAMES **/
    public static readonly string MENU_SCENE = "MainMenuScene";
    public static readonly string GAME_PLAY_SCENE = "GamePlayScene";
    public static readonly string LEVEL_SELECT_SCENE = "LevelSelect";

    /** PLAYER PREF KEYS **/
    public static readonly string FTUE_KEY = "FTUE";
    public static readonly string CURRNET_LEVEL_KEY = "CurrentLevel";
    public static readonly string MUTE_KEY = "Mute";
    public static readonly string LEVEL_SCORE_KEY = "LevelScore"; //this key is appended with chapter and number id
    public static readonly string LEVEL_STAR_KEY = "LevelStar"; //this key is appended with chapter and number id
    public static readonly string LAST_CLEARED_LEVEL = "LastClearedLevel"; //this key is appended with chapter and number id


    /** MISC **/
    public static readonly string LEVELS_FILE = "Levels";
    public static readonly bool CLEAR_DATA_ON_PLAY = false;
}
