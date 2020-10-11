using System.Collections.Generic;
using System.Web.Http;
using CelebsWebApi.Models;
using System.Net;
using System;


namespace CelebsWebApi.Controllers
{
    public class CelebsController : ApiController
    {
        protected const string imDBCelebsListUrl = "https://www.imdb.com/list/ls052283250/";
        protected static CelebsManagement celebsManagement = new CelebsManagement(imDBCelebsListUrl);

        [Route("api/celebs/InitCelebsList")]
        [HttpGet]
        public  List<Celeb> InitCelebsList()
        {
            return  celebsManagement.InitCelebsList();
        }

        [Route("api/celebs/DeleteCelebs/{indices}")]
        [HttpGet]
        public HttpStatusCode DeleteCelebs(string indices)
        {
            if (string.IsNullOrEmpty(indices)) {
                return HttpStatusCode.OK;
            }

            string[] strIndices = indices.Split(',');
            int[] removeIndices = Array.ConvertAll(strIndices, new Converter<string, int>(Convert.ToInt32));

            celebsManagement.RemoveCelebFromList(removeIndices);
            return HttpStatusCode.OK;
        }

        [Route("api/celebs/AddCeleb")]
        [HttpPost]
        public HttpStatusCode AddCeleb(Celeb celeb)
        {
            celebsManagement.AddCelebToList(celeb);
            return HttpStatusCode.OK;
        }
    }
}
