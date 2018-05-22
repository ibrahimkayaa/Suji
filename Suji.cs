using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


namespace SJ{
    
    public static class Suji  {
        
        /// <summary>
        /// Splits the raw remote settings string with char from cloud.
        /// </summary>
        /// <param name="useChar">Char for splitting.</param>
        /// <param name="raw">Raw data string.</param>
        /// <param name="outList">Out list to retu.</param>
		public static void SplitRawRemoteSettingsStringWithChar(char useChar,string raw,out List<string> outList){
			
			outList = raw.Split(useChar).ToList();
		}
		
        /// <summary>
        /// Use this function to get current stage remote config values.
        /// </summary>
        /// <param name="currentStageIndex">Current stage index.</param>
        /// <param name="remoteSettingsStringList">Remote settings string list.</param>
        /// <param name="outList">Out list.</param>
        /// <param name="outBool">If set to <c>true</c> out bool.</param>
        public static void GetCurrentStageRemote(int currentStageIndex,List<string> remoteSettingsStringList,out List<int> outList,out bool outBool)
        {
            
            
            outList = new List<int>();
            
            if (currentStageIndex < 1) currentStageIndex = 0;
            if (currentStageIndex > remoteSettingsStringList.Count) currentStageIndex = 0;
            
            if(currentStageIndex - 1 < 0){
                
                outList = null;
                outBool = false;
            }else{
                List<string> tempList = remoteSettingsStringList[currentStageIndex - 1].Split(',').ToList();
                foreach(string tempS in tempList){
                    
                    int tempInt = int.Parse(tempS);
                    outList.Add(tempInt);
                    
                }
                outBool = true;
            }
        }
        
        /// <summary>
        /// Gets the remote value with id.
        /// Use linqed id for local variable to retireve the value which cast by cloud
        /// </summary>
        /// <returns>The value of the linqed variable with id</returns>
        /// <param name="id">İdentifier.</param>
        /// <param name="currentStageRemotes">Current stage remotes.</param>
        public static int GetRemoteValueWithId(int id, List<int>currentStageRemotes){

            int retInt = 0;

            if (id < 0) retInt = -1;
            if (id > currentStageRemotes.Count - 1) retInt = -1;

            if(retInt >= 0){

                retInt = currentStageRemotes[id];
            }

            return retInt;

        }

        /// <summary>
        /// Gets the random number with percantage Range(0,percantes.Length).
        /// </summary>
        /// <returns>The random number with percantage from zero.</returns>
        /// <param name="percantages">Percantages List.</param>
        public static int GetRandomNumberWithPercantageFromZero(List<int>percantages)
        {

            List<int> randomizeList = new List<int>();

            for (int i = 0; i < percantages.Count; i++)
            {

                int percantageIndex = percantages[i];

                int startIndex = 0;
                while (startIndex < percantages[i])
                {

                    randomizeList.Add(i);
                    startIndex++;
                }
            }


            int randomNumber = Random.Range(0, randomizeList.Count);

            return randomizeList[randomNumber];
        }

        /// <summary>
        /// Gets the random number with percantage Range(1,percantes.Length).
        /// </summary>
        /// <returns>The random number with percantage from one.</returns>
        /// <param name="percantages">Percantages List.</param>
        public static int GetRandomNumberWithPercantageFromOne(List<int> percantages)
        {

            List<int> randomizeList = new List<int>();

            for (int i = 0; i < percantages.Count; i++)
            {

                int percantageIndex = percantages[i];

                int startIndex = 0;
                while (startIndex < percantages[i])
                {

                    randomizeList.Add(i+1);
                    startIndex++;
                }
            }


            int randomNumber = Random.Range(0, randomizeList.Count);

            return randomizeList[randomNumber];
        }

        /// <summary>
        /// De Saturation of the color with Percantage
        /// </summary>
        /// <returns>The de-saturated color.</returns>
        /// <param name="getColor">Get color.</param>
        /// <param name="percantage">Percantage.</param>
        public static Color DeSaturateColor(Color getColor, int percantage)
        {

            float h, s, v;
            Color newColor = getColor;
            Color.RGBToHSV(getColor, out h, out s, out v);

            if (s <= 0.0001f)
            {

                return newColor;

            }else{

                float pFloat = (float)percantage / 100f;


                s = (s * (1f - pFloat));

                newColor = Color.HSVToRGB(h, s, v);
            }


            return newColor;
        }

        /// <summary>
        /// Saturation of the color with percantage
        /// </summary>
        /// <returns>The  saturated color.</returns>
        /// <param name="getColor">Get color.</param>
        /// <param name="percantage">Percantage.</param>
        public static Color SaturateColor(Color getColor, int percantage)
        {

            float h, s, v;
            Color newColor = getColor;
            Color.RGBToHSV(getColor, out h, out s, out v);

            if (s >= 0.999f)
            {

                return newColor;

            }
            else
            {

                float pFloat = (float)percantage / 100f;


                s = (s * (1f + pFloat));

                newColor = Color.HSVToRGB(h, s, v);
            }


            return newColor;
        }
	}

}
