using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODUL8_1302210135
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }

    class BankTransferConfig
    {
        public BTConfig conifg;

        private string path = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;
        private string filename = "bank_transfer_config.json";

        public BankTransferConfig()
        {
            try
            {
                ReadConfigFile();
            }
            catch
            {
                SetDefaultConfig();
                WriteNewBTConfigFile();
            }
        }

        private BTConfig ReadConfigFile()
        {
            string configJsonString = File.ReadAllText(path + "/" + filename);
            configJsonString = JsonSerializer.Deserialize<BTConfig>(configJsonString);
            return config;
        }

        private void SetDefaultConfig()
        {
            BTTransfer bTTransfer = new BTTransfer(25000000, 6500, 15000);
            BTConfirmation bTConfirmation = new BTConfirmation("yes", "ya");
            List<string> methods = new List<string>() { "RTO(real - time)", "SKN", "RTGS", "BI FAST" };

            config = new BTConfig("en", bTTransfer, methods, bTConfirmation);
        }

        private void WriteNewBTConfigFile()
        {

        }
    }

    class BTConfig
    {
        public string lang{get; set;}
        public BTTransfer transfer { get; set; }
        public List<string> methods { get; set; }
        public BTConfirmation confirmation { get; set; }

        public BTConfig() { }

        public BTConfig(string lang, BTTransfer transfer, List<string> methods, BTConfirmation confirmation)
        {
            this.lang = lang;
            this.transfer = transfer;
            this.methods = methods;
            this.confirmation = confirmation;
        }
    }

    class BTTransfer
    {
        public double threshold { get; set;}
        public double low_fee { get; set;}
        public double high_fee { get; set;} 

        public BTTransfer() { }

        public BTTransfer(double threshold, double low_fee, double high_fee)
        {
            this.threshold = threshold;
            this.low_fee = low_fee;
            this.high_fee = high_fee;
        }
    }

    class BTConfirmation
    {
        public string en { get; set; }
        public string id { get; set; }

        public BTConfirmation() {
            this.en = en;
            this.id = id;
        }
    }
}
