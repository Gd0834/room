// API

using System.Web.Http;

public class SeatBookingController : ApiController
{
    private SeatBookingDAL seatBookingDAL = new SeatBookingDAL();

    [HttpPost]
    [Route("api/bookSeat")]
    public IHttpActionResult BookSeat([FromBody] int seatId)
    {
        if (seatBookingDAL.IsSeatAvailable(seatId))
        {
            bool success = seatBookingDAL.BookSeat(seatId);
            if (success)
            {
                return Ok("Seat booked successfully!");
            }
            else
            {
                return BadRequest("Failed to book seat.");
            }
        }
        else
        {
            return BadRequest("Seat is already booked.");
        }
    }
}
