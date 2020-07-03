using LandingPageSignup.DAL;
using LandingPageSignup.Models;
using System;
using System.Web.Http;

namespace LandingPageSignup.Controllers
{
    public class SignupController : ApiController
    {
        public void Post([FromBody]string email, [FromBody] string name)
        {
            // TODO: implement api

            //using (SubscriptionContext dbContext = new SubscriptionContext())
            //{
            //    Subscriber subscriber = new Subscriber()
            //    {
            //        Name = "Irene",
            //        Email = "myemail2@google.com",
            //        CreateDate = DateTime.Now
            //    };

            //    dbContext.Subscribers.Add(subscriber);
            //    dbContext.SaveChanges();
            //}
        }
    }
}
