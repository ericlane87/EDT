using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDT
{
    class ActiveMQ
    {
        private Dictionary<string, string> AQPrimary = new Dictionary<string, string>();


        private Dictionary<string, string> AQSecoundary = new Dictionary<string, string>();

        private Dictionary<string, string> AQPrimary_Hist = new Dictionary<string, string>();


        private Dictionary<string, string> AQSecoundary_Hist = new Dictionary<string, string>();
        public ActiveMQ()
        {
            SetPrimaryAQ();
            SetSecoundaryAQ();
            SetPrimaryAQ_History();
            SetSecoundaryAQ_History();
        }

        public void SetPrimaryAQ_History()
        {
            
            this.AQPrimary_Hist.Add("Production", "http://va22pwpegm001:8189/");

            this.AQPrimary_Hist.Add("Pre-Prod", " NULL_preprod");
            this.AQPrimary_Hist.Add("UAT", " http://va22twvegm314:8161/ ");
            this.AQPrimary_Hist.Add("SIT2", " NULL_SIT2");
            this.AQPrimary_Hist.Add("SIT1", " NULL_SIT1");
            this.AQPrimary_Hist.Add("DEV3", "NULL_DEV3");
            this.AQPrimary_Hist.Add("DEV2", "NULL_DEV2");

            this.AQPrimary_Hist.Add("DEV1", "http://va22dwvegm324.corp.agp.ads:8161/");




        }
        public void SetSecoundaryAQ_History()
        {
            this.AQSecoundary_Hist.Add("Production", "NULL_Prod");
            this.AQSecoundary_Hist.Add("Pre-Prod", "NULL_Preprod");
            this.AQSecoundary_Hist.Add("UAT", "http://va22twvegm316:8161/");
            this.AQSecoundary_Hist.Add("SIT2", "NULL_SIT2");
            this.AQSecoundary_Hist.Add("SIT", "NUL_SIT");
            this.AQSecoundary_Hist.Add("DEV3", "NULL_DEV3");
            this.AQSecoundary_Hist.Add("DEV2", "NULL DEV2");
            this.AQSecoundary_Hist.Add("DEV1", "https://va22pwvegm347:8087/tm");





        }


        public void SetPrimaryAQ()
        {
            this.AQPrimary.Add("Production", "http://va22pwpegm400a.us.ad.wellpoint.com:8161");
            this.AQPrimary.Add("Pre-Prod", "http://va22pwvegm300.corp.agp.ads:8161/ ");
            this.AQPrimary.Add("UAT", "http://va22pwpegm400a.us.ad.wellpoint.com:8161");
            this.AQPrimary.Add("SIT2", "http://va22twvegm311:8161/ ");
            this.AQPrimary.Add("SIT1", "http://va22twvegm300:8161/ ");
            this.AQPrimary.Add("DEV3", "http://va22dwvegm306:8161/");
            this.AQPrimary.Add("DEV2", "http://va22dwvegm303:8161/");
            this.AQPrimary.Add("DEV1", "http://va22dwvegm300.corp.agp.ads:8161/ ");


        }

        public string getPrimaryAQ_History(string Enviroment)
        {

            if (AQPrimary_Hist.ContainsKey(Enviroment))
            {

                return this.AQPrimary_Hist[Enviroment];
            }
            else
            {
                return null;
            }


        }


        public string getPrimaryAQ(string Enviroment)
        {

            if (AQPrimary.ContainsKey(Enviroment))
            {

                return this.AQPrimary[Enviroment];
            }
            else
            {
                return null;
            }


        }


        public void SetSecoundaryAQ()
        {
            this.AQSecoundary.Add("Production", "http://va22pwpegm400b.us.ad.wellpoint.com:8161/");
            this.AQSecoundary.Add("Pre-Prod", "http://va22pwvegm301.corp.agp.ads:8161/ ");
            this.AQSecoundary.Add("UAT", "http://va22twpegm400b:8161/");
            this.AQSecoundary.Add("SIT2", "https://va22twvegm312:8087/tm/ ");
            this.AQSecoundary.Add("SIT1", "http://va22twvegm301:8161/ ");
            this.AQSecoundary.Add("DEV3", "http://va22dwvegm307:8161/ ");
            this.AQSecoundary.Add("DEV2", "http://va22dwvegm304:8161/");
            this.AQSecoundary.Add("DEV1", "http://va22dwvegm301.corp.agp.ads:8161/ ");




        }

        public string getSecoundaryAQ_History(string Enviroment)
        {

            if (AQSecoundary_Hist.ContainsKey(Enviroment))
            {

                return this.AQSecoundary_Hist[Enviroment];
            }
            else
            {
                return null;
            }


        }


        public string getSecoundaryAQ(string Enviroment)
        {

            if (AQSecoundary.ContainsKey(Enviroment))
            {

                return this.AQSecoundary[Enviroment];
            }
            else
            {
                return null;
            }


        }



    }
}
