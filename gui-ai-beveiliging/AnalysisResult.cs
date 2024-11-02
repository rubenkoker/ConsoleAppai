using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gui_ai_beveiliging
{
    public class AnalysisResult
    {
        //<List<Dictionary<string, float>> batchresults = new List<List<Dictionary<string, float>>>();
        public string Filename;

        public List<Dictionary<string, float>> results;

        public AnalysisResult(string filename, List<Dictionary<string, float>> pairs)
        {
            Filename = filename;
            results = pairs;
        }
    }
}