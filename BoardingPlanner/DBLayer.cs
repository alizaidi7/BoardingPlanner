using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BoardingPlanner
{
    public class DBLayer
    {
        private static OleDbConnection _connection;
        private static DBLayer _instance;
        public IList<RankDTO> Ranks;
        public IList<TechnicalGroupDTO> TechnicalGroups;
        public IList<VesselDTO> Vessels;
        public IList<StaffDTO> Staffs;

        private DBLayer()
        {
            var appPath = Application.ExecutablePath;
            _connection = new OleDbConnection($"Provider = Microsoft.ACE.OLEDB.12.0; Data Source ={Path.Combine(Path.GetDirectoryName(appPath), "OnBoardDB.accdb")};Persist Security Info = True;");
            _connection.Open();
            SetupAutoCompletes();
        }

        public static DBLayer Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new DBLayer();
                return _instance;
            }
        }

        internal void ImportStaff(IEnumerable<PlannerDTO> data)
        {
            var command = new OleDbCommand(string.Empty, _connection);
            CreateRanks(data, command);
            CreateVessels(data, command);
            CreateStaffs(data, command);
        }

        internal void UpdatePlanning(int planningId, string replacement, string remarks)
        {
            var command = new OleDbCommand(string.Empty, _connection);
            command.CommandText = $"UPDATE tblPlanning SET Remarks = Remarks & ' {replacement}', Replacement = Replacement & ' {remarks}' WHERE Id = {planningId}";
            command.ExecuteNonQuery();
        }

        internal void ImportData(IEnumerable<PlannerDTO> data)
        {
            var command = new OleDbCommand(string.Empty, _connection);
            CreateRanks(data, command);
            CreateTechnicalGroups(data, command);
            CreateVessels(data, command);
            CreateStaffs(data, command);
            CreatePlanings(data, command);
            SetupAutoCompletes();
        }

        private void CreateRanks(IEnumerable<PlannerDTO> data, OleDbCommand command)
        {
            var ranks = data.Select(o => o.Rank).Distinct();
            foreach (var rank in ranks)
            {
                command.CommandText = $"SELECT Id FROM tblRank WHERE Name = '{rank}'";
                var result = command.ExecuteScalar();
                if (result == null)
                {
                    command.CommandText = $"INSERT INTO tblRank(Name)VALUES('{rank}')";
                    command.ExecuteNonQuery();
                }
            }
        }

        private void CreateTechnicalGroups(IEnumerable<PlannerDTO> data, OleDbCommand command)
        {
            var technicalGroups = data.Select(o => o.TechnicalGroup).Distinct();
            foreach (var technicalGroup in technicalGroups)
            {
                command.CommandText = $"SELECT Id FROM tblTechnicalGroup WHERE Name = '{technicalGroup}'";
                var result = command.ExecuteScalar();
                if (result == null)
                {
                    command.CommandText = $"INSERT INTO tblTechnicalGroup(Name)VALUES('{technicalGroup}')";
                    command.ExecuteNonQuery();
                }
            }
        }

        private void CreateVessels(IEnumerable<PlannerDTO> data, OleDbCommand command)
        {
            var vessels = data.Select(o => o.Vessel).Distinct();
            foreach (var vessel in vessels)
            {
                command.CommandText = $"SELECT Id FROM tblVessel WHERE Name = '{vessel}'";
                var result = command.ExecuteScalar();
                if (result == null)
                {
                    command.CommandText = $"INSERT INTO tblVessel(Name)VALUES('{vessel}')";
                    command.ExecuteNonQuery();
                }
            }
        }

        private void CreateStaffs(IEnumerable<PlannerDTO> data, OleDbCommand command)
        {
            var staffs = data.Select(o => new { o.HKID, o.Name }).Distinct();
            foreach (var staff in staffs)
            {
                command.CommandText = $"SELECT Id FROM tblStaff WHERE HKID = {staff.HKID}";
                var result = command.ExecuteScalar();
                if (result == null)
                {
                    command.CommandText = $"INSERT INTO tblStaff(HKID, Name)VALUES({staff.HKID}, '{staff.Name}')";
                    command.ExecuteNonQuery();
                }
            }
        }

        private void CreatePlanings(IEnumerable<PlannerDTO> data, OleDbCommand command)
        {
            foreach (var item in data)
            {
                command.CommandText = $"SELECT Id FROM tblPlanning WHERE StaffId = (SELECT Id FROM tblStaff WHERE HKID = {item.HKID})";
                var result = command.ExecuteScalar();
                if (result == null)
                {
                    CreatePlaning(command, item);
                }
            }
        }

        private void CreatePlaning(OleDbCommand command, PlannerDTO item)
        {
            command.CommandText = $"SELECT Id FROM tblStaff WHERE HKID = {item.HKID}";
            int hkid = Convert.ToInt32(command.ExecuteScalar());
            if (hkid == 0)
            {
                hkid = CreateStaff(command, item.HKID, item.Name);
            }
            command.CommandText = $"SELECT Id FROM tblRank WHERE Name = '{item.Rank}'";
            int rankId = Convert.ToInt32(command.ExecuteScalar());
            if (rankId == 0)
            {
                rankId = CreateRank(command, item.Name);
            }
            command.CommandText = $"SELECT Id FROM tblVessel WHERE Name = '{item.Vessel}'";
            int vesselId = Convert.ToInt32(command.ExecuteScalar());
            if (vesselId == 0)
            {
                vesselId = CreateVessel(command, item.Vessel);
            }
            command.CommandText = $"SELECT Id FROM tblTechnicalGroup WHERE Name = '{item.TechnicalGroup}'";
            int techgroupId = Convert.ToInt32(command.ExecuteScalar());
            if (techgroupId == 0)
            {
                techgroupId = CreateTechnicalGroup(command, item.TechnicalGroup);
            }
            command.CommandText = $@"INSERT INTO tblPlanning(SerialNumber, StaffId, RankId, VesselId, TechnicalGroupId, COC, Replacement, Remarks)
                                            VALUES({item.SerialNumber}, {hkid}, {rankId}, {vesselId}, {techgroupId},
                                            '{item.COC}', '{item.Replacement.Replace("'", "''")}', '{item.Remarks.Replace("'", "''")}')";

            command.ExecuteNonQuery();
        }

        private int CreateStaff(OleDbCommand command, int hKID, string name)
        {
            command.CommandText = $"INSERT INTO tblStaff(HKID, Name)VALUES({hKID}, '{name}')";
            command.ExecuteNonQuery();
            command.CommandText = $"SELECT Id FROM tblStaff WHERE HKID = {hKID}";
            return Convert.ToInt32(command.ExecuteScalar());
        }

        private int CreateRank(OleDbCommand command, string name)
        {
            command.CommandText = $"INSERT INTO tblRank(Name)VALUES('{name}')";
            command.ExecuteNonQuery();
            command.CommandText = $"SELECT Id FROM tblRank WHERE Name = '{name}'";
            return Convert.ToInt32(command.ExecuteScalar());
        }

        private int CreateVessel(OleDbCommand command, string name)
        {
            command.CommandText = $"INSERT INTO tblVessel(Name)VALUES('{name}')";
            command.ExecuteNonQuery();
            command.CommandText = $"SELECT Id FROM tblVessel WHERE Name = '{name}'";
            return Convert.ToInt32(command.ExecuteScalar());
        }

        private int CreateTechnicalGroup(OleDbCommand command, string name)
        {
            command.CommandText = $"INSERT INTO tblTechnicalGroup(Name)VALUES('{name}')";
            command.ExecuteNonQuery();
            command.CommandText = $"SELECT Id FROM tblTechnicalGroup WHERE Name = '{name}'";
            return Convert.ToInt32(command.ExecuteScalar());
        }

        public void SetupAutoCompletes()
        {
            Ranks = new List<RankDTO>();
            TechnicalGroups = new List<TechnicalGroupDTO>();
            Staffs = new List<StaffDTO>();
            Vessels = new List<VesselDTO>();
            OleDbCommand command = new OleDbCommand("SELECT Id, Name FROM tblRank", _connection);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                Ranks.Add(new RankDTO { Id = reader.GetInt32(0), Name = reader.GetString(1) });
            }
            reader.Close();
            command.CommandText = "SELECT Id, HKID, Name FROM tblStaff";
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Staffs.Add(new StaffDTO { Id = reader.GetInt32(0), HKID = reader.GetInt32(1), Name = reader.GetString(2) });
            }
            reader.Close();
            command.CommandText = "SELECT Id, Name FROM tblVessel";
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Vessels.Add(new VesselDTO { Id = reader.GetInt32(0), Name = reader.GetString(1) });
            }
            reader.Close();
            command.CommandText = "SELECT Id, Name FROM tblTechnicalGroup";
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                TechnicalGroups.Add(new TechnicalGroupDTO { Id = reader.GetInt32(0), Name = reader.GetString(1) });
            }
            reader.Close();
        }

        public IList<PlannerDTO> GetPlannings(int hkid, string name, string rank, string vessel, string techGroup, DateTime coc)
        {
            var query = $@"SELECT tblPlanning.Id, tblPlanning.SerialNumber, tblRank.Name, tblStaff.HKID, tblStaff.Name, tblVessel.Name, tblTechnicalGroup.Name, tblPlanning.COC, tblPlanning.Remarks, tblPlanning.Replacement, tblPlanning.Id
                                    FROM tblVessel INNER JOIN (tblTechnicalGroup INNER JOIN (tblStaff INNER JOIN (tblRank INNER JOIN tblPlanning ON tblRank.Id = tblPlanning.RankId) ON tblStaff.Id = tblPlanning.StaffId) ON tblTechnicalGroup.Id = tblPlanning.TechnicalGroupId) ON tblVessel.Id = tblPlanning.VesselId WHERE 1 = 1 ";

            if (hkid > 0)
            {
                query = query + $" AND tblStaff.HKID LIKE '%{hkid}%'";
            }
            if (string.IsNullOrEmpty(name) == false)
            {
                query = query + $" AND tblStaff.Name LIKE '%{name}%'";
            }
            if (string.IsNullOrEmpty(rank) == false)
            {
                query = query + $" AND tblRank.Name LIKE '%{rank}%'";
            }
            if (string.IsNullOrEmpty(vessel) == false)
            {
                query = query + $" AND tblVessel.Name LIKE '%{vessel}%'";
            }
            if (string.IsNullOrEmpty(techGroup) == false)
            {
                query = query + $" AND tblTechnicalGroup.Name LIKE '%{techGroup}%'";
            }
            if (coc > new DateTime(2000, 1, 1))
            {
                query = query + $" AND tblPlanning.COC > '{coc}'";
            }

            OleDbCommand command = new OleDbCommand(query, _connection);
            OleDbDataReader reader = command.ExecuteReader();
            IList<PlannerDTO> plannings = new List<PlannerDTO>();
            while (reader.Read())
            {
                plannings.Add(new PlannerDTO
                {
                    SerialNumber = reader.GetInt32(1),
                    Rank = reader.GetString(2),
                    HKID = reader.GetInt32(3),
                    Name = reader.GetString(4),
                    Vessel = reader.GetString(5),
                    TechnicalGroup = reader.GetString(6),
                    COC = reader.GetDateTime(7),
                    Remarks = reader.GetString(8),
                    Replacement = reader.GetString(9),
                    Id = reader.GetInt32(10),
                });
            }
            reader.Close();
            return plannings.OrderBy(o => o.SerialNumber).ToList();
        }

        public void CreatePlanning(PlannerDTO dto)
        {
            var command = new OleDbCommand(string.Empty, _connection);
            command.CommandText = $"SELECT Id FROM tblPlanning WHERE StaffId = (SELECT Id FROM tblStaff WHERE HKID = {dto.HKID})";
            var result = command.ExecuteScalar();
            if (result != null)
            {
                _connection.Close();
                throw new InvalidOperationException("Planning already exists for this staff.");
            }
            CreatePlaning(command, dto);
        }

        public int GetSerialNumber()
        {
            var command = new OleDbCommand("SELECT MAX(SerialNumber) FROM tblPlanning", _connection);
            var result = command.ExecuteScalar();
            var sNo = 1;
            if (result != null)
            {
                sNo = Convert.ToInt32(result) + 1;
            }
            return sNo;
        }

        public string GetStaffName(int hkid)
        {
            var command = new OleDbCommand($"SELECT Name FROM tblStaff WHERE HKID = {hkid}", _connection);
            var result = command.ExecuteScalar();
            return Convert.ToString(result);
        }

        public void ExecureReplacement(int planningId, int hkid, string name)
        {
            var command = new OleDbCommand(string.Empty, _connection);
            command.CommandText = $"SELECT Id FROM tblPlanning WHERE Id <> {planningId} AND StaffId = (SELECT Id FROM tblStaff WHERE HKID = {hkid})";
            var result = command.ExecuteScalar();
            if (result != null)
            {
                throw new InvalidOperationException("Planning already exists for this staff.");
            }
            command.CommandText = $"SELECT Id FROM tblStaff WHERE HKID = {hkid}";
            int staffId = Convert.ToInt32(command.ExecuteScalar());
            if (staffId == 0)
            {
                staffId = CreateStaff(command, hkid, name);
            }
            command.CommandText = $"UPDATE tblPlanning SET StaffId = {staffId} WHERE Id = {planningId}";
            command.ExecuteNonQuery();
        }

        internal IList<StaffDTO> GetOnLeave(int hkid, string name)
        {
            string query = "SELECT HKID, Name FROM tblStaff WHERE Id NOT IN (SELECT StaffId FROM tblPlanning)";
            if (hkid > 0)
            {
                query = query + $" AND HKID LIKE '%{hkid}%'";
            }
            if (string.IsNullOrEmpty(name) == false)
            {
                query = query + $" AND Name LIKE '%{name}%'";
            }
            var command = new OleDbCommand(query, _connection);
            OleDbDataReader reader = command.ExecuteReader();
            IList<StaffDTO> staffs = new List<StaffDTO>();
            while (reader.Read())
            {
                staffs.Add(new StaffDTO
                {
                    HKID = reader.GetInt32(0),
                    Name = reader.GetString(1),
                });
            }
            reader.Close();
            return staffs.OrderBy(o => o.HKID).ToList();
        }
    }
}
