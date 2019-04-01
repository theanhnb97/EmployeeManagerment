using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Salary
{
    public class CbbData
    {
        public Dictionary<int, string> cbbRankItems = new Dictionary<int, string>();
        public Dictionary<int, string> cbbBasicItems = new Dictionary<int, string>();
        public Dictionary<int, string> cbbBussinessItems = new Dictionary<int, string>();
        public Dictionary<int, string> cbbCoefficientItems = new Dictionary<int, string>();
        public CbbData()
        {
            //Rank Source
            cbbRankItems.Add(1, "Giam Doc");
            cbbRankItems.Add(2, "Truong Phong");
            cbbRankItems.Add(3, "Nhan Vien");
            // Basic Salary Source
            cbbBasicItems.Add(3, "3");
            cbbBasicItems.Add(4, "4");
            cbbBasicItems.Add(5, "5");
            cbbBasicItems.Add(6, "6");
            // Bussiness Salary Source
            cbbBussinessItems.Add(5, "5");
            cbbBussinessItems.Add(6, "6");
            cbbBussinessItems.Add(7, "7");
            cbbBussinessItems.Add(8, "8");
            // Coefficient Salary Source
            cbbCoefficientItems.Add(1, "2.34");
            cbbCoefficientItems.Add(2, "2.67");
            cbbCoefficientItems.Add(3, "3.0");
            cbbCoefficientItems.Add(4, "3.33");
        }


    }
}
