using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdopteUneDev.WADAL
{
    public class ClientEndorseDev
    {
        #region Fields
        private int _idClient;
        private int _idDev;
        private DateTime _beginDate;
        private DateTime _endDate;
        private Guid _endorseNumber;
        private Client _client;
        private Developer _developer; 
        #endregion

        #region Properties
        public DateTime EndDate
        {
            get { return _endDate; }
            set { _endDate = value; }
        }

        public Guid EndorseNumber
        {
            get { return _endorseNumber; }
            set { _endorseNumber = value; }
        }

        public Client Client
        {
            get { return _client; }
            set { _client = value; }
        }

        public Developer Developer
        {
            get { return _developer; }
            set { _developer = value; }
        }

        public int IdDev
        {
            get { return _idDev; }
            set { _idDev = value; }
        }
        public DateTime BeginDate
        {
            get { return _beginDate; }
            set { _beginDate = value; }
        }
        public int IdClient
        {
            get { return _idClient; }
            set { _idClient = value; }
        } 
        #endregion

        public static List<ClientEndorseDev> GetEndorseByClient(int idCli)
        {
            return null;
        }
    }
}
