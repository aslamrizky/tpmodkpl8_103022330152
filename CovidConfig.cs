using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace tpmod8
{
    class CovidConfig
    {
        private string satuanSuhu;
        private int batasHariDemam;
        private string pesanDitolak;
        private string pesanDiterima;
        private string configFilePath = "covid_config.json";

        public CovidConfig()
        {
            this.satuanSuhu = "celcius";
            this.batasHariDemam = 14;
            this.pesanDitolak = "Anda tidak diperbolehkan masuk ke dalam gedung ini";
            this.pesanDiterima = "Anda dipersilahkan untuk masuk ke dalam gedung ini";

            try
            {
                LoadConfig();
            }
            catch (Exception e)
            {
                Console.WriteLine("Config file not found or invalid. Using default values.");
                SaveConfig();
            }
        }

        public void LoadConfig()
        {
            if (File.Exists(configFilePath))
            {
                string jsonString = File.ReadAllText(configFilePath);
                JsonDocument doc = JsonDocument.Parse(jsonString);
                JsonElement root = doc.RootElement;

                this.satuanSuhu = root.GetProperty("satuan_suhu").GetString();
                this.batasHariDemam = int.Parse(root.GetProperty("batas_hari_deman").GetString());
                this.pesanDitolak = root.GetProperty("pesan_ditolak").GetString();
                this.pesanDiterima = root.GetProperty("pesan_diterima").GetString();
            }
        }

        public void SaveConfig()
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            var configObj = new
            {
                satuan_suhu = this.satuanSuhu,
                batas_hari_deman = this.batasHariDemam.ToString(),
                pesan_ditolak = this.pesanDitolak,
                pesan_diterima = this.pesanDiterima
            };

            string jsonString = JsonSerializer.Serialize(configObj, options);
            File.WriteAllText(configFilePath, jsonString);
        }

        public string GetSatuanSuhu()
        {
            return this.satuanSuhu;
        }

        public int GetBatasHariDemam()
        {
            return this.batasHariDemam;
        }

        public string GetPesanDitolak()
        {
            return this.pesanDitolak;
        }

        public string GetPesanDiterima()
        {
            return this.pesanDiterima;
        }

        public void SetSatuanSuhu(string satuanSuhu)
        {
            this.satuanSuhu = satuanSuhu;
            SaveConfig();
        }

        public void SetBatasHariDemam(int batasHariDemam)
        {
            this.batasHariDemam = batasHariDemam;
            SaveConfig();
        }

        public void SetPesanDitolak(string pesanDitolak)
        {
            this.pesanDitolak = pesanDitolak;
            SaveConfig();
        }

        public void SetPesanDiterima(string pesanDiterima)
        {
            this.pesanDiterima = pesanDiterima;
            SaveConfig();
        }

        public void UbahSatuan()
        {
            if (this.satuanSuhu.ToLower() == "celcius")
            {
                this.satuanSuhu = "fahrenheit";
            }
            else
            {
                this.satuanSuhu = "celcius";
            }
            SaveConfig();
        }
    }
}
