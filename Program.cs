using System;
using tpmod8;

class Program
{
    static void Main(string[] args)
    {
        CovidConfig config = new CovidConfig();

        Console.WriteLine("Current Configuration:");
        Console.WriteLine("Satuan Suhu: " + config.GetSatuanSuhu());
        Console.WriteLine("Batas Hari Demam: " + config.GetBatasHariDemam());
        Console.WriteLine();

        Console.WriteLine("Berapa suhu badan anda saat ini? Dalam nilai " + config.GetSatuanSuhu());
        double suhu = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala deman?");
        int hariDemam = Convert.ToInt32(Console.ReadLine());

        bool isTemperatureNormal = false;
        bool isFeverDaysSafe = false;

        if (config.GetSatuanSuhu().ToLower() == "celcius")
        {
            if (suhu >= 36.5 && suhu <= 37.5)
            {
                isTemperatureNormal = true;
            }
        }
        else if (config.GetSatuanSuhu().ToLower() == "fahrenheit")
        {
            if (suhu >= 97.7 && suhu <= 99.5)
            {
                isTemperatureNormal = true;
            }
        }

        if (hariDemam < config.GetBatasHariDemam())
        {
            isFeverDaysSafe = true;
        }

        Console.WriteLine("\nHasil Pemeriksaan:");
        if (isTemperatureNormal && !isFeverDaysSafe)
        {
            Console.WriteLine(config.GetPesanDitolak());
        }
        else if (!isTemperatureNormal)
        {
            Console.WriteLine(config.GetPesanDitolak());
        }
        else
        {
            Console.WriteLine(config.GetPesanDiterima());
        }

        Console.WriteLine("\nMengubah satuan suhu...");
        config.UbahSatuan();
        Console.WriteLine("Satuan suhu sekarang: " + config.GetSatuanSuhu());

        Console.WriteLine("\nTekan tombol apa saja untuk keluar...");
        Console.ReadKey();
    }
}