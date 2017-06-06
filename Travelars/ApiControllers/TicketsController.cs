using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Travelars.Models;
using Travelars.Models.Ticket;

namespace Travelars.ApiControllers
{
    [RoutePrefix("api/tickets")]
    public class TicketsController : ApiController
    {
        [Route("station")]
        [HttpGet]
        public HttpResponseMessage GetStation([FromUri] string stationName)
        {
            return Request.CreateResponse(HttpStatusCode.OK, new
            {
                Id = "22200001",
                Name = "КИЕВ-ПАССАЖИРСКИЙ"
            });
        }

        [Route("")]
        [HttpGet]
        public HttpResponseMessage Get([FromUri] TicketsRequest model)
        {
            return Request.CreateResponse(HttpStatusCode.OK, new TicketsResponse
            {
                DepartureStation = new Station
                {
                    Id = "22200001",
                    Name = "КИЕВ-ПАССАЖИРСКИЙ"
                },
                ArrivalStation = new Station
                {
                    Id = "22204001",
                    Name = "ХАРЬКОВ-ПАСС"
                },
                DepartureDate = model.DepartureDate,
                ReturnDate = model.ReturnDate,
                Variants = new TicketsVariant
                {
                    Id = "c1912161-a121-7d0d-00cb-00373736cf00",
                    DepartureDate = model.DepartureDate,
                    ArrivalDate = model.DepartureDate.AddDays(1),
                    Duration = new TimeSpan(0, 10, 15, 0),
                    Trip = new Trip
                    {
                        Id = "776П",
                        DepartureStation = new Station
                        {
                            Id = "22200001",
                            Name = "КИЕВ-ПАССАЖИРСКИЙ"
                        },
                        ArrivalStation = new Station
                        {
                            Id = "22204001",
                            Name = "ХАРЬКОВ-ПАСС"
                        }
                    },
                    Cars = new List<Car>
                    {
                        new Car
                        {
                            Type = CarType.RailwayPlats,
                            Number = 6,
                            Price = 305,
                            Seats = new List<Seat>
                            {
                                new Seat
                                {
                                    Type = SeatsType.RailwayBottom,
                                    FreeSeats = new List<string> {"4","9","40" }
                                }
                            }
                        }
                    }
                }
            });
        }

        [Route("")]
        [HttpPost]
        public HttpResponseMessage BuyTicket([FromBody] TicketsRequest model)
        {
            return Request.CreateResponse(HttpStatusCode.NotFound);
        }
    }
}
