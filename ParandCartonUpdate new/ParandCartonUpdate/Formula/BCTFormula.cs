using Microsoft.Ajax.Utilities;
using ParandCartonUpdate.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure.Interception;
using System.Linq;
using System.Web;

namespace ParandCartonUpdate.Formula
{
    public class BCTFormula
    {
        public double KgBCTcalculate(double vazn, double ertefa, bool sardkhane, bool space, int fasale, int zamananbaresh, bool chideman, string rtobat, string tedadrang, string mizanchap, bool daste, bool havakesh)
        {
            double result = new double();
            double G = Convert.ToDouble(vazn) * (The_number_of_stackable_cartons(ertefa) - 1);
            double kgbct = G * Safety_factor(G, mizanchap, tedadrang, chideman, space, fasale, zamananbaresh, rtobat, sardkhane, havakesh, daste);
            result = kgbct;
            return result;
        }
        //public double NwBCTcalculate(double kgbct)
        //{
        //    double result = 9.80665 * kgbct;
        //    return result;
        //}
        private double The_number_of_stackable_cartons(double ertefa)
        {
            int height = Convert.ToInt32(ertefa);
            int result = 255 / height;
            return result;
        }
        private double Safety_factor(double G, string mizanchap, string tedadrang, bool chideman, bool space, int fasale, int zamananbaresh, string rtobat, bool sardkhane, bool havakesh, bool daste)
        {
            double allsafety = (The_amount_of_printing(mizanchap) * G) + (Number_of_printing_colors(tedadrang) * G) + (How_to_arrange(chideman) * G) +
                (empty_space(space) * G) + (Shipping_distance(fasale) * G) + (storage_period(zamananbaresh) * G) + (humidity(rtobat) * G) + (stored_in_the_cold_room(sardkhane) * G) +
                (ventilator(havakesh) * G) + (hand_place(daste) * G);
            double safety = (allsafety / G) + 1.2;
            return safety;
        }
        private double The_amount_of_printing(string mizanchap)
        {
            string amount = mizanchap.Trim();
            switch (amount)
            {
                case "10%":
                    return 0;
                case "25%":
                    return 0.05;
                case "50%":
                    return 0.1;
                case "75%":
                    return 0.15;
                case "100%":
                    return 0.25;
                default:
                    return 0;
            }
        }
        private double Number_of_printing_colors(string tedadrang)
        {
            string number = tedadrang.Trim();
            switch (number)
            {
                case "0":
                    return 0;
                case "یک":
                    return 0.1;
                case "دو":
                    return 0.13;
                case "سه":
                    return 0.16;
                case "چهار":
                    return 0.2;
                case "پنج":
                    return 0.24;
                default: return 0;

            }
        }
        private double How_to_arrange(bool chideman)
        {
            var layout = chideman;
            if (layout == true)
            {
                return 0;
            }
            else
            {
                return 0.15;
            }
        }
        private double empty_space(bool space)
        {
            if (space == true)
            {
                return 0.6;
            }
            else
            {
                return 0;
            }
        }
        private double Shipping_distance(int fasale)
        {
            if (fasale > 0 && fasale < 50)
            {
                return 0.05;
            }
            else if (fasale <= 200)
            {
                return 0.15;
            }
            else
            {
                return 0.4;
            }
        }
        private double storage_period(int zamananbaresh)
        {
            if (zamananbaresh < 10 && zamananbaresh > 0)
            {
                return 0.37;
            }
            else if (zamananbaresh <= 30)
            {
                return 0.4;
            }
            else if (zamananbaresh <= 90)
            {
                return 0.45;
            }
            else
            {
                return 0.5;
            }
        }
        private double humidity(string rtobat)
        {
            int humidity = Convert.ToInt32(rtobat);
            switch (humidity)
            {
                case 1:
                    return 0;
                case 2:
                    return 0.1;
                case 3:
                    return 0.2;
                case 4:
                    return 0.32;
                case 5:
                    return 0.52;
                default:
                    return 0;
            }
        }
        private double stored_in_the_cold_room(bool sardkhane)
        {
            var coldroom = sardkhane;
            if (coldroom == true)
            {
                return 0.32;
            }
            else
            {
                return 0;
            }
        }
        private double ventilator(bool havakesh)
        {
            if (havakesh)
            {
                return 0.1;
            }
            else { return 0; }

        }
        private double hand_place(bool daste)
        {
            if (daste)
            {
                return 0.1;
            }
            else { return 0; }
        }
        public double GetBCTKGwithlayer(double ECT, List<string> floottype, double arz, double tool)
        {
            double BCTKG = GetBCTnewton(ECT, floottype, arz, tool) / 9.80665;
            return BCTKG;
        }
        private double GetBCTnewton(double ECT, List<string> floottype, double arz, double tool)
        {
            ECTFormula ect = new ECTFormula();
            double BCTnewton = 5.78 * ECT * Math.Sqrt(GetZaribzekhamatfloot(floottype) * Getmohitjabe(arz, tool));
            return BCTnewton;
        }
        private double Getmohitjabe(double arz, double tool)
        {
            double result = ((10 * arz) + (10 * tool)) * 2;
            return result;
        }
        private double GetZaribzekhamatfloot(List<string> data)
        {
            string lsttostrdata = Lsttostrdata(data);
            switch (lsttostrdata)
            {
                case "B":
                    return 2.6;
                case "C":
                    return 3.9;
                case "E":
                    return 1.5;
                case "EB":
                    return 3.8;
                case "BE":
                    return 3.8;
                case "EC":
                    return 5.8;
                case "CE":
                    return 5.8;
                case "BC":
                    return 7.1;
                case "CB":
                    return 7.1;
                default:
                    return 0;
            }
        }
        private string Lsttostrdata(List<string> data)
        {
            string result = string.Join("", data.ToArray());
            return result.Trim();
        }
    }
}