using LandingPageSignup.DAL;
using LandingPageSignup.Models;
using System;
using System.Web.Http;

namespace LandingPageSignup.Controllers
{
    public class SignupController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Post([FromBody] SubscriberIn data)
        {
            // Validate subscriber input data
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data");
            }

            // Persist subscriber data in database
            // TODO: implement through DI
            var subscriberId = 0;
            try
            {
                using (SubscriptionContext dbContext = new SubscriptionContext())
                {
                    Subscriber subscriber = new Subscriber()
                    {
                        Name = data.Name,
                        Email = data.Email,
                        CreateDate = DateTime.Now
                    };

                    dbContext.Subscribers.Add(subscriber);
                    dbContext.SaveChanges();

                    subscriberId = subscriber.Id;
                }
            }
            catch (Exception)
            {
                // TODO: log error
                throw;
            }

            return Ok(subscriberId);
        }
    }
}
