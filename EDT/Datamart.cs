using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDT
{
    class Datamart
    {
        private Dictionary<string, string> DMPrimary = new Dictionary<string, string>();


        private Dictionary<string, string> DMSecoundary = new Dictionary<string, string>();

        private Dictionary<string, string> DMPrimary_Hist = new Dictionary<string, string>();


        private Dictionary<string, string> DMSecoundary_Hist = new Dictionary<string, string>();
        public Datamart()
        {
            SetPrimaryDM();
            SetSecoundaryDM();
            SetPrimaryDM_History();
            SetSecoundaryDM_History();
        }

        public void SetPrimaryDM_History()
        {
            this.DMPrimary_Hist.Add("Production", "http://va22dwvegm324.corp.agp.ads:8161/ ");

            this.DMPrimary_Hist.Add("Pre-Prod", " NULL_preprod");
            this.DMPrimary_Hist.Add("UAT", "http://va22twpegm400a:8162/");
            this.DMPrimary_Hist.Add("SIT2", " NULL_SIT2");
            this.DMPrimary_Hist.Add("SIT1", " NULL_SIT1");
            this.DMPrimary_Hist.Add("DEV3", "NULL_DEV3");
            this.DMPrimary_Hist.Add("DEV2", "NULL_DEV2");

            this.DMPrimary_Hist.Add("DEV1", "http://va22dwvegm303:8162/");




        }
        public void SetSecoundaryDM_History()
        {
            this.DMSecoundary_Hist.Add("Production", "Prod_NULL");
            this.DMSecoundary_Hist.Add("Pre-Prod", "NULL_Preprod");
            this.DMSecoundary_Hist.Add("UAT", "http://va22twpegm400b:8162/ ");
            this.DMSecoundary_Hist.Add("SIT2", "NULL_SIT2");
            this.DMSecoundary_Hist.Add("SIT", "NUL_SIT");
            this.DMSecoundary_Hist.Add("DEV3", "NULL_DEV3");
            this.DMSecoundary_Hist.Add("DEV2", "NULL DEV2");
            this.DMSecoundary_Hist.Add("DEV1", "http://va22dwvegm304:8162/");





        }


        public void SetPrimaryDM()
        {
            this.DMPrimary.Add("Production", "http://va22pwpegm400a.us.ad.wellpoint.com:8162/");
            this.DMPrimary.Add("Pre-Prod", "http://va22pwvegm300.corp.agp.ads:8162/");
            this.DMPrimary.Add("UAT", "http://va22twpegm400a:8162/");
            this.DMPrimary.Add("SIT2", "NULL_SIT2");
            this.DMPrimary.Add("SIT1", "http://va22twvegm300:8162/ ");
            this.DMPrimary.Add("DEV3", "http://va22dwvegm306:8162/ ");
            this.DMPrimary.Add("DEV2", "http://va22dwvegm303:8162/ ");
            this.DMPrimary.Add("DEV1", "http://va22dwvegm300.corp.agp.ads:8162/");


        }

        public string getPrimaryDM_History(string Enviroment)
        {

            if (DMPrimary_Hist.ContainsKey(Enviroment))
            {

                return this.DMPrimary_Hist[Enviroment];
            }
            else
            {
                return null;
            }


        }


        public string getPrimaryDM(string Enviroment)
        {

            if (DMPrimary.ContainsKey(Enviroment))
            {

                return this.DMPrimary[Enviroment];
            }
            else
            {
                return null;
            }


        }


        public void SetSecoundaryDM()
        {
            this.DMSecoundary.Add("Production", "http://va22pwpegm400b.us.ad.wellpoint.com:8162/");
            this.DMSecoundary.Add("Pre-Prod", "http://va22pwvegm301.corp.agp.ads:8162/  ");
            this.DMSecoundary.Add("UAT", "http://va22twpegm400b:8162/");
            this.DMSecoundary.Add("SIT2", "NULL_SIT2 ");
            this.DMSecoundary.Add("SIT1", "http://va22twvegm301:8162/ ");
            this.DMSecoundary.Add("DEV3", "http://va22dwvegm307:8162/");
            this.DMSecoundary.Add("DEV2", "http://va22dwvegm304:8162/ ");
            this.DMSecoundary.Add("DEV1", "http://va22dwvegm301.corp.agp.ads:8162/ ");




        }

        public string getSecoundaryDM_History(string Enviroment)
        {

            if (DMSecoundary_Hist.ContainsKey(Enviroment))
            {

                return this.DMSecoundary_Hist[Enviroment];
            }
            else
            {
                return null;
            }


        }


        public string getSecoundaryDM(string Enviroment)
        {

            if (DMSecoundary.ContainsKey(Enviroment))
            {

                return this.DMSecoundary[Enviroment];
            }
            else
            {
                return null;
            }


        }
    }
}
