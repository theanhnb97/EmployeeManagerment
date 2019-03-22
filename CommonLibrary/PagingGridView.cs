using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary
{
    /// <summary>
    /// Page Size Generic Create by TheAnh <3 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PagingGridView<T>
    {
        public int CurentPage { get; set; }
        public List<T> CurentSource { get; set; }
        public int PageSize { get; set; }

        public PagingGridView()
        {
            CurentPage = 1;
            PageSize = 5;
            CurentSource =new List<T>();
        }
        public PagingGridView(int curentPage,int pageSize, List<T> curentSource)
        {
            CurentPage = curentPage;
            PageSize = pageSize;
            CurentSource = curentSource;
        }
        public List<T> GetPage(int page)
        {
            List<T> tempList = new List<T>();
            int pagee = (page - 1) * PageSize;
            for (int i = pagee; i < pagee + PageSize && i < CurentSource.Count; i++)
                tempList.Add(CurentSource[i]);
            return tempList;
        }
        public List<T> PrevPage()
        {
            if (CurentPage > 1)
                CurentPage--;
            return GetPage(CurentPage);
        }
        public List<T> NextPage()
        {
            CurentPage++;
            return GetPage(CurentPage);
        }
    }
}
