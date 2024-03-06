using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DrawAndRun {
    public class GameData: Singleton<GameData>
    {
        public int scorePerCrystal = 10;
        public int clonesStartNum = 12;   
    } 
}