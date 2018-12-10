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
        /// Gets the random number with percentage from zero with dictionary.
        /// </summary>
        /// <returns>The random number with percentage from zero with dictionary.</returns>
        /// <param name="dictionary">Dictionary.</param>
        public static int GetRandomNumberWithPercentageFromZeroWithDictionary(Dictionary<int, int> dictionary)
        {
            int retInt = 0;
            List<int> randomizeList = new List<int>();

            for(int i = 0; i < dictionary.Count; i++)
            {

                int percentageIndex = dictionary.ElementAt(i).Value;

                int startIndex = 0;
                while(startIndex < dictionary.ElementAt(i).Value)
                {
                    randomizeList.Add(dictionary.ElementAt(i).Key);
                    startIndex++;
                }
            }

            retInt = Random.Range(0,randomizeList.Count);
            return randomizeList[retInt];
        }

        /// <summary>
        /// Sets the percentages list.
        /// </summary>
        /// <returns>The percentages list.</returns>
        /// <param name="dictionary">Dictionary.</param>
        public static List<int> SetPercentagesList(Dictionary<int,int> dictionary)
        {
            List<int> randomizeList = new List<int>();

            for (int i = 0; i < dictionary.Count; i++)
            {

                int percentageIndex = dictionary.ElementAt(i).Value;

                int startIndex = 0;
                while (startIndex < dictionary.ElementAt(i).Value)
                {
                    randomizeList.Add(dictionary.ElementAt(i).Key);
                    startIndex++;
                }
            }

           
            return randomizeList;
        }
        /// <summary>
        /// Sets the percentages list.
        /// </summary>
        /// <returns>The percentages list.</returns>
        /// <param name="intValue">İnt value.</param>
        public static List<int> SetPercentagesList(List<int> intValue){
            
            List<int> randomizeList = new List<int>();
            for (int i = 0; i < intValue.Count;i++){

               
                int startIndex = 0;

                while(startIndex < intValue[i]){

                    randomizeList.Add(i);
                    startIndex++;
                }

            }

            return randomizeList;
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
        /// Get Complimentary Color
        /// </summary>
        /// <param name="getColor"></param>
        /// <returns></returns>
        public static Color GetComplimentaryColor(Color getColor)
        {

            float h, s, v;
            Color newColor = getColor;
            Color.RGBToHSV(getColor, out h, out s, out v);

            //Debug.Log("h : " + h);
            float newH = h * 360;
            //Debug.Log("new h : " + newH);

            if(newH > 180)
            {

                newH -= 180f;
            }
            else
            {
                newH += 180f;
            }

            newH = newH / 360f;

            newColor = Color.HSVToRGB(newH, s, v);
            return newColor;
        }

        /// <summary>
        /// Dark the color.
        /// </summary>
        /// <returns>Darkest color of the given color with percentage.</returns>
        /// <param name="getColor">Get color.</param>
        /// <param name="percantage">Percantage.</param>
        public static Color DarkColor(Color getColor, int percantage)
        {
            float h, s, v;
            Color newColor = getColor;
            Color.RGBToHSV(getColor, out h, out s, out v);


            if (v < 0.001f)
            {
                return newColor;
            }
            else
            {

                float pFloat = (float)percantage / 100f;

                v = (v * (1f - pFloat));
                newColor = Color.HSVToRGB(h, s, v);
            }

            return newColor;


        }

        /// <summary>
        /// Gets The Triad Color combination with given color
        /// </summary>
        /// <param name="inputColor">İnput color.</param>
        /// <param name="secondColor">Second color.</param>
        /// <param name="thirdColor">Third color.</param>
        public static void GetTriadColor(Color inputColor, out Color secondColor, out Color thirdColor)
        {

            float h, s, v;
            secondColor = Color.white;
            thirdColor = Color.white;
            Color.RGBToHSV(inputColor, out h, out s, out v);

            float tempH = h * 360f;

            tempH += 120f;
            if (tempH >= 360) tempH -= 360f;
            tempH = tempH / 360f;
            secondColor = Color.HSVToRGB(tempH, s, v);
            tempH = tempH * 360f;
            tempH += 120f;
            if (tempH >= 360) tempH -= 360f;
            tempH = tempH / 360f;
            thirdColor = Color.HSVToRGB(tempH, s, v);

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

        //[System.Diagnostics.Conditional("DEVELOPMENT_BUILD")]
        public static void Log(string message)
        {

#if UNITY_EDITOR
            Debug.Log("sj-log : " + message);
#endif

        }
	}

}
