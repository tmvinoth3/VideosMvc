using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Videos.Models;
using System.Data;

namespace Videos.Controllers
{
    //[Authorize]
    public class VideoController : ApiController
    {
        private videoDB db;

        public VideoController()
        {
            db = new videoDB();
            db.Configuration.ProxyCreationEnabled = false;
        }


        // GET api/video

        public IEnumerable<videos> GetAllVideos()
        {
            return db.videos;
        }

        // GET api/video/5
        public videos GetVideo(int id)
        {
            return db.videos.FirstOrDefault(x=>x.id==id);
            //if (video == null)
            //{
            //    throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            //}
            //return video;
        }

        // POST api/video
        [HttpPost]
        public HttpResponseMessage PostVideo(videos video)
        {
            var count = db.videos.Select(d => d).Count();
            video.id = Convert.ToInt32(count)+1;         
            db.Entry(video).State = EntityState.Added;
            try
            {
                db.SaveChanges();
            }
            catch (DBConcurrencyException)
            {

                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK, video);
        }


        // PUT api/video/5
        [HttpPut]
        public HttpResponseMessage PutVideo(int id, videos video)
        {
            if (ModelState.IsValid && id == video.id)
            {
                db.Entry(video).State = EntityState.Modified;
                try
                {
                    db.SaveChanges();
                }
                catch (DBConcurrencyException)
                {

                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
                return Request.CreateResponse(HttpStatusCode.OK, video);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/video/5
        [HttpDelete]
        public HttpResponseMessage DeleteVideo(int id)
        {
            videos video = new videos { id = id};

            if (ModelState.IsValid && db.videos.Any(x => x.id == id))
            {
                db.Entry(video).State = EntityState.Deleted;
                try
                {
                    db.SaveChanges();
                }
                catch (DBConcurrencyException)
                {

                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
                return Request.CreateResponse(HttpStatusCode.OK, video);
            }

            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

        }

    }
}

