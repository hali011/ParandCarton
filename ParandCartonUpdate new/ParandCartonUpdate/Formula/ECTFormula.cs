using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ParandCartonUpdate.Models;

namespace ParandCartonUpdate.Formula
{
    public class ECTFormula
    {
        public List<double> GetECT(bool type, int roye, List<int> liner, List<int> floot, List<string> floottype,double arz , double ertefa)
        {
            List<double> data = new List<double>();
            if (type == true)
            {
                double result = 1.28 * (GetZaribroye(roye) + GetZaribliner(liner[0]) + GetZaribliner(liner[1]) + (GetZaribfloot(floot[0]) * GetZaribfloottype(floottype[0])) + (GetZaribfloot(floot[1]) * GetZaribfloottype(floottype[1])));
                data.Add(result);
            }
            else 
            {
                double result = 1.28 * (GetZaribroye(roye) + GetZaribliner(liner[0]) + (GetZaribfloot(floot[0]) * GetZaribfloottype(floottype[0])));
                data.Add(result);
            }
            double wasterate = GetZaribzayeat(arz, ertefa ,roye , liner , floot);
            data.Add(wasterate);
            return data;
        }
        private double GetZaribroye(int data)
        {
            ParandCartondbEntities sda = new ParandCartondbEntities();
            var bs = sda.Layers.Where(w => w.Id == data).SingleOrDefault();
            return bs.RCT;
        }
        private double GetZaribliner(int data)
        {
            ParandCartondbEntities sda = new ParandCartondbEntities();
            var bs = sda.Layers.Where(w => w.Id == data).SingleOrDefault();
            return bs.RCT;
        }
        private double GetZaribfloot(int data)
        {
            ParandCartondbEntities sda = new ParandCartondbEntities();
            var bs = sda.Layers.Where(w => w.Id == data).SingleOrDefault();
            return bs.RCT;
        }
        private double GetZaribfloottype(string data)
        {
            switch (data)
            {
                case "B":
                    return 1.35;
                case "C":
                    return 1.45;
                case "E":
                    return 1.25;
                default:
                    return 0;
            }
        }
        private double GetZaribzayeat(double arz, double ertefa, int roye, List<int> liner, List<int> floot)
        {
            arz = arz + ertefa;
            var lowarz = Getlowarz(roye , liner , floot);
            double result = calculatezayeat(arz,lowarz);
            return result;
        }
        private double Getlowarz(int roye, List<int> liner, List<int> floot)
        {
            List<int> data = new List<int>();
            data.Add(roye);
            for (int i = 0; i < liner.Count; i++)
            {
                data.Add(liner[i]);
            }
            for (int i = 0; i < floot.Count; i++)
            {
                data.Add(floot[i]);
            }
            var alllayer = GetWidth(data);
            var result = alllayer.Min();
            return result;
        }
        private List<int> GetWidth(List<int> data)
        {
            List<int> result = new List<int>();
            List<Layer> ly = new List<Layer>();
            using (ParandCartondbEntities db = new ParandCartondbEntities())
            {
                ly = db.Layers.ToList();
            }
            for (int i = 0; i < data.Count; i++)
            {
                var layer = ly.Where(w => w.Id == data[i]).SingleOrDefault();
                result.Add(layer.Width);
            }
            return result;
        }
        private double calculatezayeat(double arz , double lowarz)
        {
            double test = (lowarz - 3) / arz;
            double c28 = test;
            double b36 = lowarz;
            double b38 = c28 * arz;
            double result = (b36 - b38) / 100;
            return result;
        }
    }
}