using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using ParandCartonUpdate.Models;

namespace ParandCartonUpdate.Formula
{
    public class OrderPriceFormula
    {
        public List<double> price(bool type, int reqcount, int roye, List<int> floot, List<int> liner, double arz, double tool, double ertefa, List<string> floottype , double zaribzayeat)
        {
            if (CheckPrice(roye , floot ,liner ))
            {
                double cofone = Getcostofone(type, roye, floot, liner, arz, tool, ertefa, floottype, zaribzayeat);
                double result = 1.25 * reqcount * cofone;
                List<double> final = new List<double>();
                final.Add(cofone);
                final.Add(result);
                return final;
            }
            else
            {
                List<double> data = new List<double>();
                data.Add(0);
                data.Add(0);
                return data;
            }
        }
        private bool CheckPrice(int roye, List<int> floot, List<int> liner)
        {
            bool flag = false;
            List<int> data = new List<int>();
            List<double> result = new List<double>();
            data.Add(roye);
            for (int i = 0; i < floot.Count; i++)
            {
                data.Add(floot[i]);
                data.Add(liner[i]);
            }
            for (int i = 0; i < data.Count; i++)
            {
                result.Add(Getcostofpermm(data[i]));
            }
            for (int i = 0; i < result.Count; i++)
            {
                if (result[i] == 0)
                {
                    flag = false;
                    break;
                }
                else
                {
                    flag = true;
                }
            }
            return flag;
        }
        private double Getcostofone(bool type, int roye, List<int> floot, List<int> liner, double arz, double tool, double ertefa, List<string> floottype, double zaribzayeat)
        {
            double hazinetolid = Getcostoftolid(type, roye, floot, liner, arz, tool, ertefa, floottype);
            double result = 1.1 * (hazinetolid + Getcostofzayeat(hazinetolid, zaribzayeat));
            return result;
        }
        private double Getcostoftolid(bool type, int roye, List<int> floot, List<int> liner, double arz, double tool, double ertefa, List<string> floottype)
        {
            double masahat = mc(arz, tool, ertefa);
            double result = 0;
            if (type == false)
            {
                result = (Getcostofroye(roye, masahat) + Getcostoffloot(floot[0], masahat, floottype[0]) + Getcostofliner(liner[0], masahat));
            }
            else if (type == true)
            {
                result = (Getcostofroye(roye, masahat) + Getcostoffloot(floot[0], masahat, floottype[0]) + Getcostofliner(liner[0], masahat) + Getcostoffloot(floot[1], masahat, floottype[1]) + Getcostofliner(liner[1], masahat));
            }
            return result;
        }
        private double Getcostofroye(int roye, double mc)
        {
            double result = Getcostofpermm(roye) * mc;
            return result;
        }
        private double Getcostofpermm(int id)
        {
            ParandCartondbEntities strd = new ParandCartondbEntities();
            var bs = strd.Layers.Where(w => w.Id == id).SingleOrDefault();
            double bsdb = Convert.ToDouble(bs.Price);
            return bsdb;
        }
        private double Getcostoffloot(int floot, double mc, string floottype)
        {
            double result = (Getcostofpermm(floot) * mc * GetZaribfloottype(floottype));
            return result;
        }
        private double Getcostofliner(int liner, double mc)
        {
            double result = (Getcostofpermm(liner) * mc);
            return result;
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
        private double mc(double arz, double tool, double ertefa)
        {
            double tol = 4 + ((2 * arz) + (2 * tool));
            double arzz = arz + ertefa;
            double result = (Convert.ToDouble(tol) * Convert.ToDouble(arzz)) / 10000;
            return result;
        }
        private double Getcostofzayeat(double data, double zaribzayeat)
        {
            double result = data * zaribzayeat;
            return result;
        }
    }
}