namespace CommonLibrary
{
    using System.Collections.Generic;

    /// <summary>
    /// Defines the <see cref="PagingGridView{T}" />
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PagingGridView<T>
    {
        /// <summary>
        /// Gets or sets the curentPage
        /// </summary>
        public int curentPage { get; set; }

        /// <summary>
        /// Gets or sets the curentSource
        /// </summary>
        public List<T> curentSource { get; set; }

        /// <summary>
        /// Gets or sets the pageSize
        /// </summary>
        public int pageSize { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PagingGridView{T}"/> class.
        /// </summary>
        public PagingGridView()
        {
            curentPage = 1;
            pageSize = 5;
            curentSource = new List<T>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PagingGridView{T}"/> class.
        /// </summary>
        /// <param name="curentPage">The curentPage<see cref="int"/></param>
        /// <param name="pageSize">The pageSize<see cref="int"/></param>
        /// <param name="curentSource">The curentSource<see cref="List{T}"/></param>
        public PagingGridView(int curentPage, int pageSize, List<T> curentSource)
        {
            this.curentPage = curentPage;
            this.pageSize = pageSize;
            this.curentSource = curentSource;
        }

        /// <summary>
        /// The GetPage
        /// </summary>
        /// <param name="page">The page<see cref="int"/></param>
        /// <returns>The <see cref="List{T}"/></returns>
        public List<T> GetPage(int page)
        {
            List<T> tempList = new List<T>();
            int pagee = (page - 1) * pageSize;
            for (int i = pagee; i < pagee + pageSize && i < curentSource.Count; i++)
                tempList.Add(curentSource[i]);
            return tempList;
        }

        /// <summary>
        /// The PrevPage
        /// </summary>
        /// <returns>The <see cref="List{T}"/></returns>
        public List<T> PrevPage()
        {
            if (curentPage > 1)
                curentPage--;
            return GetPage(curentPage);
        }

        /// <summary>
        /// The NextPage
        /// </summary>
        /// <returns>The <see cref="List{T}"/></returns>
        public List<T> NextPage()
        {
            curentPage++;
            return GetPage(curentPage);
        }
    }
}
