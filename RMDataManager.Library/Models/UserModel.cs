using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMDataManager.Library.Models
{
    public class UserModel
    {
        /// <summary>
        /// The unique identifier for a given user
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// User's First Name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// User's Last Name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// User's email address.
        /// </summary>
        public string EmailAddress { get; set; }

        /// <summary>
        /// The date has the user's profile was created.
        /// </summary>
        public DateTime CreatedDate { get; set; } 

    }
}
