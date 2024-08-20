using Npgsql;
using SponsorAPI.Data;
using System.Data;
using NpgsqlTypes;
namespace SponsorAPI.DAO
{
    public class SponsorDaoImpl : ISponsorDAO
    {
        NpgsqlConnection _connection;

        public SponsorDaoImpl(NpgsqlConnection connection)
        {
            _connection = connection;
        }

        public async Task<List<Sponsor>> GetSponsors()
        {
            List<Sponsor> plist = new List<Sponsor>();
            string query = @"select * from sports.sponsors";
            string errMessage = string.Empty;
            Sponsor p = null;

            try
            {
                await _connection.OpenAsync();
                NpgsqlCommand command = new NpgsqlCommand(query, _connection);
                command.CommandType = CommandType.Text;
                NpgsqlDataReader reader = await command.ExecuteReaderAsync();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        p = new Sponsor();
                        p.Id = reader.GetInt32(0);
                        p.SponsorName = reader.GetString(1);
                        p.IndustryType = reader.GetString(2);
                        p.ContactEmail = reader.GetString(3);
                        p.PhoneNumber= reader.GetString(4);
                        plist.Add(p);
                    }
                }
                reader.Close();
            }
            catch (NpgsqlException e)
            {
                errMessage = e.Message;
                Console.WriteLine("------Exception-----:" + errMessage);
            }

            return plist;
        }

        //2)

        public async Task<List<Sponsor>> GetSponsorsDetailsWithPayments()
        {
            List<Sponsor> plist = new List<Sponsor>();
            string query = @"select * from sports.sponsordetails";
            string errMessage = string.Empty;
            Sponsor p = null;

            try
            {
                await _connection.OpenAsync();
                NpgsqlCommand command = new NpgsqlCommand(query, _connection);
                command.CommandType = CommandType.Text;
                NpgsqlDataReader reader = await command.ExecuteReaderAsync();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        p = new Sponsor();
                        p.Id = reader.GetInt32(0);
                        p.SponsorName = reader.GetString(1);
                        p.IndustryType = reader.GetString(2);
                        p.ContactEmail = reader.GetString(3);
                        p.PhoneNumber = reader.GetString(4);
                        p.TotalPayment = reader.GetDecimal(5);
                        p.NumberOfPayment = reader.GetInt32(6);
                        plist.Add(p);
                    }
                }
                reader.Close();
            }
            catch (NpgsqlException e)
            {
                errMessage = e.Message;
                Console.WriteLine("------Exception-----:" + errMessage);
            }

            return plist;
        }


        //3))

        public async Task<List<Sponsor>> GetMatchDetailsWithPayment()
        {
            List<Sponsor> plist = new List<Sponsor>();
            string query = @"select * from sports.matchdetailsandpayments";
            string errMessage = string.Empty;
            Sponsor p = null;

            try
            {
                await _connection.OpenAsync();
                NpgsqlCommand command = new NpgsqlCommand(query, _connection);
                command.CommandType = CommandType.Text;
                NpgsqlDataReader reader = await command.ExecuteReaderAsync();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        p = new Sponsor();
                        p.MatchID = reader.GetInt32(0);
                        p.MatchName = reader.GetString(1);
                        p.Date = reader.GetString(2);
                        p.Location = reader.GetString(3);
                        p.TotalPayment = reader.GetDecimal(4);
                       
                        plist.Add(p);
                    }
                }
                reader.Close();
            }
            catch (NpgsqlException e)
            {
                errMessage = e.Message;
                Console.WriteLine("------Exception-----:" + errMessage);
            }

            return plist;
        }
        //Insert Payment
        public async Task<int> InsertPayment(Sponsor payment)
        {
            int rowInserted = 0;
            string insertQuery = $"insert into sports.payments(paymentid,paymentdate,amountpaid,paymentstatus) values ('{payment.PaymentID}','{payment.PaymentDate}','{payment.AmountPaid}','{payment.PaymentStatus}') ;";
            try
            {
                using (_connection)
                {
                    await _connection.OpenAsync();
                    NpgsqlCommand insertCommand = new NpgsqlCommand(insertQuery, _connection);
                    insertCommand.CommandType = CommandType.Text;
                    rowInserted = await insertCommand.ExecuteNonQueryAsync();
                }
            }
            catch (NpgsqlException e)
            {
                string msg = e.Message;
                Console.WriteLine(msg);
            }
            return (rowInserted);
        }

    }

}
