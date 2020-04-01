using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDT
{
    class UserInterface
    {
        private Dictionary<string, string> UIPrimary = new Dictionary<string, string>();
       

        private Dictionary<string, string> UISecoundary = new Dictionary<string, string>();

        private Dictionary<string, string> UIPrimary_Hist = new Dictionary<string, string>();


        private Dictionary<string, string> UISecoundary_Hist = new Dictionary<string, string>();
        public UserInterface()
        {
            SetPrimaryUI();
            SetSecoundaryUI();
            SetPrimaryUI_History();
            SetSecoundaryUI_History(); 
        }

        public void SetPrimaryUI_History()
        {
           this.UIPrimary_Hist.Add("Production", " https://va22pwvegm307.corp.agp.ads:8087/tm/");



            this.UIPrimary_Hist.Add("Pre-Prod", "NULL_Pre-Prod");
            this.UIPrimary_Hist.Add("UAT", "https://va22twvegm314:8087/tm ");
            this.UIPrimary_Hist.Add("SIT2", "NULL_SIT2");
            this.UIPrimary_Hist.Add("SIT1", "NULL_SIT1");
            this.UIPrimary_Hist.Add("DEV3", " NULL_Dev3");
            this.UIPrimary_Hist.Add("DEV2", " NULL_DEV2");
            this.UIPrimary_Hist.Add("DEV1", "https://VA22DWVEGM324:8087/tm ");    



        }
        public void SetSecoundaryUI_History()
        {
          this.UISecoundary_Hist.Add("Production", "https://va22pwvegm347:8087/tm");




            this.UISecoundary_Hist.Add("Pre-Prod", "NULL_Pre-pred2");
            this.UISecoundary_Hist.Add("UAT", "https://va22twvegm316:8087/tm ");
            this.UISecoundary_Hist.Add("SIT2", "NULL_SIT2_2");
            this.UISecoundary_Hist.Add("SIT1", "NULL_SIT1_2");
            this.UISecoundary_Hist.Add("DEV3", " NULL_DEV3_2");
            this.UISecoundary_Hist.Add("DEV2", " NULL_DEV2_2");
            this.UISecoundary_Hist.Add("DEV1", "NULL_Dev1_2");


        }


        public void SetPrimaryUI()
        {
            this.UIPrimary.Add("Production", " https://va22pwvegm307.corp.agp.ads:8087/tm/");
            this.UIPrimary.Add("Pre-Prod", "https://va22pwvegm300.corp.agp.ads:8087/tm/");
            this.UIPrimary.Add("UAT", "http://va22twpegm400a:8161/");
            this.UIPrimary.Add("SIT2", "https://va22twvegm311:8087/tm/ ");
            this.UIPrimary.Add("SIT1", "https://va22twvegm300:8087/tm/");
            this.UIPrimary.Add("DEV3", " https://va22dwvegm306.corp.agp.ads:8087/tm/");
            this.UIPrimary.Add("DEV2", " https://va22dwvegm306.corp.agp.ads:8087/tm/");
            this.UIPrimary.Add("DEV1", "https://va22dwvegm300.corp.agp.ads:8087/tm/ ");



        }

        public string getPrimaryUI_History(string Enviroment)
        {

            if (UIPrimary_Hist.ContainsKey(Enviroment))
            {

                return this.UIPrimary_Hist[Enviroment];
            }
            else
            {
                return null;
            }


        }


        public string getPrimaryUI(string Enviroment)
        {

            if (UIPrimary.ContainsKey(Enviroment)){

                return this.UIPrimary[Enviroment];
            }
            else
            {
                return null;
            }


    }


        public void SetSecoundaryUI()
        {
            this.UISecoundary.Add("Production", "https://va22pwvegm308.corp.agp.ads:8087/tm/");
            this.UISecoundary.Add("PRE-PROD", "https://va22pwvegm301.corp.agp.ads:8087/tm/ ");
            this.UISecoundary.Add("UAT", "https://va22twvegm304:8087/tm/ ");
            this.UISecoundary.Add("SIT2", "https://va22twvegm312:8087/tm/");
            this.UISecoundary.Add("SIT1", "http://va22twvegm301:8161/");
            this.UISecoundary.Add("DEV3", "https://va22dwvegm307.corp.agp.ads:8087/tm/ ");
            this.UISecoundary.Add("DEV2", "https://va22dwvegm304.corp.agp.ads:8087/tm/ ");
            this.UISecoundary.Add("DEV1", "https://va22dwvegm301.corp.agp.ads:8087/tm/ ");



        }

        public string getSecoundaryUI_History(string Enviroment)
        {

            if (UISecoundary_Hist.ContainsKey(Enviroment))
            {

                return this.UISecoundary_Hist[Enviroment];
            }
            else
            {
                return null;
            }


        }


        public string getSecoundaryUI(string Enviroment)
        {

            if (UIPrimary.ContainsKey(Enviroment))
            {

                return this.UISecoundary[Enviroment];
            }
            else
            {
                return null;
            }


        }
    }
}