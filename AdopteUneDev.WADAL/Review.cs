using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdopteUneDev.WADAL
{
    public class Review
    {
        public int idReview { get; set; }
        public int idDev { get; set; }
        public string ReviewName { get; set; }
        public string ReviewText { get; set; }
        public DateTime ReviewDate { get; set; }
        public string ReviewMail { get; set; }

        public static List<Review> getReviewsFromDev(int idD)
        {
            List<Review> retour = new List<Review>();

            List<Dictionary<string, object>> DesReviews =
            GestionConnexion.Instance.getData("select * from Review where idDev=" + idD);

            foreach (Dictionary<string, object> item in DesReviews)
            {
                Review r = new Review()
                {
                    idDev = (int)item["idDev"],
                    idReview = (int)item["idReview"],
                    ReviewName = item["ReviewName"].ToString(),
                    ReviewMail = item["ReviewMail"].ToString(),
                    ReviewDate = (DateTime)item["ReviewDate"],
                    ReviewText = item["ReviewText"].ToString()
                };

                retour.Add(r);
            }
            return retour;

        }

        public static void AddReview(int id, string txtName, string txtMail, string txtText)
        {
            string query = @"INSERT INTO [AdopteUneDev].[dbo].[Review]
           ([ReviewName]
           ,[ReviewText]
           ,[ReviewMail]
           ,[idDev])
     VALUES
           (@ReviewName,@ReviewText,@ReviewMail,@idDev)";
            Dictionary<string, object> dicovalues = new Dictionary<string, object>();

            dicovalues.Add("ReviewName", txtName);
            dicovalues.Add("ReviewText", txtText);
            dicovalues.Add("ReviewMail", txtMail);
            dicovalues.Add("idDev", id);

            GestionConnexion.Instance.saveData(query, GenerateKey.APP, dicovalues);
        }
    }
}
