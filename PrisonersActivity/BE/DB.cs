using System.Data;

namespace PrisonersActivity.BE
{
    internal class Db
    {
        public DataTable GetNationalities()
        {
            var txtq = $@"SELECT
  nationalityid, nationalityname
FROM tblnationalities
order by nationalityid";
            return new Dal().Select(txtq);

        }
        public void InsertNationality(string name)
        {
            var txtq = $@"INSERT INTO tblnationalities (nationalityname) VALUES ('{name}')";
            new Dal().ExcuteCommand(txtq);
        }
    }
}
