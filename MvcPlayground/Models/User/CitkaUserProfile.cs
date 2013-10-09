using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MvcPlayground.Models.User
{
    public class CitkaUserProfile
    {
        private string _name;
        private string _email;

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                string[] parts = _name.Split(' ');
                FirstName = parts[0];
                LastName = parts[1];
            }
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                string[] parts = _email.Split('@');
                UserName = parts[0];
            }
        }
        public string Bio { get; set; }

        public CitkaUserProfile()
        {
            UserName = "wwhite";
            Bio = @"Walter is a 50-year old chemistry teacher at Wynne High School in Albuquerque, New Mexico. He is a husband and father of a teenage son. His wife Skyler is pregnant with the couple's second child. He forms a drug production partnership with former student Jesse Pinkman that is the driving force behind the story.

When we first meet Walter he is diagnosed with lung cancer and given approximately two years to live. He learns this startling news alone and the information brings him to a crossroads. His plan is to quickly make as much money as possible so he will have something to leave his family. This leads to connecting with Jesse, a former student who is now a local meth cook.

Though his talent for chemistry appears to be wasted at the high school level, Walter does seems to enjoy bringing science to young minds. This affinity for teaching can be seen in the relationship between Walter and Jesse.

In his former life Walter was a supremely talented chemist, having studied at Caltech with some of the field's sharpest minds. He formed a company called Gray Matter with his friend, Elliott Schwartz, but eventually sold his share in the company.";
        }
    }
}
