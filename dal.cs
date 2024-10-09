//DAL

using System;
using System.Data.SqlClient;

public class SeatBookingDAL
{
    private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SeatBookingDB"].ConnectionString;

    public bool BookSeat(int seatId)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            string query = "UPDATE Seats SET IsBooked = 1 WHERE SeatId = @SeatId AND IsBooked = 0";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@SeatId", seatId);

            int rowsAffected = cmd.ExecuteNonQuery();
            return rowsAffected > 0;
        }
    }

    public bool IsSeatAvailable(int seatId)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            string query = "SELECT COUNT(*) FROM Seats WHERE SeatId = @SeatId AND IsBooked = 0";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@SeatId", seatId);

            int count = (int)cmd.ExecuteScalar();
            return count > 0;
        }
    }
}
