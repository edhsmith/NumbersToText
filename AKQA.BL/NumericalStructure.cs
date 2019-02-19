using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AKQA.BL
{
    /// <summary>
    /// Contains the list of common text to describe a number.
    /// </summary>
    public class NumericalStructure:Dictionary<string,int>
    {
        public NumericalStructure() : base(32)
        {
            
        }

        public  static NumericalStructure Initialise()
        {
            NumericalStructure result = null;
            
            using (Stream resourceStream = typeof(NumericalStructure).Assembly.GetManifestResourceStream("AKQA.BL.NumberStructure.json"))
            {
                using (StreamReader reader = new StreamReader(resourceStream))
                {
                    result = JsonConvert.DeserializeObject<NumericalStructure>(reader.ReadToEnd());
                }
            }
            return result;
        }

    }
}
