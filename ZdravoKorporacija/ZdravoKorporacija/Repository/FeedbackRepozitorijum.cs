using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using ZdravoKorporacija.Model;

namespace ZdravoKorporacija.Repository
{
    class FeedbackRepozitorijum
    {
        private string lokacija;
        private static FeedbackRepozitorijum _instance;
        public static FeedbackRepozitorijum Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new FeedbackRepozitorijum();
                }
                return _instance;
            }
        }
        public FeedbackRepozitorijum()
        {
            this.lokacija = @"..\..\..\Data\feedback.json";
        }
       
        public List<FeedbackForma> DobaviSve()
        {
            List<FeedbackForma> forme = new List<FeedbackForma>();
            if (File.Exists(lokacija))
            {
                string jsonText = File.ReadAllText(lokacija);
                if (!string.IsNullOrEmpty(jsonText))
                {
                    forme = JsonConvert.DeserializeObject<List<FeedbackForma>>(jsonText);
                }
            }
            return forme;
        }

        public void Sacuvaj(List<FeedbackForma> ankete)
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Formatting = Formatting.Indented;
            StreamWriter writer = new StreamWriter(lokacija);
            JsonWriter jWriter = new JsonTextWriter(writer);
            serializer.Serialize(jWriter, ankete);
            jWriter.Close();
            writer.Close();
        }
    }
}
