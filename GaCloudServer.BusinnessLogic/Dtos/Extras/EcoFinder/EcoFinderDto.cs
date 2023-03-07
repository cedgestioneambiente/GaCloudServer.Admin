using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.BusinnessLogic.Dtos.Extras.EcoFinder
{
    public class FleetType
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
    }

    public class DualEventStatusType
    {
        public int id { get; set; }
        public string description { get; set; }
        public int idDevice { get; set; }
        public int idDualEvent { get; set; }
        public double totWorkDist { get; set; }
        public double totWorkTime { get; set; }

    }

    public class EventsType
    {
        public int id { get; set; }
        public string description { get; set; }
        public int idDevice { get; set; }
        public int idEvent { get; set; }
        public DateTime dateTime { get; set; }
        public string info { get; set; }
        public double km { get; set; }
        public double xcoord { get; set; }
        public double ycoord { get; set; }

    }

    public class LastPositionType
    {
        public DateTime date { get; set; }
        public double xcoord { get; set; }
        public double ycoord { get; set; }
    }

    public class PathPointType
    {
        public DateTime date { get; set; }
        public double km { get; set; }
        public double xcoord { get; set; }
        public double ycoord { get; set; }
        public double speed { get; set; }
        public bool highlight { get; set; }
    }

    public class AlarmType
    {
        public int id { get; set; }
        public string description { get; set; }// Descrizione dell’allarme String
        public int idDevice { get; set; } // Id Dispositivo Int
        public int idEventDef { get; set; } // Id Evento Int
        public string message { get; set; } //Informazioni relative all’allarme String
        public DateTime activationTime { get; set; } // Data ora attivazione Datetime
        public bool alrAcknowledge { get; set; }
        public bool alrStatus { get; set; } // Boolean
        public double xcoord { get; set; }// Coordinata X(WGS84) Float
        public double ycoord { get; set; } // Coordinata Y(WGS84) Float
    }

    public class AuthenticationResponse
    {
        public string token { get; set; } // Token restituito da autilizzarsi nelle chiamate agli altri metodi String
        public string username { get; set; } // Nome utente d’accesso String
    }

    public class GroupsResponse
    {
        public string description { get; set; } // Descrizione del gruppo String
        public int id { get; set; } // Id del gruppo Int
        public string name { get; set; } // Nome del gruppo String
        public List<FleetType> fleets { get; set; } // Elenco flotte appartenenti al gruppo List<FleetType>
    }

    public class DevicesResponse
    {
        public string description { get; set; } // Descrizione del dispositivo(di solito targa del veicolo) String
        public int fleetId { get; set; } // Id flotta di appartenenza Int
        public int id { get; set; }//Id del device Int
        public double totaleKm { get; set; } //Distanza totale del veicolo Float
    }

    public class DeviceDataRequest
    {
        public string targa { get; set; }
        public DateTime dateStart { get; set; }
        public DateTime dateEnd { get; set; }
    }

    public class DeviceDataResponse
    {
        public List<AlarmType> alarms { get; set; }// List<AlarmType>
        public string description { get; set; }// Descrizione del dispositivo (di solito targa del veicolo) String
        public double distanzaPercorso { get; set; } // Distanza totale del percorso rilevato Float
        public List<DualEventStatusType> dualEventStatus { get; set; } //Informazioni cumulative sugli eventi duali List<DualEventStatusType>
        public List<EventsType> events { get; set; } // Elenco Eventi rilevati dal dispositivo List<EventsType>
        public DateTime? finePercorso { get; set; } // Data Ora di fine percorso Datetime
        public int id { get; set; }// Id del device Int
        public DateTime? inizioPercorso { get; set; }// Data Ora di inizio percorso Datetime
        public LastPositionType lastPosition { get; set; }// Ultima posizione del dispositivo LastPositionType
        public List<PathPointType> routes { get; set; } //Percorso memorizzato dal dispositivo List<PathPointType>
        public string status { get; set; } //Ultimo stato quadro String “CHIAVEOFF”
    }
}
