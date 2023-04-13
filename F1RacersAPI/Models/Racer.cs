using System;
using System.Text;
using System.Collections.Generic;

namespace F1RacersAPI.Models
{
   [Serializable]
   public class Racer : IComparable<Racer>, IFormattable
   {
    
        public Racer(int id, string firstname, string lastname, string country, int starts, int wins)
        {

            this.id = id;
            this.firstname = firstname;
            this.lastname = lastname;
            this.country = country;
            this.starts = starts;
            this.wins = wins;
        }

      public Racer()
      {

      }

      private int id;

      public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string firstname = String.Empty;

      public string Firstname
      {
         get { return firstname; }
         set { firstname = value; }
      }

      private string lastname = String.Empty;

      public string Lastname
      {
         get { return lastname; }
         set { lastname = value; }
      }

      private int wins;

      public int Wins
      {
         get { return wins; }
         set { wins = value; }
      }

      private int starts;

      public int Starts
      {
         get { return starts; }
         set { starts = value; }
      }
	

      private string country = String.Empty;

      public string Country
      {
         get { return country; }
         set { country = value; }
      }

        public override string ToString()
        {
            return firstname + " " + lastname;
        }

        #region IComparable<Racer> Members

        public int CompareTo(Racer other)
      {
         return this.lastname.CompareTo(other.lastname);
      }

        #endregion


 

        #region IFormattable Members

        public string ToString(string format, IFormatProvider formatProvider)
      {
         switch (format)
         {
            case null:
            case "N":
               return ToString();
            case "F":
               return firstname;
            case "L":
               return lastname;
            case "A":
               StringBuilder sb = new StringBuilder();
               sb.Append(firstname);
               sb.Append(" ");
               sb.Append(lastname);
               sb.Append(", ");
               sb.Append(country);
               sb.Append("; starts: ");
               sb.Append(starts);
               sb.Append(", wins: ");
               sb.Append(wins);
               //sb.Append(", titles: ");
               //foreach (int title in titles)
               //{
               //   sb.Append(title);
               //   sb.Append(" ");
               //}
               return sb.ToString();
            default:
               throw new FormatException(String.Format("Format {0} not supported", format));

               
         }
      }

      #endregion

 
	
   }
}
